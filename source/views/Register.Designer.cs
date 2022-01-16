namespace SEPFramework.source.views
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.register_btn = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.confirm_label = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.confirm_textbox = new System.Windows.Forms.TextBox();
            this.signIn_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notify_label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(271, 246);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(188, 50);
            this.register_btn.TabIndex = 0;
            this.register_btn.Text = "Register";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(49, 21);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(70, 16);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(49, 75);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(67, 16);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password";
            // 
            // confirm_label
            // 
            this.confirm_label.AutoSize = true;
            this.confirm_label.Location = new System.Drawing.Point(49, 131);
            this.confirm_label.Name = "confirm_label";
            this.confirm_label.Size = new System.Drawing.Size(116, 16);
            this.confirm_label.TabIndex = 3;
            this.confirm_label.Text = "Confirm-Password";
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(52, 40);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(188, 22);
            this.username_textbox.TabIndex = 4;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(52, 94);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(188, 22);
            this.password_textbox.TabIndex = 5;
            // 
            // confirm_textbox
            // 
            this.confirm_textbox.Location = new System.Drawing.Point(52, 150);
            this.confirm_textbox.Name = "confirm_textbox";
            this.confirm_textbox.Size = new System.Drawing.Size(188, 22);
            this.confirm_textbox.TabIndex = 6;
            // 
            // signIn_btn
            // 
            this.signIn_btn.Location = new System.Drawing.Point(271, 315);
            this.signIn_btn.Name = "signIn_btn";
            this.signIn_btn.Size = new System.Drawing.Size(188, 50);
            this.signIn_btn.TabIndex = 1;
            this.signIn_btn.Text = "Sign In";
            this.signIn_btn.UseVisualStyleBackColor = true;
            this.signIn_btn.Click += new System.EventHandler(this.signIn_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.confirm_textbox);
            this.panel1.Controls.Add(this.username_label);
            this.panel1.Controls.Add(this.confirm_label);
            this.panel1.Controls.Add(this.password_textbox);
            this.panel1.Controls.Add(this.username_textbox);
            this.panel1.Controls.Add(this.password_label);
            this.panel1.Location = new System.Drawing.Point(219, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 208);
            this.panel1.TabIndex = 2;
            // 
            // notify_label
            // 
            this.notify_label.AutoSize = true;
            this.notify_label.Location = new System.Drawing.Point(268, 13);
            this.notify_label.Name = "notify_label";
            this.notify_label.Size = new System.Drawing.Size(44, 16);
            this.notify_label.TabIndex = 7;
            this.notify_label.Text = "label1";
            this.notify_label.Visible = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.notify_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.signIn_btn);
            this.Controls.Add(this.register_btn);
            this.Name = "Register";
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.TextBox confirm_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label confirm_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Button signIn_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label notify_label;
    }
}