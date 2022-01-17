using Scriban;
using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class FormTemplate : ITemplate
    {
        protected Template form;
        protected Template designer;
        protected List<TableMapper> data;
        protected string namespaceString;
        public FormTemplate(Template form, Template designer, List<TableMapper> data, string namespaceString)
        {
            this.form = form;
            this.designer = designer;
            this.data = data;
            this.namespaceString = namespaceString;
        }
        public void Render(string path, string filename)
        {
            string formData = RenderForm();
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".cs", formData);
            string designerData = RenderDesigner();
            FileUtils.GetInstance().CreateFile(path + "\\" + filename + ".Designer.cs", designerData);
        }
        public virtual string RenderForm()
        {
            return form.Render(new { namespacestring = namespaceString });
        }
        public virtual string RenderDesigner()
        {
            return designer.Render(new { namespacestring = this.namespaceString });
        }
    }
}
