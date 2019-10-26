using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhibernateclassGeneration
{
    public interface IGenerator
    {
        void Generate(bool writeToFile = true);
    }
}
