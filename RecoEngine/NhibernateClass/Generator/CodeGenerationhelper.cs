using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;

namespace NhibernateclassGeneration
{
    public class CodeGenerationHelper 
    {
        public CodeCompileUnit GetCodeCompileUnit(string nameSpace, string className)
        {
            var codeCompileUnit = new CodeCompileUnit();
            var codeNamespace = new CodeNamespace(nameSpace);
            var codeTypeDeclaration = new CodeTypeDeclaration(className);


            codeNamespace.Types.Add(codeTypeDeclaration);
            codeCompileUnit.Namespaces.Add(codeNamespace);
            return codeCompileUnit;
        }

        public CodeCompileUnit GetCodeCompileUnitWithInheritanceAndInterface(string nameSpace, string className, string inheritanceAndInterface)
        {
            var codeCompileUnit = GetCodeCompileUnit(nameSpace, className);
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


        public CodeMemberProperty CreateAutoProperty(Type type, string propertyName, bool fieldIsNull, bool useLazy = true)
        {
            bool setFieldAsNullable = fieldIsNull && IsNullable(type);
            if (setFieldAsNullable)
                type = typeof(Nullable<>).MakeGenericType(type);
            var codeMemberProperty = new CodeMemberProperty
                                         {
                                             Name = propertyName,
                                             HasGet = true,
                                             HasSet = true,
                                             Attributes = MemberAttributes.Public,
                                             Type = new CodeTypeReference(type)
                                         };
            if (!useLazy)
                codeMemberProperty.Attributes = codeMemberProperty.Attributes | MemberAttributes.Final;
            return codeMemberProperty;
        }

        public CodeMemberProperty CreateAutoProperty(string typeName, string propertyName, bool useLazy = true)
        {
            var codeMemberProperty = new CodeMemberProperty
                                         {
                                             Name = propertyName,
                                             HasGet = true,
                                             HasSet = true,
                                             Attributes = MemberAttributes.Public,
                                             Type = new CodeTypeReference(typeName)
                                         };
            if (!useLazy)
                codeMemberProperty.Attributes = codeMemberProperty.Attributes | MemberAttributes.Final;
            return codeMemberProperty;
        }

        private static bool IsNullable(Type type)
        {
            return type.IsValueType ||
                   (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public CodeMemberProperty CreateAutoPropertyWithDataMemberAttribute(string type, string propertyName)
        {
            var attributes = new CodeAttributeDeclarationCollection { new CodeAttributeDeclaration("DataMember") };
            var codeMemberProperty = new CodeMemberProperty
            {
                Name = propertyName,
                HasGet = true,
                HasSet = true,
                CustomAttributes = attributes,
                Attributes = MemberAttributes.Public,
                Type = new CodeTypeReference(type)
            };
            return codeMemberProperty;
        }

        public string InstatiationObject(string foreignEntityCollectionType)
        {
            if (foreignEntityCollectionType.Contains("List"))
                return "List";
            if (foreignEntityCollectionType.Contains("Set"))
                return "HashedSet";
            if (foreignEntityCollectionType.Contains("Collection"))
                return "List";
            return foreignEntityCollectionType;
        }
       
    }
}