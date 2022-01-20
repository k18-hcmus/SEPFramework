using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.SQLSep.Attribute;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public class SQLType : DataType
    {
        public string GenCreateQuery(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(Int32) || prop.PropertyType == typeof(Int32?))
            {
                var query = prop.Name + " INT";

                //Check require attribute
                if (Key.check(prop))
                {
                    query += " IDENTITY";
                }

                //Check require attribute
                if (prop.PropertyType == typeof(Int32) || Required.check(prop))
                {
                    query += " NOT NULL";
                }

                return query;
            }

            return "";
        }

        public string GenSQLValue(object value)
        {
            throw new NotImplementedException();
        }
    }
}
