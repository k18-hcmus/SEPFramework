using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.IoCContainer
{
    public class InjectionConstructor : Object
    {
        private Type type;
        private List<object> paramList = new List<object>();
        public InjectionConstructor()
        {
        }
        public InjectionConstructor(Type type)
        {
            this.Type = type;
        }

        public Type Type { get => type; set => type = value; }
        public List<object> ParamList { get => paramList; set => paramList = value; }
        public InjectionConstructor AddParameter<T>(T newParam)
        {
            ParamList.Add(newParam);
            return this;
        }
    }
}
