using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.SQLSep.Attribute;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public class SchemaByString : ISchemaByType
    {
        public string GenerateSchema(PropertyInfo prop)
        {
            if (prop.PropertyType != typeof(String))
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} VARCHAR({1})", prop.Name, StringLength.GetMaximumLength(prop));
            if (Required.validate(prop))
                sb.Append(" NOT NULL");

            return sb.ToString();
        }
    }
}
