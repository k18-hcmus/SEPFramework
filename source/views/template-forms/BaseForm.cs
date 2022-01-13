using SEPFramework.source.Engines;
using SEPFramework.source.EntityMeta;
using SEPFramework.source.Utils.Renderers;
using SEPFramework.source.Utils.Renderers.Factories;
using SEPFramework.source.Utils.Renderers.Parameters;
using SEPFramework.source.Views.template_forms;
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

namespace SEPFramework.source.views.template_forms
{
    public partial class BaseForm : Form
    {
        public DataTable data = new DataTable();
        public BaseForm(List<object> data, Type type)
        {
            InitializeComponent();
            InitData(data, type);
        }

        private void InitData(List<object> list_data, Type type)
        {
            data = ToDataTable<Student>((List<Student>)(object)list_data);
            dgvData.DataSource = data;
            DataProvider dataProvider = DataProvider.Instance;
            dataProvider.ConnString = "Data Source=\"localhost, 1433\";" +
                "Initial Catalog=StudentManagement;User ID=sa;" +
                "Password=DesignPattern@2022;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False" +
                ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<EntityMetaData> tables = dataProvider.getTables();
            ITemplateFactory entityFactory = new EntityFactory();
            string namespaceString = "SEP.SampleSource";
            DirectoryInfo di = Directory.CreateDirectory("SampleSource");
            string path = ".\\SampleSource";
            foreach (EntityMetaData t in tables)
            {
                ITemplate entityTemplate = entityFactory.GetTemplate(new EntityParameter(t, namespaceString));
                entityTemplate.Render(path, t.name);
            }
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
