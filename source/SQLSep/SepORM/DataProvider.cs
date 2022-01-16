using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.SQLSep.Entities;
using System.Data.SqlClient;
using System.Data;


namespace SEPFramework.source.SQLSep.SepORM
{
    public class DataProvider
    {
        private SqlConnection connection;
        private string connString = "";
        public DataProvider(string connString)
        {
            this.connString = connString;
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
            using (connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, this.connection);
                adapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }
    }
}
