using SEPFramework.source.EntityMeta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Engines
{
    internal class EntityTemplateEngine
    {
        // Singleton to create only one 
        private static EntityTemplateEngine instance = null;
        private static int templateCount;
        public static EntityTemplateEngine Instance
        {
            get { 
                if (instance == null) instance = new EntityTemplateEngine();
                return instance;
            }
        }

        string entityTemplateFile = @"..\..\source\template\EntityTemplate.txt";

        public void generateEntityFile(EntityMetaData entity)
        {
            string templateContent = File.ReadAllText(entityTemplateFile);
            StringBuilder temp = new StringBuilder(templateContent);

            temp = temp.Replace("##namespace", "MyNamespace"+ templateCount);
            temp = temp.Replace("##entityName", entity.mappingTableName);
            temp = temp.Replace("##entityColumns", generateEntityColumns(entity.columns));

            exportFile(entity.name, temp.ToString());
            Console.WriteLine(entity.name + ".cs generated");
        }
     

        private string generateEntityColumns(Dictionary<string, ColumnMetaData> columns)
        {
            StringBuilder body = new StringBuilder();
            foreach (KeyValuePair<string, ColumnMetaData> c in columns)
            {
                string fieldTemplate = "\tpublic ##type ##name {get; set;}\n";
                fieldTemplate = fieldTemplate.Replace("##type", c.Value.type);
                fieldTemplate = fieldTemplate.Replace("##name", c.Value.name);
                body.Append(fieldTemplate);
            }

            return body.ToString();
        }

        private void exportFile(string mappingTableName, string fileBody)
        {
            string path = @"../../source/ORMEntities/" + mappingTableName + ".cs";
            File.WriteAllText(path, fileBody, Encoding.UTF8);
        }
    }
}
