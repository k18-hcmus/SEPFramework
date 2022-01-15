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
            InitMockData();
        }

        private void InitMockData()
        {
            data.Columns.Add("Name");
            data.Columns.Add("MSSV");
            data.Columns.Add("Email");
            data.Rows.Add("Nhan", "18120495", "ttn@gmail.com");
            data.Rows.Add("Long", "18120449", "nhl@gmail.com");
            data.Rows.Add("Quan", "18120521", "kmq@gmail.com");
            data.Rows.Add("Nguyen", "18120488", "tpn@gmail.com");
            dgvData.DataSource = data;
            
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

            // Demo Get
            Mon_Hoc monhoc = sqlDB.Get<Mon_Hoc>("THT01");
            Console.WriteLine("Old 1: " + monhoc.MaMH + " " + monhoc.Ma_Khoa+ " "+ monhoc.TenMH);

            // Demo Update
            Mon_Hoc monhoc2 = sqlDB.Get<Mon_Hoc>("THT02");
            monhoc2.TenMH = "Xin chao Viet Nam";
            Console.WriteLine("Old 2: " + monhoc2.MaMH + " " + monhoc2.Ma_Khoa + " " + monhoc2.TenMH);

            bool ok = sqlDB.Update<Mon_Hoc>(monhoc, monhoc2);
            
            Mon_Hoc monhocX = sqlDB.Get<Mon_Hoc>("THT01");
            Console.WriteLine("New 1: " + monhocX.MaMH + " " + monhocX.Ma_Khoa + " " + monhocX.TenMH);


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
