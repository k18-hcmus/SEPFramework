using SEPFramework.source.SQLSep.Attribute;
using System.Collections.Generic;
using System.Reflection;

namespace SEPFramework.source.SQLSep.SepORM
{
    public class TableSchemaFactory
    {
        public TableSchemaFactory()
        {
        }

        public string GenerateTableSchema(PropertyInfo[] props)
        {
            List<string> schemaLines = new List<string>();
            List<string> keys = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                if (Key.validate(prop))
                {
                    lstKey.Add(prop.Name);
                }
            }
            return "";
        }
    }
}