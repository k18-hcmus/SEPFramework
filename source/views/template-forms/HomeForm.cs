using SEPFramework.source.Engines;
using SEPFramework.source.EntityMeta;
using SEPFramework.source.views.template_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.Views.template_forms
{
    public partial class HomeForm : Form
    {
        public List<Student> list_student;
        public List<Class> list_class;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            Button b = new Button();
            b.Text = "Student";
            b.Click += openBaseForm;
        }

        private void openBaseForm(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Form baseForm;
            switch (b.Text)
            {
                case "Student":
                    baseForm = new BaseForm(list_student);
                    break;
                case "Class":
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
