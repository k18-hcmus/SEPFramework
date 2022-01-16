using Scriban;
using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class BaseFormTemplate : FormTemplate
    {
        public BaseFormTemplate(Template form, Template designer, List<TableMapper> data, string namespaceString) : base(form, designer, data, namespaceString)
        {

        }

        public override string RenderForm()
        {
            Template constructorTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm\\Constructor.txt"));
            StringBuilder contructors = new StringBuilder();
            foreach (TableMapper table in this.data)
            {
                string contructor = constructorTemplate.Render(new { table.name });
                contructors.Append(contructor);
            }
            return this.form.Render(new
            {
                namespacestring = this.namespaceString,
                constructors = contructors.ToString()
            });
        }
    }
}
