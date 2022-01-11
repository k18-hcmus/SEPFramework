using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.utils.renderers
{
    public class FormTemplate : FileTemplate
    {
        private Template designer;
        private string namespaceString;
        public FormTemplate(Template form, Template designer, string namespaceString) : base(form)
        {
            this.designer = designer;
            this.namespaceString = namespaceString;
        }
        public override void Render(string path, string filename)
        {
            string formData = this.template.Render(new { namespacestring = this.namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", formData);
            string designerData = this.designer.Render(new { namespacestring = this.namespaceString });
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".Designer.cs", designerData);
        }
    }
}
