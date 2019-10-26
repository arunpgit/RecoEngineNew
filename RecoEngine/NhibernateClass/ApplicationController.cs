using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhibernateclassGeneration;

namespace NhibernateclassGeneration
{
    public class ApplicationController
    {
        private readonly ApplicationPreferences applicationPreferences;
        private readonly CodeGenerator codeGenerator;
       
        public ApplicationController(ApplicationPreferences applicationPreferences, Table table)
        {
            this.applicationPreferences = applicationPreferences;
            codeGenerator = new CodeGenerator(applicationPreferences, table);
        }

        public string GeneratedDomainCode { get; set; }
  
        public void Generate(bool writeToFile = true)
        {
            codeGenerator.Generate(writeToFile);
            GeneratedDomainCode = codeGenerator.GeneratedCode;
        }
    }
}