using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.EntityMeta;
using System.Data.SqlClient;
using System.Data;


namespace SEPFramework.source.Engines
{
    internal class DataProvider
    {
        // Singleton
        private static DataProvider instance = null;
        public string ConnString { get; set; }
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
        }
        public List<EntityMetaData> getTables()
        {
            DataTable tables = GetTableList();
            List<EntityMetaData> entities = new List<EntityMetaData>();
            foreach (DataRow row in tables.Rows)
            {
                EntityMetaData entity = new EntityMetaData();
                entity.name = row[0].ToString();
                entity.mappingTableName = entity.name;
                entity.columns = GetColumns(entity.name);
                entities.Add(entity);
            }
            return entities;
        }
        public Dictionary<string, ColumnMetaData> GetColumns(string tableName)
        {
            DataTable fields = GetColumnList(tableName);
            Dictionary<string, ColumnMetaData> columns = new Dictionary<string, ColumnMetaData>();
            foreach (DataRow row in fields.Rows)
            {
                ColumnMetaData column = new ColumnMetaData();
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
            string queryString = "SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_TYPE ='BASE TABLE' order by TABLE_NAME";
            return GetDataTable(queryString);
        }

        public DataTable GetColumnList(string tableName)
        {
            string queryString = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";
            return GetDataTable(queryString);
        }

        public DataTable GetDataTable(string queryString)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.ConnString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                adapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }
    }
}
