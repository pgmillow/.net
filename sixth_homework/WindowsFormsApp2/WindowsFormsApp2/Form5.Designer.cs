namespace WindowsFormsApp2
{
    partial class Form5
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewInfo = new System.Windows.Forms.TextBox();
            this.buttonUpdateSchool = new System.Windows.Forms.Button();
            this.BtnDeleteClass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(269, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(317, 26);
            this.comboBox1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "学校新名称： ";
            // 
            // textBoxNewName
            // 
            this.textBoxNewName.Location = new System.Drawing.Point(269, 123);
            this.textBoxNewName.Name = "textBoxNewName";
            this.textBoxNewName.Size = new System.Drawing.Size(317, 28);
            this.textBoxNewName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "学校原名称： ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "学校新地址： ";
            // 
            // textBoxNewInfo
            // 
            this.textBoxNewInfo.Location = new System.Drawing.Point(269, 192);
            this.textBoxNewInfo.Name = "textBoxNewInfo";
            this.textBoxNewInfo.Size = new System.Drawing.Size(317, 28);
            this.textBoxNewInfo.TabIndex = 18;
            // 
            // buttonUpdateSchool
            // 
            this.buttonUpdateSchool.Location = new System.Drawing.Point(269, 281);
            this.buttonUpdateSchool.Name = "buttonUpdateSchool";
            this.buttonUpdateSchool.Size = new System.Drawing.Size(187, 69);
            this.buttonUpdateSchool.TabIndex = 20;
            this.buttonUpdateSchool.Text = "确认";
            this.buttonUpdateSchool.UseVisualStyleBackColor = true;
            this.buttonUpdateSchool.Click += new System.EventHandler(this.buttonUpdateSchool_Click);
            // 
            // BtnDeleteClass
            // 
            this.BtnDeleteClass.BackColor = System.Drawing.Color.Brown;
            this.BtnDeleteClass.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnDeleteClass.Location = new System.Drawing.Point(510, 281);
            this.BtnDeleteClass.Name = "BtnDeleteClass";
            this.BtnDeleteClass.Size = new System.Drawing.Size(164, 69);
            this.BtnDeleteClass.TabIndex = 39;
            this.BtnDeleteClass.Text = "删除学校";
            this.BtnDeleteClass.UseVisualStyleBackColor = false;
            this.BtnDeleteClass.Click += new System.EventHandler(this.BtnDeleteClass_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnDeleteClass);
            this.Controls.Add(this.buttonUpdateSchool);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewInfo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNewName);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewInfo;
        private System.Windows.Forms.Button buttonUpdateSchool;
        private System.Windows.Forms.Button BtnDeleteClass;
    }
}