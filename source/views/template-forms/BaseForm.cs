using SEPFramework.source.Engines;
using SEPFramework.source.SQLSep.Entities;
using SEPFramework.source.SQLSep.SepORM;
using SEPFramework.source.Utils;
using SEPFramework.source.Views.template_forms;
using source.Poco;
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
        private HomeForm homeForm = null;
        private string dataType = "";
        public BaseForm(HomeForm homeForm, string dataType, List<Student> data)
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

        private void InitData()
        {
            dgvData.DataSource = this.data;
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

        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            homeForm.RefeshData(dataType);
        }
    }
}
