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
            return this.form.Render(new
            {
                namespacestring = this.namespaceString,
                entitynames = this.data.Select(table => table.name)
            });
        }
    }
}
