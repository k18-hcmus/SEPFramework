using Scriban;
using SEPFramework.source.EntityMeta;
using SEPFramework.source.Utils.Renderers;
using SEPFramework.source.Utils.Renderers.Parameters;
using SEPFramework.source.Utils.Renderers.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Factories
{
    public class FormFactory : ITemplateFactory
    {
        public ITemplate GetTemplate(BaseParameter parameter)
        {
            FormParameter formParam = parameter as FormParameter;
            ITemplate fileTemplate = null;
            switch (formParam.FormType)
            {
                case FormParameter.Type.BaseForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.Designer.txt")),
                        formParam.NamespaceString);
                    break;
                case FormParameter.Type.ActionForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\ActionForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\ActionForm.Designer.txt")),
                        formParam.NamespaceString);
                    break;
                case FormParameter.Type.AddForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.Designer.txt")),
                        formParam.NamespaceString);
                    break;
                case FormParameter.Type.EditForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.Designer.txt")),
                        formParam.NamespaceString);
                    break;
            }
            return fileTemplate;
        }
    }
}
