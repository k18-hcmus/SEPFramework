using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class FormTemplate : ITemplate
    {
        private Template form;
        private Template designer;
        private string namespaceString;
        public FormTemplate(Template form, Template designer, string namespaceString)
        {
            this.form = form;
            this.designer = designer;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string formData = form.Render(new { namespacestring = namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", formData);
            string designerData = this.designer.Render(new { namespacestring = this.namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".Designer.cs", designerData);
        }
    }
}
