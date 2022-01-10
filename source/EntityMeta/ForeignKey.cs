using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.EntityMeta
{
    internal class ForeignKey
    {
        public string columnName { get; set; }
        public KeyValuePair<string, string> referTable { get; set; } 
    }
}
