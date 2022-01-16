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
        public HomeFormTemplate(Template form, Template designer, List<TableMapper> data, string namespaceString) : base(form, designer, data, namespaceString)
        {

        }

        public override string RenderForm()
        {
            Template listEntityTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\ListEntity.txt"));
            Template openFormButtonTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\OpenFormButton.txt"));
            Template openFormCaseTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\OpenFormCase.txt"));
            StringBuilder listEntity = new StringBuilder();
            StringBuilder openFormButtons = new StringBuilder();
            StringBuilder openFormCases = new StringBuilder();
            foreach (TableMapper table in this.data)
            {
                string entity = listEntityTemplate.Render(new { table.name });
                listEntity.Append(entity);
                string openFormButton = openFormButtonTemplate.Render(new { table.name });
                openFormButtons.Append(openFormButton);
                string openFormCase = openFormCaseTemplate.Render(new { table.name });
                openFormCases.Append(openFormCase);
            }
            return this.form.Render(new { namespacestring = this.namespaceString,
                listentity = listEntity.ToString(),
                openformbuttons = openFormButtons.ToString(),
                openformcases = openFormCases.ToString(),
            });
        }
    }
}
