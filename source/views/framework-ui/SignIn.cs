using Scriban;
using SEPFramework.source.utils.renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.views.framework_ui
{
    public partial class SignIn : Form
    {
        private Home homeForm;
        public SignIn(Home homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Sample Generate Code
            //DirectoryInfo di = Directory.CreateDirectory("sample");
            //string namespaceString = "SEPFramework.sample";
            //TemplateFactory.getTemplate(TemplateFactory.FormType.BaseForm, namespaceString)
            //    .Render(".\\sample", "BaseForm");
            //TemplateFactory.getTemplate(TemplateFactory.FormType.ActionForm, namespaceString)
            //    .Render(".\\sample", "ActionForm");
            //TemplateFactory.getTemplate(TemplateFactory.FormType.AddForm, namespaceString)
            //    .Render(".\\sample", "AddForm");
            //TemplateFactory.getTemplate(TemplateFactory.FormType.EditForm, namespaceString)
            //    .Render(".\\sample", "EditForm");


            //if (true)
            //{
            //    this.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            homeForm.SetLoggedIn(true);
            this.Close();
        }
    }
}
