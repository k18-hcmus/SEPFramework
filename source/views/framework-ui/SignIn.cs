using Scriban;
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
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Sample Generate Code
            DirectoryInfo di = Directory.CreateDirectory("source");
            string text = System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.txt");
            Template baseFormTemplate = Template.Parse(text);
            string result = baseFormTemplate.Render(new { name = "Nhan" });
            File.WriteAllText(".\\source\\ClonedBaseForm.cs", result);
            string text2 = System.IO.File.ReadAllText("..\\..\\source\\views\\template-forms\\BaseForm.Designer.cs.txt");
            Template baseFormTemplate2 = Template.Parse(text2);
            string result2 = baseFormTemplate2.Render();
            File.WriteAllText(".\\source\\ClonedBaseForm.Designer.cs", result2);
        }
    }
}
