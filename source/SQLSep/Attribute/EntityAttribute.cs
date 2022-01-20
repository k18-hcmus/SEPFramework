using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]

    public class EntityAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }

        public EntityAttribute()
        {
            ErrorMessage = "";
        }
    }
}
