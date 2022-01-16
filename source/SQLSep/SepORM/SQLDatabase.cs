using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace SEPFramework.source.SQLSep.SepORM
{
    public class SQLDatabase : IDatabase
    {
        private SqlConnection connection;
        private bool isClosedConnection;
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseType { get; set; }

        public SQLDatabase(string connectionString)
        {
            var connStringBuilder = new SqlConnectionStringBuilder(connectionString);
            this.DatabaseName = connStringBuilder.InitialCatalog;
            this.ConnectionString = connStringBuilder.ConnectionString;
            this.connection = new SqlConnection(this.ConnectionString);
            this.isClosedConnection = true;
        }

        public bool Open()
        {
            if (this.connection == null) return false;
            connection.ConnectionString = this.ConnectionString;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
                this.isClosedConnection = false;
                return true;
            }
            return false;
        }

        public bool Close()
        {
            throw new NotImplementedException();
        }
        public void CreateTableIfNotExist()
        {
            throw new NotImplementedException();
        }
        public List<T> GetAll<T>() where T : class, new()
        {
            List<T> records = new List<T>();
            String sql = "SELECT * FROM " + typeof(T).Name;
            Console.WriteLine(sql);
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            while (reader.Read())
            {
                T entity = new T();
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(entity, reader[prop.Name]);
                }
                records.Add(entity);
            }
            reader.Close();
            return records;
        }

        public T Get<T>(string ID) where T : class, new()
        {
            T model = new T();
            String sql = "SELECT * FROM " + typeof(T).Name + " WHERE " + typeof(T).GetProperties()[0].Name
                + " = " + QuotedName(ID);

            Console.WriteLine(sql);
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            if (reader.Read())
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                reader.Close();
                return model;
            }
            reader.Close();
            return null;
        }

        public bool Create<T>(T entity) where T : class
        {
            String fields = "", values = "";
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                fields += prop.Name + ",";
                values += QuotedName(prop.GetValue(entity).ToString()) + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            fields = fields.Remove(fields.Length - 1, 1);
            string sql = "INSERT INTO " + typeof(T).Name + "(" + fields + ") VALUES (" + values + ")";
            Console.WriteLine(sql);
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
<<<<<<< HEAD

=======
>>>>>>> main
            return afftectedRow == 1;
        }

        public bool Update<T>(T oldEntity, T newEntity) where T : class
        {
            String fieldsUpdate = "";
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (typeof(T).GetProperties()[0] == prop) continue;
                fieldsUpdate += prop.Name + " = " + QuotedName(prop.GetValue(newEntity).ToString()) + ",";
            }
            fieldsUpdate = fieldsUpdate.Remove(fieldsUpdate.Length - 1, 1);

            string ID = typeof(T).GetProperties()[0].GetValue(oldEntity).ToString();

            String sql = "UPDATE " + typeof(T).Name + " SET " + fieldsUpdate + " WHERE " 
                + typeof(T).GetProperties()[0].Name + " = " + QuotedName(ID);

            Console.WriteLine(sql);
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
            return afftectedRow == 1;
        }

        public bool Delete<T>(T entity) where T : class
        {
            string keyName = typeof(T).GetProperties()[0].GetValue(entity).ToString();

            String sql = "DELETE FROM " + typeof(T).Name + " WHERE "
                + typeof(T).GetProperties()[0].Name + " = " + QuotedName(keyName);

            Console.WriteLine(sql);
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
            return afftectedRow == 1;
        }
        
        public string QuotedName(string str)
        {
            return String.Format("'{0}'", str);
        }

    }
}
