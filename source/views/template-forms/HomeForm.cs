using SEPFramework.source.Engines;
using SEPFramework.source.SQLSep.SepORM;
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
        private Font defaultFont = new Font("Microsoft Sans Serif", 11);
        private bool defaultAutoSize = true;
        //public List<Student> list_student = new List<Student>();
        //public List<Class> list_class = new List<Class>();
        public HomeForm()
        {
            InitializeComponent();
            LoadData();
            GenerateButtons();
        }

        private void LoadData()
        {
        }

        private void GenerateButtons()
        {
            ////Student
            //Button bStudent = new Button();
            //bStudent.Text = "Student";
            //bStudent.Click += openBaseForm;
            //bStudent.AutoSize = defaultAutoSize;
            //bStudent.Font = defaultFont;
            //flpButtons.Controls.Add(bStudent);
            ////Class
            //Button bClass = new Button();
            //bClass.Text = "Class";
            //bClass.Click += openBaseForm;
            //bClass.AutoSize = true;
            //bClass.Font = new Font("Microsoft Sans Serif", 11);
            //flpButtons.Controls.Add(bClass);
        }

        public void RefeshData(string type)
        {
            return;
            string CONNECTION_STRING = "Data Source=\"localhost, 1433\";" +
            "Initial Catalog=StudentManagement;User ID=sa;" +
            "Password=DesignPattern@2022;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False" +
            ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataProvider dataProvider = new DataProvider(CONNECTION_STRING);
            IDatabase sqlDB = new SQLDatabase(CONNECTION_STRING);
            sqlDB.Open();
            switch (type)
            {
                case "Student":
                    //list_student = sqlDB.GetAll<Student>("THT01");
                    break;
                case "Class":
                    //list_class = sqlDB.GetAll<Class>("THT01");
                    break;
            }
        }

        private void openBaseForm(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Form baseForm = null;
            switch (b.Text)
            {
                //case "Student":
                //    baseForm = new BaseForm(this, typeof(Student).Name, list_student);
                //    break;
                //case "Class":
                //    baseForm = new BaseForm(this, typeof(Class).Name, list_class);
                //    break;
            }
            if (baseForm != null)
                baseForm.Show();
        }
    }
}
