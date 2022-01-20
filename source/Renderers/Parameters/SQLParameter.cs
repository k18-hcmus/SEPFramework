using SEPFramework.source.Utils.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Parameters
{
    public class SQLParameter : BaseParameter
    {
        public enum Type
        {
            SQLServer
        }
        private Type sQLType;
        public Type SQLType { get => sQLType; set => sQLType = value; }
        public SQLParameter(Type sQLType, string namespaceString) : base(namespaceString)
        {
            SQLType = sQLType;
        }
    }
}
