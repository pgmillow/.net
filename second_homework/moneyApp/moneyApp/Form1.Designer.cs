namespace moneyApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            txtUsername = new TextBox();
            btnLogin = new Button();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(22, 25);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(42, 24);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "test";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(435, 140);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(245, 30);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(395, 392);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 34);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "login/regist";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(435, 223);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(245, 30);
            txtPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 140);
            label2.Name = "label2";
            label2.Size = new Size(94, 24);
            label2.TabIndex = 4;
            label2.Text = "username";
           
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(222, 219);
            label3.Name = "label3";
            label3.Size = new Size(92, 24);
            label3.TabIndex = 5;
            label3.Text = "password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 615);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(txtUsername);
            Controls.Add(lblMessage);
            Name = "Form1";
            Text = "登录";
            Load += Form1_Load;
            Click += btnLogin_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblMessage;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
    }
}
