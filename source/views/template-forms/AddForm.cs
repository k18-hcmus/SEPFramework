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
    public partial class AddForm : ActionForm
    {
        public AddForm(BaseForm baseForm, DataTable data, Modification modification, int index = -1): base(baseForm, data, modification, index)
        {
            InitializeComponent();
            this.Size = new Size(550, 420);
        }

        protected override void execute()
        {
            List<string> data = new List<string>();
            foreach (Control panel in pnData.Controls)
            {
                for (int i = 1; i < panel.Controls.Count; i += 2) {
                    data.Add(panel.Controls[i].Text.ToString());
                }
            }
            this.data.Rows.Add(data.ToArray());
        }
    }
}
