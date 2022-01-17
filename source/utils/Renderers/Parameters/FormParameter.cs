using Scriban;
using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Parameters
{
    public class FormParameter : BaseParameter
    {
        public enum Type
        {
            BaseForm,
            ActionForm,
            AddForm,
            EditForm,
            HomeForm
        }
        private Type formType;
        public Type FormType { get => formType; set => formType = value; }
        private List<TableMapper> data;
        public List<TableMapper> Data { get => data; set => data = value; }
        private string connectionString;
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public FormParameter(string connectionString, Type formType, string namespaceString, List<TableMapper> data) : base(namespaceString)
        {
            string tmp = connectionString.Replace("\"", "\\\"");
            ConnectionString = tmp;
            FormType = formType;
            Data = data;
        }
        public FormParameter(Type formType, string namespaceString, List<TableMapper> data) : base(namespaceString)
        {
            FormType = formType;
            Data = data;
        }
        public FormParameter(Type formType, string namespaceString) : base(namespaceString)
        {
            FormType = formType;
        }
    }
}
