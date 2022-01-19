using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.SQLSep.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SEPFramework.source.SQLSep.SepORM
{
    public class DataProvider
    {
        private SqlConnection connection;
        private string datasource = "";
        private string username = "";
        private string password = "";
        private string catalog = "";
        public string Catalog { get => catalog; set => catalog = value; }
        private static DataProvider instance;
        private DataProvider(string datasource, string username, string password)
        {
            this.datasource = datasource;
            this.username = username;
            this.password = password;
        }
        public string GetConnectionString()
        {
            string connectionString = "Data Source=\"" + datasource + "\";" +
               "Initial Catalog=" + catalog +
               ";User ID=" + username + ";" +
               "Password=" + password + ";Connect Timeout=30;" +
               "Encrypt=False;TrustServerCertificate=False" +
               ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return connectionString;
        }
        public static DataProvider GetInstance(string datasource = "", string username = "", string password = "")
        {
            if (instance == null && datasource != "")
            {
                instance = new DataProvider(datasource, username, password);
                if (!instance.TestConnectionHealth())
                    instance = null;
            }
            return instance;
        }
        public List<TableMapper> getTables()
        {
            DataTable tables = GetTableList();
            List<TableMapper> entities = new List<TableMapper>();
            foreach (DataRow row in tables.Rows)
            {
                TableMapper entity = new TableMapper();
                entity.name = row[0].ToString();
                entity.mappingTableName = entity.name;
                entity.columns = GetColumns(entity.name);
                entities.Add(entity);
            }
            return entities;
        }
        public Dictionary<string, ColumnMapper> GetColumns(string tableName)
        {
            DataTable fields = GetColumnList(tableName);
            Dictionary<string, ColumnMapper> columns = new Dictionary<string, ColumnMapper>();
            foreach (DataRow row in fields.Rows)
            {
                ColumnMapper column = new ColumnMapper();
                column.mappingColumnName = row[0].ToString();
                column.mappingColumnType = row[1].ToString();
                column.name = column.mappingColumnName;
                column.type = SQLDataTypeMapping.ParseMSSQLDataType(column.mappingColumnType);
                columns.Add(column.name, column);
            }
            return columns;
        }

        public DataTable GetTableList()
        {
            string queryString = "SELECT TABLE_NAME FROM information_schema.tables " +
                "WHERE TABLE_TYPE ='BASE TABLE' order by TABLE_NAME";
            return GetDataTable(queryString);
        }

        public DataTable GetColumnList(string tableName)
        {
            string queryString = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                $"WHERE TABLE_NAME = '{tableName}'";
            return GetDataTable(queryString);
        }

        public DataTable GetDataTable(string queryString)
        {
            DataTable dataTable = new DataTable();
            using (connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, this.connection);
                adapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }

        public DataTable GetCatalogList()
        {
            string sql = "SELECT d.name AS [name] FROM sys.databases AS d " +
                "INNER JOIN sys.master_files AS m ON d.database_id = m.database_id " +
                "WHERE d.state_desc = 'ONLINE' AND m.type_desc = 'ROWS' " +
                "AND m.name not in ('master','tempdev','modeldev','MSDBData') " +
                "ORDER BY m.name;";
            return GetDataTable(sql);
        }

        public bool TestConnectionHealth()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
