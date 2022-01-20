using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{

    [AttributeUsage(AttributeTargets.Property)]
    public class StringLength : EntityAttribute
    {
        private int _maximumLength = 0;

        public StringLength()
        {
            _maximumLength = 1024;
            ErrorMessage = "This property must be a string with a maximum length of " + _maximumLength;
        }

        public StringLength(int maxLength)
        {
            _maximumLength = maxLength;
            ErrorMessage = "This property must be a string with a maximum length of " + _maximumLength;
        }

        public static int GetMaximumLength(PropertyInfo prop)
        {
            return ((StringLength)prop.GetCustomAttribute(typeof(StringLength)))._maximumLength;
        }
    }
}
