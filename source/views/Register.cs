using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.Utils.IoCContainer;
using SEPFramework.source.Utils.membership;
using SEPFramework.source.Views.RegisterComponents;

namespace SEPFramework.source.views
{
    public partial class Register : Form
    {
        private SignIn signIn;
        private RegisterState registerState;
        public RegisterState RegisterState { get => registerState; set => registerState = value; }
        public Register(SignIn signIn)
        {
            InitializeComponent();
            this.signIn = signIn;
            RegisterState = IoC.Resolve<IdleState>(new InjectionConstructor().AddParameter<Register>(this));
        }
        public void setNotifyClear()
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
        public void OnVerificationSuccess()
        {
            showSuccessNotify("Register success, press Sign In to go back");
            return;
        }

        public void NotifyVerificationFailed()
        {
            showFailNotify("Username already exist!");
            return;
        }

        public void NotifyValidationFailed()
        {
            var username = username_textbox.Text;
            var password = password_textbox.Text;
            var confirm = confirm_textbox.Text;
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
            if (password != confirm)
            {
                confirm_label.ForeColor = Color.Red;
                confirm_label.Text = "Cofirm password do not match";
                return;
            }
        }

        public bool Verify()
        {
            if (this.signIn.member.Register(username_textbox.Text, password_textbox.Text))
                return true;
            else
                return false;
        }

        public bool Validate()
        {
            if (username_textbox.Text == "" || password_textbox.Text == "" || password_textbox.Text != confirm_textbox.Text )
                return false;
            return true;
        }
        private void signIn_btn_Click(object sender, EventArgs e)
        {
            this.signIn.Show();
            this.Close();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {

            registerState.OnRegister();

        }
    }
}
