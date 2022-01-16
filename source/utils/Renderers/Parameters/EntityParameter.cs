using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Parameters
{
    public class EntityParameter : BaseParameter
    {
        private TableMapper data;
        public TableMapper Data { get => data; set => data = value; }
        public EntityParameter(TableMapper data, string namespaceString) : base(namespaceString)
        {
            Data = data;
        }
    }
}
