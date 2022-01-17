using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.Utils.membership;

namespace SEPFramework.source.views
{
    public partial class Home : Form
    {
        public Membership member;
        private string username;
        private SignIn signIn;
        public Home(SignIn signIn)
        {
            InitializeComponent();
            this.signIn = signIn;
            string CONNECTION_STRING = "Data Source=\"localhost, 1433\";" +
                            "Initial Catalog=StudentManagement;User ID=sa;" +
                            "Password=DesignPattern@2022;Connect Timeout=30;" +
                            "Encrypt=False;TrustServerCertificate=False" +
                            ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            member = new Membership(CONNECTION_STRING);
            this.username = signIn.getUsername();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (this.member.Logout(this.username))
            {
                this.signIn.Show();
                this.Close();
            }
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            GeneratingForm form = new GeneratingForm();
            form.Show();
        }
    }
}
