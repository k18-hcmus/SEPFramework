using SEPFramework.source.SQLSep.Attribute;
using System;
using System.Reflection;
using System.Text;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public class SchemaByDouble : ISchemaByType
    {
        public string GenerateSchema(PropertyInfo prop)
        {
            if (prop.PropertyType != typeof(Double) && prop.PropertyType != typeof(float))
                return "";

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} FLOAT", prop.Name);
            if (Required.validate(prop))
                sb.Append(" NOT NULL");

            return sb.ToString();
        }
    }


}
