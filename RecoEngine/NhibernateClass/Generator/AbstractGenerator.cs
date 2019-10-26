using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using NhibernateclassGeneration.Textformatter;

namespace NhibernateclassGeneration
{
    public abstract class AbstractGenerator : IGenerator
    {
        protected Table Table;
        protected string assemblyName;
        protected string filePath;
        protected string nameSpace;
       protected string tableName;
        internal const string TABS = "\t\t\t";
        protected string ClassNamePrefix { get; set; }
        protected ApplicationPreferences applicationPreferences;

        protected AbstractGenerator(string filePath, string tableName, string nameSpace, string assemblyName,  Table table, ApplicationPreferences appPrefs)
        {
            this.filePath = filePath;
        
                if (!this.filePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    this.filePath = this.filePath + Path.DirectorySeparatorChar;
                }
            
            this.tableName = tableName;
            this.nameSpace = nameSpace;
            this.assemblyName = assemblyName;
       
            Table = table;
            Formatter = TextFormatterFactory.GetTextFormatter(appPrefs);
              this.applicationPreferences = appPrefs;
        }

        public ITextFormatter Formatter { get; set; }

        public string GeneratedCode { get; set; }

        public abstract void Generate(bool writeToFile = true);

        protected string WriteToString(CodeCompileUnit compileUnit, CodeDomProvider provider)
        {
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

            return CleanupGeneratedFile(streamWriter.ToString());
        }

        protected abstract string CleanupGeneratedFile(string generatedContent);
    }
}