using Scriban;
using SEPFramework.source.Utils.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.renderers.Templates
{
    public class SQLTemplate : ITemplate
    {
        private string namespaceString;
        private Template template;
        public SQLTemplate(Template template, string namespaceString)
        {
            this.template = template;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string designerData = template.Render(new { namespacestring = this.namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", designerData);
        }
    }
}
