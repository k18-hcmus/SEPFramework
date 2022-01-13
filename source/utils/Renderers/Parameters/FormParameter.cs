using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Parameters
{
    public class FormParameter : BaseParameter
    {
        public enum Type
        {
            BaseForm,
            ActionForm,
            AddForm,
            EditForm
        }
        private Type formType;
        public Type FormType { get => formType; set => formType = value; }
        public FormParameter(Type formType, string namespaceString) : base(namespaceString)
        {
            this.FormType = formType;
        }
    }
}
