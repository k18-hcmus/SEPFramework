using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Column : EntityAttribute
    {
        private string _name;

        public Column(String name)
        {
            this._name = name;
        }

        public static string getName(PropertyInfo prop)
        {
            return ((Column)prop.GetCustomAttribute(typeof(Column)))._name;
        }

    }
}
