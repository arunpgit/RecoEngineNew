using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhibernateclassGeneration.Domain;

namespace NhibernateclassGeneration
{
    public class Connection
    {
        public Guid Id { get; set; }
        public string ConnectionString { get; set; }
        public string className { get; set; }
        public string Name { get; set; }
        public ServerType Type { get; set; }
        public string EntityName { get; set; }
        public string Domainfolderpath { get; set; }
    }
}