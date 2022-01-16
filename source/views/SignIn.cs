using Scriban;
using SEPFramework.source.Utils.Renderers;
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

namespace SEPFramework.source.views
{
    public partial class SignIn : Form
    {
        private Home homeForm;
        public SignIn(Home homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            homeForm.SetLoggedIn(true);
            this.Close();
        }
    }
}
