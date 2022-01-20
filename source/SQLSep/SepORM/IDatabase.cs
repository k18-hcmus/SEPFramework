using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepORM
{
    public interface IDatabase
    {
        bool CreateTableNotExist(string TabelName, string queryProps);
        List<T> GetList<T>(string whereConditions = "") where T : class,new();
        T Get<T>(string sql) where T : class, new();
        T GetByID<T>(string ID) where T : class, new();
        bool Insert<T>(T entity) where T : class;
        bool Update<T>(T oldEntity, T newEntity) where T : class;
        bool Delete<T>(T entity) where T :  class;
    }
}
