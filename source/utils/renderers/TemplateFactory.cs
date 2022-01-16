using Scriban;
using SEPFramework.source.SQLSep.Entities;
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
        public enum Type
        {
            BaseForm,
            ActionForm,
            AddForm,
            EditForm,
            Entity
        }
        private void initTemplate()
        {
            //formTemplateDict.Add(Type.BaseForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.txt"));
            //formTemplateDict.Add(Type.Action, System.IO.File.ReadAllText("..\\..\\source\\Templates\\Action.txt"));
            //formTemplateDict.Add(Type.AddForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.txt"));
            //formTemplateDict.Add(Type.EditForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.txt"));
            //formDesignerDict.Add(Type.BaseForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.Designer.txt"));
            //formDesignerDict.Add(Type.Action, System.IO.File.ReadAllText("..\\..\\source\\Templates\\Action.Designer.txt"));
            //formDesignerDict.Add(Type.AddForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.Designer.txt"));
            //formDesignerDict.Add(Type.EditForm, System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.Designer.txt"));
        }
        public static ITemplate getTemplate(Type type, string namespaceString, TableMapper data = null)
        {
            ITemplate fileTemplate = null;
            switch (type)
            {
                case Type.BaseForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\BaseForm.Designer.txt")),
                        namespaceString);
                    break;
                case Type.ActionForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\ActionForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\ActionForm.Designer.txt")),
                        namespaceString);
                    break;
                case Type.AddForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\AddForm.Designer.txt")),
                        namespaceString);
                    break;
                case Type.EditForm:
                    fileTemplate = new FormTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\EditForm.Designer.txt")),
                        namespaceString);
                    break;
                case Type.Entity:
                    fileTemplate = new EntityTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\EntityTemplate.txt")),
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\FieldTemplate.txt")),
                        data,
                        namespaceString);
                    break;
            }
            return fileTemplate;
        }
    }
}
