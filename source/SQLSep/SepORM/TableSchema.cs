using SEPFramework.source.SQLSep.Attribute;
using SEPFramework.source.SQLSep.SepDataType;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SEPFramework.source.SQLSep.SepORM
{
    public class TableSchema
    {
        private List<string> _sqlKeys;

        public TableSchema()
        {
            _sqlKeys = new List<string>();
        }
        public string GenerateCreateTableSchema(Type classType)
        {
            SchemaByType schemaByType;
            StringBuilder sb = new StringBuilder();
            var props = classType.GetProperties();
            foreach(PropertyInfo prop in props)
            {
                schemaByType = SchemaByType.GetInstance(prop.PropertyType.Name);
                string schemaLine = schemaByType.GenerateSchema(prop);
                sb.AppendFormat("{0},", schemaLine);
                if (Key.validate(prop))
                {
                    _sqlKeys.Add(prop.Name);
                }
            }
         
            if (_sqlKeys.Count > 0)
            {
                sb.AppendFormat("PRIMARY KEY ({0})", string.Join(", ", _sqlKeys));
            }

            var sql = string.Format("create table {0}({1})", classType.Name, sb.ToString());
            return sql;
        }
    }
}