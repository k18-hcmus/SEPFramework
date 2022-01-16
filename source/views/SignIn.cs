using Scriban;
using SEPFramework.source.Utils.membership;
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
        public Member member;
        public SignIn()
        {
            InitializeComponent();
            member = new Member();
        }

        private void setNotifyClear()
        {
            notify_label.Visible = false;
            notify_label.Text = "";
            username_Label.ForeColor = Color.Black;
            username_Label.Text = "Username";
            password_label.ForeColor = Color.Black;
            password_label.Text = "Password";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setNotifyClear();
            var username = username_textbox.Text;
            var password = password_textbox.Text;
            if (username == "" || password == "")
            {
                if (username == "")
                {
                    username_Label.ForeColor = Color.Red;
                    username_Label.Text = "Username is not empty";
                }
                if (password == "")
                {
                    password_label.ForeColor = Color.Red;
                    password_label.Text = "Password is not empty";
                }
                return;
            }
            else
            {

                if (this.member.Login(username, password))
                {
                    this.Hide();
                    notify_label.Visible = false;
                    Home home = new Home(this);
                    home.Show();
                }
                else
                {
                    Label Mes = notify_label;
                    Mes.Text = "Username or password incorrect!";
                    Mes.ForeColor = Color.Red;
                    Mes.Visible = true;
                }
            }
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register(this);
            register.Show();
        }
        public string getUsername()
        {
            return username_textbox.Text;
        }
    }
}
