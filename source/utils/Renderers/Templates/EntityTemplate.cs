using Scriban;
using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class EntityTemplate : ITemplate
    {
        private Template entity;
        private TableMapper data;
        private string namespaceString;
        public EntityTemplate(Template entity, TableMapper data, string namespaceString)
        {
            this.entity = entity;
            this.data = data;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string paramList = "";
            foreach (KeyValuePair<string, ColumnMapper> c in data.columns)
            {
                paramList += c.Value.type + " " + c.Value.name + ", ";
            }
            paramList = paramList.Substring(0, paramList.Length - 2);
            string[] paramArray = data.columns.Select(column => column.Value.name).ToArray();
            string entityData = entity.Render(new { namespacestring = this.namespaceString,
                name = data.mappingTableName,
                columns = GenerateEntityColumns(data.columns),
                paramlist = paramList,
                parameters = paramArray,
                datarowconstructbody = GetDatarowConstructBody(data.columns)
            });
            FileUtils.CreateFile(path + "\\" + filename + ".cs", entityData);
        }
        private string GenerateEntityColumns(Dictionary<string, ColumnMapper> columns)
        {
            Template bodyTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\Entity\\FieldTemplate.txt"));
            return ConstructBody(columns, bodyTemplate);
        }
        private string GetDatarowConstructBody(Dictionary<string, ColumnMapper> columns)
        {
            Template bodyTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\Entity\\DataRowConstructBody.txt"));
            return ConstructBody(columns, bodyTemplate);
        }
        private string ConstructBody(Dictionary<string, ColumnMapper> columns, Template template)
        {
            StringBuilder body = new StringBuilder();
            foreach (KeyValuePair<string, ColumnMapper> c in columns)
            {
                string fieldData = template.Render(new { type = c.Value.type, name = c.Value.name });
                body.Append(fieldData);
            }

            return body.ToString();
        }
    }
}
