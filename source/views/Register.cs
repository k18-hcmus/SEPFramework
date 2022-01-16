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

namespace SEPFramework.source.views
{
    public partial class Register : Form
    {
        public Member member;
        private SignIn signIn;
        public Register(SignIn signIn)
        {
            InitializeComponent();
            member = new Member();
            this.signIn = signIn;
        }
        private void setNotifyClear()
        {
            notify_label.Visible = false;
            notify_label.Text = "";
            username_label.ForeColor = Color.Black;
            username_label.Text = "Username";
            password_label.ForeColor = Color.Black;
            password_label.Text = "Password";
            confirm_label.ForeColor = Color.Black;
            confirm_label.Text = "Confirm Password";
        }
        private void showFailNotify(string msg)
        {
            notify_label.Text = msg;
            notify_label.ForeColor = Color.Red;
            notify_label.Visible = true;
        }
        private void showSuccessNotify(string msg)
        {
            notify_label.Text = msg;
            notify_label.ForeColor = Color.Green;
            notify_label.Visible = true;
        }
        private void signIn_btn_Click(object sender, EventArgs e)
        {
            this.signIn.Show();
            this.Close();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            setNotifyClear();
            var username = username_textbox.Text;
            var password = password_textbox.Text;
            var confirm = confirm_textbox.Text;

            if (username == "" || password == "")
            {
                if (username == "")
                {
                    username_label.ForeColor = Color.Red;
                    username_label.Text = "Username is not empty";
                }
                if (password == "")
                {
                    password_label.ForeColor = Color.Red;
                    password_label.Text = "Password is not empty";
                }
                return;
            }

            if (password != confirm)
            {
                confirm_label.ForeColor = Color.Red;
                confirm_label.Text = "Cofirm password do not match";
                return;
            }

            if (this.member.Register(username, password))
            {
                showSuccessNotify("Register success, press Sign In to go back");
                return ;
            }
            else
            {
                showFailNotify("Username already exist!");
                return ;
            }

        }
    }
}
