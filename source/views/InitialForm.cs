using SEPFramework.source.SQLSep.SepORM;
using SEPFramework.source.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.Views
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataProvider provider = GetDataProvider();
            if (provider == null)
            {
                MessageBox.Show("Connection Creating Failed");
                return;
            }
            if (cbDatabase.SelectedItem == null)
            {
                MessageBox.Show("Database Name Not Selected");
                return;
            }
            DataRowView row = cbDatabase.SelectedItem as DataRowView;
            provider.Catalog = (string)row.Row["name"];
            SignIn signInForm = new SignIn();
            signInForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProvider provider = GetDataProvider();
            if (provider == null)
                MessageBox.Show("Test Failed!!!");
            else
                MessageBox.Show("Test Successfully!!!");
        }

        private void cbDatabase_Click(object sender, EventArgs e)
        {
            DataProvider provider = GetDataProvider();
            if (provider == null)
            {
                MessageBox.Show("Connection Creating Failed!!!");
                return;
            }
            cbDatabase.DataSource = provider.GetCatalogList();
            cbDatabase.DisplayMember = "name";
            cbDatabase.Enabled = true;
        }

        private DataProvider GetDataProvider()
        {
            return DataProvider.GetInstance(tbDataSource.Text, tbUserName.Text, tbPassword.Text);
        }
    }
}
