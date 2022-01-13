using SEPFramework.source.EntityMeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Parameters
{
    public class EntityParameter : BaseParameter
    {
        private EntityMetaData data;
        public EntityMetaData Data { get => data; set => data = value; }
        public EntityParameter(EntityMetaData data, string namespaceString) : base(namespaceString)
        {
            Data = data;
        }
    }
}
