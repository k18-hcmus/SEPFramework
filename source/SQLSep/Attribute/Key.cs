using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Key : EntityAttribute
    {
        private bool _isKey;

        public Key()
        {
            _isKey = true;
            ErrorMessage = "This property must be a primary key";
        }

        public static bool validate(PropertyInfo prop)
        {
            return prop.GetCustomAttribute(typeof(Key)) != null && ((Key)prop.GetCustomAttribute(typeof(Key)))._isKey;
        }
    }
}

