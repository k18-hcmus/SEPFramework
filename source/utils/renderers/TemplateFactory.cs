using Scriban;
using SEPFramework.source.views.template_forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.utils.renderers
{
    public class TemplateFactory
    {
        public enum FormType
        {
            BaseForm,
            ActionForm,
            AddForm,
            EditForm
        }
        private void initTemplate()
        {
            //formTemplateDict.Add(FormType.BaseForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.txt"));
            //formTemplateDict.Add(FormType.Action, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\Action.txt"));
            //formTemplateDict.Add(FormType.AddForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\AddForm.txt"));
            //formTemplateDict.Add(FormType.EditForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\EditForm.txt"));
            //formDesignerDict.Add(FormType.BaseForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.Designer.txt"));
            //formDesignerDict.Add(FormType.Action, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\Action.Designer.txt"));
            //formDesignerDict.Add(FormType.AddForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\AddForm.Designer.txt"));
            //formDesignerDict.Add(FormType.EditForm, System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\EditForm.Designer.txt"));
        }
        public static FileTemplate getTemplate(FormType type, string namespaceString)
        {
            FileTemplate fileTemplate = null;
            switch (type)
            {
                case FormType.BaseForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.Designer.txt")),
                        namespaceString);
                    break;
                case FormType.ActionForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\ActionForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\ActionForm.Designer.txt")),
                        namespaceString);
                    break;
                case FormType.AddForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\AddForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\AddForm.Designer.txt")),
                        namespaceString);
                    break;
                case FormType.EditForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\EditForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\EditForm.Designer.txt")),
                        namespaceString);
                    break;
            }
            return fileTemplate;
        }
    }
}
