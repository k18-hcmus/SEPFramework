using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Engines
{
    public class EntityTemplateEngine
    {
        // Singleton to create only one 
        private static EntityTemplateEngine instance = null;
        public static EntityTemplateEngine Instance
        {
            get { 
                if (instance == null) instance = new EntityTemplateEngine();
                return instance;
            }
        }

        private readonly string entityTemplateFile = @"..\..\source\Templates\EntityTemplate.txt";

        public void generateEntityFile(TableMapper entity)
        {
            string templateContent = File.ReadAllText(entityTemplateFile);
            StringBuilder temp = new StringBuilder(templateContent);

            temp = temp.Replace("{{ namespacestring }}", "source.Poco");
            temp = temp.Replace("{{ name }}", entity.mappingTableName);
            temp = temp.Replace("{{ columns }}", generateEntityColumns(entity.columns));

            exportFile(entity.name, temp.ToString());
            Console.WriteLine(entity.name + ".cs generated");
        }

        private string generateEntityColumns(Dictionary<string, ColumnMapper> columns)
        {
            StringBuilder body = new StringBuilder();
            foreach (KeyValuePair<string, ColumnMapper> c in columns)
            {
                string fieldTemplate = "\tpublic {{ type }} {{ fieldname }} {get; set;}\n";
                fieldTemplate = fieldTemplate.Replace("{{ type }}", c.Value.type);
                fieldTemplate = fieldTemplate.Replace("{{ fieldname }}", c.Value.name);
                body.Append(fieldTemplate);
            }

            return body.ToString();
        }

        private void exportFile(string mappingTableName, string fileBody)
        {
            string path = @"../../source/Poco/" + mappingTableName + ".cs";
            File.WriteAllText(path, fileBody, Encoding.UTF8);
        }
    }
}
