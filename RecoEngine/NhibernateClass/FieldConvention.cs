using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhibernateclassGeneration
{
    public enum FieldNamingConvention
    {
        SameAsDatabase,
        CamelCase,
        Prefixed,
        PascalCase
    }

    public enum FieldGenerationConvention
    {
        Field,
        Property,
        AutoProperty
    }
   
  
   
}