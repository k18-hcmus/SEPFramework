using Scriban;
using SEPFramework.source.EntityMeta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.utils.renderers
{
    public class EntityTemplate : ITemplate
    {
        private Template entity;
        private Template field;
        private EntityMetaData data;
        private string namespaceString;
        public EntityTemplate(Template entity, Template field, EntityMetaData data, string namespaceString)
        {
            this.entity = entity;
            this.field = field;
            this.data = data;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string entityData = field.Render(new { namespacestring = this.namespaceString, name = data.mappingTableName, columns = generateEntityColumns(data.columns) });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", entityData);
        }
        private string generateEntityColumns(Dictionary<string, ColumnMetaData> columns)
        {
            StringBuilder body = new StringBuilder();
            foreach (KeyValuePair<string, ColumnMetaData> c in columns)
            {
                string fieldData = field.Render(new { type = c.Value.type, name = c.Value.name });
                body.Append(fieldData);
            }

            return body.ToString();
        }
    }
}
