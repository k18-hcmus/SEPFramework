using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Entities
{
    public class PrimaryKey
    {
        public List<string> columnNames { get; set; }
        public Dictionary<string, string> references { get; set; } 
    }
}
