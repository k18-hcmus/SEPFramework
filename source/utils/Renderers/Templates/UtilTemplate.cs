using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class UtilTemplate : ITemplate
    {
        private string namespaceString;
        private Template template;
        public UtilTemplate(Template template, string namespaceString)
        {
            this.template = template;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string designerData = template.Render(new { namespacestring = this.namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".Designer.cs", designerData);
        }
    }
}
