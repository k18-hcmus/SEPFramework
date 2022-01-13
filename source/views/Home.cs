using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.views
{
    public partial class Home : Form
    {
        private bool isLoggedIn = false;
        public Home()
        {
            InitializeComponent();
            LoadButton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Signin
            if (true)
            {
                GeneratingForm form = new GeneratingForm();
                form.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void lvContainer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton()
        {
            pnContainer.Controls.Clear();
            if (!isLoggedIn)
            {
                Button b = new Button();
                b.Text = "Sign In";
                b.Font = new Font("Microsoft Sans Serif", 11);
                b.Location = new Point(20, 20);
                b.Size = new Size(100, 40);
                b.Click += SignIn_Click;
                pnContainer.Controls.Add(b);
                Button b2 = new Button();
                b2.Text = "Register";
                b2.Font = new Font("Microsoft Sans Serif", 11);
                b2.Location = new Point(20, 70);
                b2.Size = new Size(100, 40);
                pnContainer.Controls.Add(b2);
            }
            else
            {
                Button b = new Button();
                b.Text = "Generate Source";
                b.Font = new Font("Microsoft Sans Serif", 11);
                b.Location = new Point(20, 20);
                b.Size = new Size(100, 40);
                pnContainer.Controls.Add(b);
                Button b2 = new Button();
                b2.Text = "Sign out";
                b2.Font = new Font("Microsoft Sans Serif", 11);
                b2.Location = new Point(20, 70);
                b2.Size = new Size(100, 40);
                pnContainer.Controls.Add(b2);
            }
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            SignIn f = new SignIn(this);
            f.Show();
        }

        public void SetLoggedIn(bool isLoggedIn)
        {
            this.isLoggedIn = isLoggedIn;
            LoadButton();
        }
    }
}
