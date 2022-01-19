using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.Utils.IoCContainer
{
    public class IoCImpl : IIoC
    {
        Dictionary<Type, Type> registeredDict =
            new Dictionary<Type, Type>();

        Dictionary<Type, object> instances =
            new Dictionary<Type, object>();

        public bool IsRegistered<Type>()
        {
            return registeredDict.Any(a => a.Key == typeof(Type));
        }

        public T Resolve<T>() where T : class
        {
            try
            {
                T obj = (T)ResolveType(typeof(T));
                if (!instances.ContainsKey(typeof(T)))
                    instances.Add(typeof(T), obj);
                return obj;
            }
            catch(Exception exp)
            {
                MessageBox.Show("Resolve entity failed err=" + exp.Message);
            }
            return null;
        }

        public void RegisterType<T>(InjectionConstructor constructor = null) where T : class
        {
            try
            {
                T obj = (T)ResolveType(typeof(T), constructor);
                if (!instances.ContainsKey(typeof(T)))
                    instances.Add(typeof(T), obj);
                if (!registeredDict.ContainsKey(typeof(T)))
                    registeredDict.Add(typeof(T), typeof(T));
            }
            catch (Exception exp)
            {
                MessageBox.Show("Register entity failed err=" + exp.Message);
            }
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            try
            {
                Type TFromType = typeof(TFrom);
                Type TToType = typeof(TTo);
                if (registeredDict.ContainsKey(TFromType))
                    registeredDict[TFromType] = TToType;
                else
                    registeredDict.Add(TFromType, TToType);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Register entity failed err=" + exp.Message);
            }
        }

        private object ResolveType(Type type, InjectionConstructor constructParam = null)
        {
            try
            {
                if (instances.ContainsKey(type))
                {
                    return instances.First(f => f.Key == type).Value;
                }
                else if (constructParam != null)
                    return CreateObjectWithParameter(type, constructParam.ParamList);
                else
                    return CreateDefaultObject(type);
            }
            catch (Exception)
            {
                throw new Exception("Cannot resolve " + type.FullName);
            }
        }

        private object CreateDefaultObject(Type type)
        {
            ConstructorInfo constructor = type.GetConstructors().First();
            List<ParameterInfo> constructorParams = constructor.GetParameters().Where(w => w.GetType().IsClass).ToList();

            if (!constructorParams.Any())
                return Activator.CreateInstance(type);

            List<object> paramList = new List<object>();

            foreach (ParameterInfo paramInfo in constructorParams)
            {
                object resolvedType = ResolveType(paramInfo.ParameterType);
                paramList.Add(resolvedType);
            }
            return constructor.Invoke(paramList.ToArray());
        }

        private object CreateObjectWithParameter(Type type, List<object> parameters)
        {
            ConstructorInfo constructor = type.GetConstructors().First();
            List<ParameterInfo> constructorParams = constructor.GetParameters().Where(w => w.GetType().IsClass).ToList();

            if (!constructorParams.Any())
                return Activator.CreateInstance(type);

            List<object> paramList = new List<object>();

            foreach (object param in parameters)
            {
                if (param.GetType() == typeof(InjectionConstructor))
                {
                    InjectionConstructor con = (InjectionConstructor)param;
                    object resolvedType = CreateObjectWithParameter(con.Type, con.ParamList);
                    paramList.Add(resolvedType);
                }
                else
                {
                    paramList.Add(param);
                }
            }

            return constructor.Invoke(paramList.ToArray());
        }
    }
}
