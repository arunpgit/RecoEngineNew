using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NhibernateclassGeneration.Reader;
using NhibernateclassGeneration.Domain;

namespace NhibernateclassGeneration
{
    public class MetadataFactory
    {
        public static IMetadataReader GetReader(ServerType serverType, string connectionStr)
        {

            switch (serverType)
            {
                case ServerType.Oracle:
                    return new OracleMetadataReader(connectionStr);
                case ServerType.SqlServer:
                    return new SqlServerMetadataReader(connectionStr);
                 default:
                    return new SqlServerMetadataReader(connectionStr);
            }
               
            }
        }
    }
