using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.utils.membership;

namespace SEPFramework.source.views.framework_ui
{
    public partial class Home : Form
    {
        public Member member;
        private string username;
        private SignIn signIn;
        public Home(SignIn signIn)
        {
            InitializeComponent();
            this.signIn = signIn;
            member = new Member();
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
