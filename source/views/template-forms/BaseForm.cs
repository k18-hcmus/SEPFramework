using SEPFramework.source.Engines;
using SEPFramework.source.SQLSep.Entities;
using SEPFramework.source.SQLSep.SepORM;
using source.Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.views.template_forms
{
    public partial class BaseForm : Form
    {
        public DataTable data = new DataTable();
        public BaseForm()
        {
            InitializeComponent();
            this.homeForm = homeForm;
            this.dataType = dataType;
            this.data = DataUtils.ToDataTable<Student>(data);
            InitData();
        }
        public BaseForm(HomeForm homeForm, string dataType, List<Class> data)
        {
            InitializeComponent();
            this.homeForm = homeForm;
            this.dataType = dataType;
            this.data = DataUtils.ToDataTable<Class>(data);
            InitData();
        }

        private void InitMockData()
        {
            dgvData.DataSource = this.data;
            return;
            string CONNECTION_STRING = "Data Source=\"localhost, 1433\";" +
                "Initial Catalog=StudentManagement;User ID=sa;" +
                "Password=DesignPattern@2022;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False" +
                ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataProvider dataProvider = new DataProvider(CONNECTION_STRING);

            //// Generate Entity from Table
            //List<TableMapper> tables = dataProvider.getTables();
            //foreach (TableMapper t in tables)
            //{
            //    EntityTemplateEngine.Instance.generateEntityFile(t);
            //}

            IDatabase sqlDB = new SQLDatabase(CONNECTION_STRING);
            sqlDB.Open();

            //// Demo Get
            //Mon_Hoc monhoc = sqlDB.GetByID<Mon_Hoc>("THT01");
            //Console.WriteLine("Old 1: " + monhoc.MaMH + " " + monhoc.Ma_Khoa + " " + monhoc.TenMH);

            //// Demo Update
            //Mon_Hoc monhoc2 = sqlDB.GetByID<Mon_Hoc>("THT02");
            //monhoc2.TenMH = "Xin chao Viet Nam 2";
            //Console.WriteLine("Old 2: " + monhoc2.MaMH + " " + monhoc2.Ma_Khoa + " " + monhoc2.TenMH);

            //bool ok = sqlDB.Update<Mon_Hoc>(monhoc, monhoc2);

            //Mon_Hoc monhocX = sqlDB.GetByID<Mon_Hoc>("THT01");
            //Console.WriteLine("New 1: " + monhocX.MaMH + " " + monhocX.Ma_Khoa + " " + monhocX.TenMH);

            //// Demo Insert
            //monhoc2.MaMH = "THT003";
            //bool x = sqlDB.Insert<Mon_Hoc>(monhoc2);

            //Mon_Hoc monhocY = sqlDB.GetByID<Mon_Hoc>("THT003");
            //Console.WriteLine("New inserted: " + monhocY.MaMH + " " + monhocY.Ma_Khoa + " " + monhocY.TenMH);

            //// Demo Get List Normal
            //List<Mon_Hoc> subjects = sqlDB.GetList<Mon_Hoc>();
            //foreach (Mon_Hoc subject in subjects)
            //{
            //    Console.WriteLine(subject.MaMH + " " + subject.Ma_Khoa + " " + subject.TenMH);
            //}
            //// Demo Get List With Conditions
            //List<Mon_Hoc> conditionSubs = sqlDB.GetList<Mon_Hoc>(string.Format("MaMH = '{0}'", "THT02"));
            //foreach (Mon_Hoc subject in conditionSubs)
            //{
            //    Console.WriteLine(subject.MaMH + " " + subject.Ma_Khoa + " " + subject.TenMH);
            //}

            // Demo Get With Conditions
            Mon_Hoc monhoc = sqlDB.Get<Mon_Hoc>("SELECT * FROM Mon_Hoc WHERE MaMH = 'THT02'");
            Console.WriteLine("Get With Condition " + monhoc.MaMH + " " + monhoc.Ma_Khoa + " " + monhoc.TenMH);


        }

        private void Add_Click(object sender, EventArgs e)
        {
            ActionForm af = new AddForm(this, ActionForm.Modification.Editable);
            af.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
                return;
            DataGridViewRow selectedRow = dgvData.SelectedRows[0] as DataGridViewRow;
            ActionForm ef = new EditForm(this, ActionForm.Modification.Editable, selectedRow.Index);
            ef.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
                return;
            DataGridViewRow selectedRow = dgvData.SelectedRows[0] as DataGridViewRow;
            string dataString = "";
            foreach (DataGridViewCell cell in selectedRow.Cells)
                dataString += cell.Value.ToString() + " ";
            DialogResult dialogResult = MessageBox.Show(dataString, "Are you sure to delete this row", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                data.Rows.Remove(data.Rows[selectedRow.Index]);
            }
        }
    }
}
