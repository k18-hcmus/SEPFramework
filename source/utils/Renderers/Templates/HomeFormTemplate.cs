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
            Template listEntityTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\ListEntity.txt"));
            Template openFormButtonTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\OpenFormButton.txt"));
            Template openFormCaseTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\OpenFormCase.txt"));
            Template getDataTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\GetData.txt"));
            Template getDataCaseTemplate = Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\HomeForm\\GetDataCase.txt"));
            StringBuilder listEntity = new StringBuilder();
            StringBuilder openFormButtons = new StringBuilder();
            StringBuilder openFormCases = new StringBuilder();
            StringBuilder getDatas = new StringBuilder();
            StringBuilder getDataCases = new StringBuilder();
            foreach (TableMapper table in this.data)
            {
                string entity = listEntityTemplate.Render(new { table.name });
                listEntity.Append(entity);
                string openFormButton = openFormButtonTemplate.Render(new { table.name });
                openFormButtons.Append(openFormButton);
                string openFormCase = openFormCaseTemplate.Render(new { table.name });
                openFormCases.Append(openFormCase);
                string getData = getDataTemplate.Render(new { table.name });
                getDatas.Append(getData);
                string getDataCase = getDataCaseTemplate.Render(new { table.name });
                getDataCases.Append(getDataCase);
            }
            return this.form.Render(new
            {
                namespacestring = this.namespaceString,
                listentity = listEntity.ToString(),
                openformbuttons = openFormButtons.ToString(),
                openformcases = openFormCases.ToString(),
                getdatas = getDatas.ToString(),
                getdatacases = getDataCases.ToString(),
                connectionstring = connectionString
            });
        }
    }
}
