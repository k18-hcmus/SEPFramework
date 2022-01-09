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
    public partial class EditForm : ActionForm
    {
        public EditForm(BaseForm baseForm, DataTable data, Modification modification, int index = -1) : base(baseForm, data, modification, index)
        {
            InitializeComponent();
            this.Size = new Size(550, 420);
        }

        protected override void execute()
        {
            List<string> data = new List<string>();
            for (int i = 0; i < this.data.Columns.Count; i += 1)
            {
                this.data.Rows[this.index][i] = pnData.Controls[i].Controls[1].Text.ToString();
            }
            baseForm.dgvData.DataSource = this.data;
        }
    }
}
