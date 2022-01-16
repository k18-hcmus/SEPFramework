using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Entities
{
    public class ColumnMapper
    {
        public string name { get; set; }
        public string type { get; set; }
        public string mappingColumnName { get; set; }
        public string mappingColumnType { get; set; }
    }
}
