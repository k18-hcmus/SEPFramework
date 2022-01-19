using Scriban;
using SEPFramework.source.SQLSep.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Templates
{
    public class HomeFormTemplate : FormTemplate
    {
        private string connectionString;
        public HomeFormTemplate(string connectionString, Template form, Template designer, List<TableMapper> data, string namespaceString) : base(form, designer, data, namespaceString)
        {
            this.connectionString = connectionString;
        }

        public override string RenderForm()
        {
            return this.form.Render(new
            {
                namespacestring = this.namespaceString,
                entitynames = this.data.Select(table => table.name),
                connectionstring = connectionString
            });
        }
    }
}
