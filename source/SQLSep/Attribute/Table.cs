using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : System.Attribute
    {
        private string _name;
        public Table(String name)
        {
            _name = name;
        }

        public static string GetTableName(Type type)
        {
            return ((Table)type.GetCustomAttribute(typeof(Table)))._name;
        }
    }
}
