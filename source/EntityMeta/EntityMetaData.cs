using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.EntityMeta
{
    internal class EntityMetaData
    {
        public string name { get; set; }
        public string mappingTableName { get; set; }
        public Dictionary<string, ColumnMetaData> columns { get; set; }
        public PrimaryKey primaryKey { get; set; }
        public List<ForeignKey> foreignKeys { get; set; }
    }
}
