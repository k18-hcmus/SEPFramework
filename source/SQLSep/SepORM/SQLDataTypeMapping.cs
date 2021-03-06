using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepORM
{
    public class SQLDataTypeMapping
    {
        public static string ParseMSSQLDataType(string SQLDataType)
        {
            switch (SQLDataType)
            {
                //Numeric
                case "tinyint":
                    return "Byte";
                case "real":
                    return "Single";
                case "int":
                    return "Int32";
                case "smallint":
                    return "Int16";
                case "bigint":
                    return "Int64";
                case "float":
                    return "Double";
                case "decimal":
                case "numeric":
                case "smallmoney":
                case "money":
                    return "Decimal";
                case "binary":
                    return "Byte[]";
                case "bit":
                    return "Boolean";
                //DateTime
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    return "DateTime";
                case "datetimeoffset":
                    return "DateTimeOffset";
                //Byte[]
                case "varbinary":
                case "rowversion":
                case "timestamp":
                    return "DateTime";
                //Various
                case "time":
                    return "TimeSpan";
                case "uniqueidentifier":
                    return "Guid";
                case "xml":
                    return "Xml";
                // String
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                    return "string";
                default:
                    throw new Exception(String.Format("unable to convert SQL datatype \"{0}\" to C#", SQLDataType));
            }

        }
    }
}
