using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using NhibernateclassGeneration.Domain;
using NhibernateclassGeneration.Textformatter;

namespace NhibernateclassGeneration
{
    class CodeGenerator : AbstractGenerator
    {
        private readonly ApplicationPreferences appPrefs;
      

        public CodeGenerator(ApplicationPreferences appPrefs, Table table)
            : base(appPrefs.DomainFolderPath, appPrefs.TableName, appPrefs.NameSpace, appPrefs.AssemblyName, table, appPrefs)
        {
            this.appPrefs = appPrefs;
   
            Inflector.EnableInflection = appPrefs.EnableInflections;
        }
        public override void Generate(bool writeToFile = true)
        {
            var className = appPrefs.TableName;
            var compileUnit = GetCompileUnit(className);

            if (writeToFile)
            {
                WriteToFile(compileUnit, className);
            }
            else
            {
                // Output to property
                GeneratedCode = WriteToString(compileUnit, GetCodeDomProvider());
            }
        }
        public CodeCompileUnit GetCompileUnit(string className)
        {
            var codeGenerationHelper = new CodeGenerationHelper();
            string nameSpace="Entity";
            var compileUnit = codeGenerationHelper.GetCodeCompileUnitWithInheritanceAndInterface(nameSpace, className, "");

            var mapper = new DataTypeMapper();
            var newType = compileUnit.Namespaces[0].Types[0];
            CreateProperties(codeGenerationHelper, mapper, newType);
             // Generate GetHashCode() and Equals() methods.
            if (Table.PrimaryKey != null && Table.PrimaryKey.Columns.Count != 0 && Table.PrimaryKey.Type == PrimaryKeyType.CompositeKey)
            {
                var pkColsList = new List<string>();
                foreach (var pkCol in Table.PrimaryKey.Columns)
                {
                   
                  
                     pkColsList.Add(Formatter.FormatText(pkCol.Name));
                    
                }

                var equalsCode = CreateCompositeKeyEqualsMethod(pkColsList);
                var getHashKeyCode = CreateCompositeKeyGetHashKeyMethod(pkColsList);

                equalsCode.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "NHibernate Composite Key Requirements"));
                newType.Members.Add(equalsCode);
                newType.Members.Add(getHashKeyCode);
                getHashKeyCode.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
            }

            // Dont create a constructor if there are no relationships.
            
                return compileUnit;

            
           
        }
        private CodeMemberMethod CreateCompositeKeyEqualsMethod(IList<string> columns)
        {
            if (columns.Count == 0)
                return null;

            var method = new CodeMemberMethod
            {
                Name = "Equals",
                ReturnType = new CodeTypeReference(typeof(bool)),
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
            };

            method.Parameters.Add(new CodeParameterDeclarationExpression("System.Object", "obj"));

            // Create the if statement to compare if the obj equals another.
            var compareCode = new StringBuilder();

            var className = appPrefs.TableName;

            if (appPrefs.Language == Language.CSharp)
            {
                method.Statements.Add(new CodeSnippetStatement("\t\t\tif (obj == null) return false;"));
                method.Statements.Add(new CodeSnippetStatement(string.Format("\t\t\tvar t = obj as {0};", className)));
                method.Statements.Add(new CodeSnippetStatement("\t\t\tif (t == null) return false;"));

                compareCode.Append("\t\t\tif (");
                var lastCol = columns.LastOrDefault();
                foreach (var column in columns)
                {
                    compareCode.Append(string.Format("{0} == t.{0}", column));
                    compareCode.Append(column != lastCol ? "\n\t\t\t && " : ")");
                }
                method.Statements.Add(new CodeSnippetStatement(compareCode.ToString()));

                method.Statements.Add(new CodeSnippetStatement("\t\t\t\treturn true;"));
                method.Statements.Add(new CodeSnippetStatement(string.Empty));
                method.Statements.Add(new CodeSnippetStatement("\t\t\treturn false;"));
            }
           
            return method;
        }

        private CodeMemberMethod CreateCompositeKeyGetHashKeyMethod(IList<string> columns)
        {
            if (columns.Count == 0)
                return null;

            var method = new CodeMemberMethod
            {
                Name = "GetHashCode",
                ReturnType = new CodeTypeReference(typeof(int)),
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
            };

            if (appPrefs.Language == Language.CSharp)
            {
                // Create the if statement to compare if the obj equals another.
                method.Statements.Add(new CodeSnippetStatement("\t\t\tint hash = GetType().GetHashCode();"));

                foreach (var column in columns)
                {
                    method.Statements.Add(
                        new CodeSnippetStatement(string.Format("\t\t\thash = (hash * 397) ^ {0}.GetHashCode();", column)));
                }

                method.Statements.Add(new CodeSnippetStatement(string.Empty));
                method.Statements.Add(new CodeSnippetStatement("\t\t\treturn hash;"));
            }
            else if (appPrefs.Language == Language.VB)
            {
                // Create the if statement to compare if the obj equals another.
                method.Statements.Add(new CodeSnippetStatement("\t\t\tDim hash As Integer = 13"));

                foreach (var column in columns)
                {
                    method.Statements.Add(new CodeSnippetStatement(string.Format("\t\t\thash += {0}.GetHashCode()", column)));
                }

                method.Statements.Add(new CodeSnippetStatement(string.Empty));
                method.Statements.Add(new CodeSnippetStatement("\t\t\tReturn hash"));
            }
            return method;
        }
        private void CreateProperties(CodeGenerationHelper codeGenerationHelper, DataTypeMapper mapper, CodeTypeDeclaration newType)
        {
             
                    CreateAutoProperties(codeGenerationHelper, mapper, newType);
                    
        }

       
        private void AttachValidatorAttributes(ref CodeMemberProperty property, Column column)
        {
           
                    if (!column.IsNullable)
                    {
                        property.CustomAttributes.Add(new CodeAttributeDeclaration("Required"));
                    }
                    if (column.DataLength.HasValue & column.DataLength > 0 & column.MappedDataType == "System.String" & appPrefs.IncludeLengthAndScale)
                    {
                        property.CustomAttributes.Add(new CodeAttributeDeclaration("StringLength", new CodeAttributeArgument(new CodePrimitiveExpression(column.DataLength))));
                    }
          }

      
        private string FixPropertyWithSameClassName(string property, string className)
        {
            return property.ToLowerInvariant() == className.ToLowerInvariant() ? property + "Val" : property;
        }
        private void WriteToFile(CodeCompileUnit compileUnit, string className)
        {
            var provider = GetCodeDomProvider();
            var sourceFile = GetCompleteFilePath(provider, className);
            var streamWriter = new StringWriter();
            using (provider)
            {
                var textWriter = new IndentedTextWriter(streamWriter, "    ");
                using (textWriter)
                {
                    using (streamWriter)
                    {
                        var options = new CodeGeneratorOptions { BlankLinesBetweenMembers = false };
                        provider.GenerateCodeFromCompileUnit(compileUnit, textWriter, options);
                    }
                }
            }
            var entireContent = CleanupGeneratedFile(streamWriter.ToString());

            using (var writer = new StreamWriter(sourceFile))
            {
                writer.Write(entireContent);
            }
        }
        public CodeCompileUnit GetCodeCompileUnitWithInheritanceAndInterface(string nameSpace, string className, string inheritanceAndInterface)
        {
            var codeGenerationHelper = new CodeGenerationHelper();
            var codeCompileUnit = codeGenerationHelper.GetCodeCompileUnit(nameSpace, className);
            if (!string.IsNullOrEmpty(inheritanceAndInterface))
            {
                foreach (CodeNamespace ns in codeCompileUnit.Namespaces)
                {
                    foreach (CodeTypeDeclaration type in ns.Types)
                    {
                        foreach (var classOrInterface in inheritanceAndInterface.Split(','))
                            type.BaseTypes.Add(new CodeTypeReference(classOrInterface.Replace("<T>", "<" + className + ">").Trim()));
                    }
                }
            }
            return codeCompileUnit;
        }
        private void CreateAutoProperties(CodeGenerationHelper codeGenerationHelper, DataTypeMapper mapper, CodeTypeDeclaration newType)
        {
            if (Table.PrimaryKey != null)
            {
                foreach (var pk in Table.PrimaryKey.Columns)
                {
                    if (pk.IsForeignKey && appPrefs.IncludeForeignKeys)
                    {
                        newType.Members.Add(codeGenerationHelper.CreateAutoProperty(Formatter.FormatSingular(pk.ForeignKeyTableName),
                                                                                    Formatter.FormatSingular(pk.ForeignKeyTableName),
                                                                                    appPrefs.UseLazy));
                    }
                    else
                    {
                        var mapFromDbType = mapper.MapFromDBType(this.appPrefs.ServerType, pk.DataType, pk.DataLength,
                                                             pk.DataPrecision, pk.DataScale);
                        var fieldName = FixPropertyWithSameClassName(pk.Name, Table.Name);
                        var pkAlsoFkQty = (from fk in Table.ForeignKeys.Where(fk => fk.UniquePropertyName == pk.Name) select fk).Count();
                        if (pkAlsoFkQty > 0)
                            fieldName = fieldName + "Id";
                        newType.Members.Add(codeGenerationHelper.CreateAutoProperty(mapFromDbType.ToString(),
                                                                                Formatter.FormatText(fieldName),
                                                                                appPrefs.UseLazy));
                    }
                }
            }

            //if (appPrefs.IncludeForeignKeys)
            //{
            //    var pascalCaseTextFormatter = new PascalCaseTextFormatter { PrefixRemovalList = appPrefs.FieldPrefixRemovalList };
            //    // Note that a foreign key referencing a primary within the same table will end up giving you a foreign key property with the same name as the table.
            //    string lastOne = null;
            //    foreach (var fk in Table.Columns.Where(c => c.IsForeignKey && !c.IsPrimaryKey))
            //    {
            //        var typeName = appPrefs.ClassNamePrefix + pascalCaseTextFormatter.FormatSingular(fk.ForeignKeyTableName);
            //        var propertyName = Formatter.FormatSingular(fk.ForeignKeyTableName);
            //        var fieldName = FixPropertyWithSameClassName(propertyName, Table.Name);
            //        if (lastOne != fieldName)
            //            newType.Members.Add(codeGenerationHelper.CreateAutoProperty(typeName, fieldName, appPrefs.UseLazy));
            //        lastOne = fieldName;
            //    }
            //}

            foreach (var column in Table.Columns.Where(x => !x.IsPrimaryKey && (!x.IsForeignKey || !appPrefs.IncludeForeignKeys)))
            {
                var mapFromDbType = mapper.MapFromDBType(this.appPrefs.ServerType, column.DataType, column.DataLength, column.DataPrecision, column.DataScale);

                var fieldName = FixPropertyWithSameClassName(column.Name, Table.Name);
                var property = codeGenerationHelper.CreateAutoProperty(mapFromDbType, Formatter.FormatText(fieldName), column.IsNullable, appPrefs.UseLazy);
                AttachValidatorAttributes(ref property, column);
                newType.Members.Add(property);
            }
        }
        protected override string CleanupGeneratedFile(string entireContent)
        {
            entireContent = RemoveComments(entireContent);
            entireContent = AddStandardHeader(entireContent);
            entireContent = FixAutoProperties(entireContent);
            entireContent = FixNullableTypes(entireContent);
            //Fix Attrubutes with blank parenthesis
            entireContent = entireContent.Replace("()]", "]");

            return entireContent;
        }
        // Hack : Auto property generator is not there in CodeDom.
        private string FixAutoProperties(string entireContent)
        {
           var builder = new StringBuilder();
                builder.AppendLine("{");
                builder.Append("        }");
                entireContent = entireContent.Replace(builder.ToString(), "{ }");
                builder.Clear();
                builder.AppendLine("{");
                builder.AppendLine("            get {");
                builder.AppendLine("            }");
                builder.AppendLine("            set {");
                builder.AppendLine("            }");
                builder.Append("        }");
                entireContent = entireContent.Replace(builder.ToString(), "{ get; set; }");
           
           
            return entireContent;
        }
        // Hack : Fix Nullable Types, use "int?" instead of System.Nullable<int>.
        private string FixNullableTypes(string entireContent)
        {
                entireContent = entireContent.Replace("System.Nullable<bool>", "bool?");
                entireContent = entireContent.Replace("System.Nullable<int>", "int?");
                entireContent = entireContent.Replace("System.Nullable<byte>", "byte?");
                entireContent = entireContent.Replace("System.Nullable<short>", "short?");
                entireContent = entireContent.Replace("System.Nullable<long>", "long?");
                entireContent = entireContent.Replace("System.Nullable<decimal>", "decimal?");
                entireContent = entireContent.Replace("System.Nullable<float>", "float?");
                entireContent = entireContent.Replace("System.Nullable<double>", "double?");
                entireContent = entireContent.Replace("System.Nullable<System.DateTime>", "DateTime?");
                //Just remove the "System." from DateTime type. (we already have the "using System;" statement)
                entireContent = entireContent.Replace("System.DateTime", "DateTime");
           
           
            return entireContent;
        }

        private string AddStandardHeader(string entireContent)
        {
            var scopeStatements = new List<string> { "System", "System.Text", "System.Collections.Generic" };

                // scopeStatements.Add("System.ComponentModel");
                //scopeStatements.Add("System.ComponentModel.DataAnnotations");
                   
           
            var builder = new StringBuilder();
            foreach (var statement in scopeStatements)
            {
                   builder.AppendLine(string.Format("using {0};", statement));
              
               
            }
            builder.Append(entireContent);
            return builder.ToString();
        }

        private static string RemoveComments(string entireContent)
        {
            int end = entireContent.LastIndexOf("----------", StringComparison.Ordinal);
            entireContent = entireContent.Remove(0, end + 10);
            return entireContent;
        }

        private string GetCompleteFilePath(CodeDomProvider provider, string className)
        {
            if (className.ToLowerInvariant() == "con")
                className = className + "Table";
            string fileName = filePath + className;
            return provider.FileExtension[0] == '.'
                       ? fileName + provider.FileExtension
                       : fileName + "." + provider.FileExtension;
        }
        private CodeDomProvider GetCodeDomProvider()
        {
            return  (CodeDomProvider)new CSharpCodeProvider();
        }
    }
}
