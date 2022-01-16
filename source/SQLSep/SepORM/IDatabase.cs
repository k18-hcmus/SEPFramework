using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepORM
{
    public interface IDatabase
    {
        bool Open();
        bool Close();
        void CreateTableIfNotExist();

        void GetAll<T>() where T : class;

        T Get<T>(string ID) where T : class, new();
        bool Create<T>(T entity) where T : class;

        bool Update<T>(T oldEntity, T newEntity) where T : class;
        void Delete<T>(T entity) where T :  class;
    }
}
