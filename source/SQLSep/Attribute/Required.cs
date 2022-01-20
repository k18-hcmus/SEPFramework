using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]

    public class Required : EntityAttribute
    {
        private bool _isRequired { get; set; }

        public Required()
        {
            _isRequired = true;
            ErrorMessage = "This property is required";
        }

        public static bool validate(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Required)) != null && ((Required)prop.GetCustomAttribute(typeof(Required)))._isRequired;
        }
    }
}
