using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers
{
    public class BaseParameter
    {
        private string namespaceString; 
        public string NamespaceString { get => namespaceString; set => namespaceString = value; }
        public BaseParameter(string namespaceString)
        {
            this.NamespaceString = namespaceString;
        }
    }
}
