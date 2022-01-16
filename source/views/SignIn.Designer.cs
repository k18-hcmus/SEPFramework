namespace SEPFramework.source.views
{
    partial class SignIn
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
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.username_Label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.signIn_btn = new System.Windows.Forms.Button();
            this.notify_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(203, 289);
            this.register_btn.Margin = new System.Windows.Forms.Padding(4);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(188, 50);
            this.register_btn.TabIndex = 1;
            this.register_btn.Text = "Register";
            this.register_btn.UseVisualStyleBackColor = true;
            this.register_btn.Click += new System.EventHandler(this.register_btn_Click);
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(203, 103);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(188, 22);
            this.username_textbox.TabIndex = 2;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(203, 163);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(188, 22);
            this.password_textbox.TabIndex = 3;
            // 
            // username_Label
            // 
            this.username_Label.AutoSize = true;
            this.username_Label.Location = new System.Drawing.Point(200, 84);
            this.username_Label.Name = "username_Label";
            this.username_Label.Size = new System.Drawing.Size(70, 16);
            this.username_Label.TabIndex = 4;
            this.username_Label.Text = "Username";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(203, 141);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(67, 16);
            this.password_label.TabIndex = 5;
            this.password_label.Text = "Password";
            // 
            // signIn_btn
            // 
            this.signIn_btn.Location = new System.Drawing.Point(203, 218);
            this.signIn_btn.Margin = new System.Windows.Forms.Padding(4);
            this.signIn_btn.Name = "signIn_btn";
            this.signIn_btn.Size = new System.Drawing.Size(188, 50);
            this.signIn_btn.TabIndex = 6;
            this.signIn_btn.Text = "Sign in";
            this.signIn_btn.UseVisualStyleBackColor = true;
            this.signIn_btn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // notify_label
            // 
            this.notify_label.AutoSize = true;
            this.notify_label.Location = new System.Drawing.Point(200, 37);
            this.notify_label.Name = "notify_label";
            this.notify_label.Size = new System.Drawing.Size(44, 16);
            this.notify_label.TabIndex = 7;
            this.notify_label.Text = "label1";
            this.notify_label.Visible = false;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 409);
            this.Controls.Add(this.notify_label);
            this.Controls.Add(this.signIn_btn);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_Label);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.register_btn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SignIn";
            this.Text = "SignIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button register_btn;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label username_Label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button signIn_btn;
        private System.Windows.Forms.Label notify_label;
    }
}