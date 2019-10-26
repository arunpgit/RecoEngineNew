using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhibernateclassGeneration.Domain;

namespace NhibernateclassGeneration
{
    public class ApplicationPreferences
    {
        public ApplicationPreferences()
        {
            FieldNamingConvention = FieldNamingConvention.SameAsDatabase;
            FieldGenerationConvention = FieldGenerationConvention.AutoProperty;
            Language=  Language.CSharp;
            Prefix = string.Empty;
        }
        public string TableName { get; set; }

        public string FolderPath { get; set; }

        public string DomainFolderPath { get; set; }

        public string NameSpace { get; set; }

        public string NameSpaceMap { get; set; }

        public string AssemblyName { get; set; }

        public ServerType servertype{ get; set; }

        public string ConnectionString { get; set; }
               
        public string Prefix { get; set; }

        public string ForeignEntityCollectionType { get; set; }

        public string InheritenceAndInterfaces { get; set; }

        public string ClassNamePrefix { get; set; }

        public bool EnableInflections { get; set; }

        public string EntityName { get; set; }
    
        public bool UseLazy { get; set; }

        public bool IncludeForeignKeys { get; set; }

        public bool NameFkAsForeignTable { get; set; }

        public bool IncludeHasMany { get; set; }

        public bool IncludeLengthAndScale { get; set; }
        public ServerType ServerType { get; set; }
        public List<string> FieldPrefixRemovalList { get; set; }
        public FieldGenerationConvention FieldGenerationConvention { get; set; }
        public FieldNamingConvention FieldNamingConvention { get; set; }
        public Language Language { get; set; }
             
    }
}