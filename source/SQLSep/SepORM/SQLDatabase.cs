using SEPFramework.source.SQLSep.Attribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        private static SQLDatabase instance = null;
        private SQLDatabase(string connectionString)
        {
            var connStringBuilder = new SqlConnectionStringBuilder(connectionString);
            this.DatabaseName = connStringBuilder.InitialCatalog;
            this.ConnectionString = connStringBuilder.ConnectionString;
            this.connection = new SqlConnection(this.ConnectionString);
            this.isClosedConnection = true;
        }
        public static SQLDatabase GetInstance(string connString = "")
        {
            if (instance == null && connString != "")
            {
                instance = new SQLDatabase(connString);
                instance.Open();
            }
            return instance;
        }
        private bool Open()
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
        private bool IsTableExist (string TableName)
        {
            var sql = string.Format("SELECT * FROM INFORMATION_SCHEMA.TABLES Where Table_Schema = 'dbo'  AND Table_Name = '{0}'", TableName);
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            if (reader.HasRows) // exists
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }
        public bool CreateTableNotExist(string TableName,string queryProps)
        {
            if (IsTableExist(TableName))
                return false;
            var sql = string.Format("create table {0}({1})",TableName, queryProps);
            int tableCreated = new SqlCommand(sql, connection).ExecuteNonQuery();
            return tableCreated == 1;
        }

        public bool CreateTableNotExist(Type classType)
        {
            if (IsTableExist(classType.Name))
                return false;
            TableSchema tableSchema = new TableSchema();
            string sql = tableSchema.GenerateCreateTableSchema(classType);
                
            int tableCreated = new SqlCommand(sql, connection).ExecuteNonQuery();
            return tableCreated == 1;
        }
 

        public List<T> GetList<T>(string whereConditions = "") where T : class, new()
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            var sb = new StringBuilder();
            sb.Append("SELECT *");
            sb.AppendFormat(" FROM {0}", tableName);
            if (whereConditions != "") sb.Append(" WHERE " + whereConditions);

            String sql = sb.ToString();
            Trace.WriteLine(sql);

            // Execute Query 
            List<T> records = new List<T>();
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            while (reader.Read())
            {
                T entity = new T();
                foreach (PropertyInfo prop in props)
                {
                    prop.SetValue(entity, reader[prop.Name]);
                }
                records.Add(entity);
            }
            reader.Close();
            return records;
        }
        public T Get<T>(string sql) where T : class, new()
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            // Execute Query 
            T model = new T();
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            if (reader.Read())
            {
                foreach (PropertyInfo prop in props)
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                reader.Close();
                return model;
            }
            reader.Close();
            return null;
        }
        public T GetByID<T>(string ID) where T : class, new()
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            if(props.Length <= 0)
                throw new ArgumentException("GetByID<T> only supports an entity with a PrimaryKey or Id property");

            var sb = new StringBuilder();
            sb.Append("SELECT *");
            sb.AppendFormat(" FROM {0} WHERE ", tableName);
            sb.AppendFormat("{0} = {1}", props[0].Name, QuotedName(ID));
            string sql = sb.ToString();
            Trace.WriteLine(sql);

            // Execute Query 
            T model = new T();
            SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
            if (reader.Read())
            {
                foreach (PropertyInfo prop in props)
                {
                    prop.SetValue(model, reader[prop.Name]);
                }
                reader.Close();
                return model;
            }
            reader.Close();
            return null;
        }

        public bool Insert<T>(T entity) where T : class
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            string fields = "", values = "";
            foreach (PropertyInfo prop in props)
            {
                fields += prop.Name + ",";
                values += QuotedName(prop.GetValue(entity).ToString()) + ",";
            }
            values = values.Remove(values.Length - 1, 1);
            fields = fields.Remove(fields.Length - 1, 1);

            var sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO {0}", tableName);
            sb.AppendFormat(" ({0}) ", fields);
            sb.AppendFormat("VALUES ({0})", values);
            string sql = sb.ToString(); 
            Trace.WriteLine(sql);

            // Execute Query 
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
            return afftectedRow == 1;
        }

        public bool Update<T>(T oldEntity, T newEntity) where T : class
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            string fieldsUpdate = "";
            foreach (PropertyInfo prop in props)
            {
                if (typeof(T).GetProperties()[0] == prop) continue;
                fieldsUpdate += prop.Name + " = " + QuotedName(prop.GetValue(newEntity).ToString()) + ",";
            }
            fieldsUpdate = fieldsUpdate.Remove(fieldsUpdate.Length - 1, 1);

            string keyName = props[0].GetValue(oldEntity).ToString();

            var sb = new StringBuilder();
            sb.AppendFormat("UPDATE {0} ", tableName);
            sb.AppendFormat("SET {0} ", fieldsUpdate);
            sb.AppendFormat("WHERE {0} = {1}", props[0].Name, QuotedName(keyName));
            string sql = sb.ToString();
            Trace.WriteLine(sql);

            // Execute Query 
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
            return afftectedRow == 1;
        }

        public bool Delete<T>(T entity) where T : class
        {
            // Build Query
            var tableName = typeof(T).Name;
            var props = typeof(T).GetProperties();

            string keyName = props[0].GetValue(entity).ToString();

            var sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM {0} ", tableName);
            sb.AppendFormat("WHERE {0} = {1}", props[0].Name, QuotedName(keyName));
            string sql = sb.ToString();
            Trace.WriteLine(sql);

            // Execute Query 
            int afftectedRow = new SqlCommand(sql, connection).ExecuteNonQuery();
            return afftectedRow == 1;
        }
        
        public string QuotedName(string str)
        {
            return String.Format("'{0}'", str);
        }
 
    }
}
