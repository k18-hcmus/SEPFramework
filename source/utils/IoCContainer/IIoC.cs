using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.IoCContainer
{
    public interface IIoC
    {
        T Resolve<T>() where T : class;
        bool IsRegistered<Type>();
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterType<T>(InjectionConstructor constructor = null) where T : class;
    }
}
