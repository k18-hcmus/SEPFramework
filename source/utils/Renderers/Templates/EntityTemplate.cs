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
        private Template field;
        private TableMapper data;
        private string namespaceString;
        public EntityTemplate(Template entity, Template field, TableMapper data, string namespaceString)
        {
            this.entity = entity;
            this.field = field;
            this.data = data;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string entityData = entity.Render(new { namespacestring = this.namespaceString, name = data.mappingTableName, columns = generateEntityColumns(data.columns) });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", entityData);
        }
        private string generateEntityColumns(Dictionary<string, ColumnMapper> columns)
        {
            StringBuilder body = new StringBuilder();
            foreach (KeyValuePair<string, ColumnMapper> c in columns)
            {
                string fieldData = field.Render(new { type = c.Value.type, name = c.Value.name });
                body.Append(fieldData);
            }

            return body.ToString();
        }
    }
}
