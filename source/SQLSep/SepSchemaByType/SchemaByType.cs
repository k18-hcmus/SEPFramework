using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public class SchemaByType
    {
        private static Dictionary<string, SchemaByType> schemaByTypes;

        static SchemaByType()
        {
            schemaByTypes = new Dictionary<string, SchemaByType>();
            schemaByTypes.Add("bool", new SchemaByBool());
            schemaByTypes.Add("int", new SchemaByInt());
            schemaByTypes.Add("datetime", new SchemaByDateTime());
            schemaByTypes.Add("double", new SchemaByDouble());
            schemaByTypes.Add("float", new SchemaByDouble());
            schemaByTypes.Add("string", new SchemaByString());
        }
        public static SchemaByType GetInstance(string typeName)
        {
            return schemaByTypes[typeName];
        }

        public virtual string GenerateSchema(PropertyInfo prop)
        {
            return "";
        }
    }
}
