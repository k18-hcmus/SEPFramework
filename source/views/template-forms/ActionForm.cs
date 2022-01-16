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
    public partial class ActionForm : Form
    {
        public DataTable data;
        public enum Modification
        {
            Readonly,
            Editable
        }
        public Modification modification;
        public BaseForm baseForm;
        public int index = -1;
        public ActionForm(BaseForm baseForm, Modification modification, int index = -1)
        {
            InitializeComponent();
            this.baseForm = baseForm;
            this.data = baseForm.data;
            this.modification = modification;
            this.index = index;
            AddData();
        }
        protected void AddData()
        {
            int panelTop = 4;
            int margin = 3;
            Size panelSize = new Size(0, 0);
            for(int i = 0; i < data.Columns.Count; i++)
            {
                Panel rowPanel = new Panel();
                Label rowLabel = new Label();
                rowLabel.AutoSize = true;
                rowLabel.Text = data.Columns[i].ColumnName;
                rowLabel.Font = new Font("Microsoft Sans Serif", 11);
                rowLabel.Location = new Point(0, 0);
                rowPanel.Controls.Add(rowLabel);
                switch (modification)
                {
                    case Modification.Readonly:
                        Label rowValueLabel = new Label();
                        rowValueLabel.AutoSize = true;
                        if (this.index == -1)
                            rowValueLabel.Text = "";
                        else
                            rowValueLabel.Text = data.Rows[this.index].ItemArray[i].ToString();
                        rowValueLabel.Font = new Font("Microsoft Sans Serif", 11);
                        rowValueLabel.Location = new Point(rowLabel.Size.Width + margin, 0);
                        rowPanel.Controls.Add(rowValueLabel);
                        panelSize = new Size(rowLabel.Size.Width + margin + rowValueLabel.Size.Width, rowLabel.Size.Height);
                        break;
                    case Modification.Editable:
                        rowLabel.Location = new Point(0, 4);
                        TextBox rowValueInput = new TextBox();
                        if (this.index == -1)
                            rowValueInput.Text = "";
                        else
                            rowValueInput.Text = data.Rows[this.index].ItemArray[i].ToString();
                        rowValueInput.Font = new Font("Microsoft Sans Serif", 11);
                        string inputText = "Sample Text";
                        if (!rowValueInput.Text.ToString().Equals(""))
                            inputText = rowValueInput.Text;
                        Size size = TextRenderer.MeasureText(inputText, rowValueInput.Font);
                        rowValueInput.Size = new Size(size.Width + 25, size.Height);
                        rowValueInput.Location = new Point(rowLabel.Size.Width + margin, 0);
                        rowPanel.Controls.Add(rowValueInput);
                        panelSize = new Size(rowLabel.Size.Width + 25 + margin + rowValueInput.Size.Width + 2*margin, rowLabel.Size.Height + 2*margin);
                        break;
                }
                rowPanel.Location = new Point(4, panelTop);
                rowPanel.Size = panelSize;
                pnData.Controls.Add(rowPanel);
                panelTop += rowPanel.Size.Height + margin;
            }
        }

        protected virtual void execute() 
        {
            MessageBox.Show("Action Form");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            execute();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
