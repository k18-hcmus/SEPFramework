 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.Entities
{
    public class TableMapper
    {
        public string name { get; set; }
        public string mappingTableName { get; set; }
        public Dictionary<string, ColumnMapper> columns { get; set; }
        public PrimaryKey primaryKey { get; set; }
        public List<ForeignKey> foreignKeys { get; set; }
        public TableMapper() { }
    }
}
