namespace Third
{
    partial class txtOriginalLineCoun1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtOrialLineCoun = new System.Windows.Forms.Label();
            this.txtOriginalLineCount = new System.Windows.Forms.TextBox();
            this.txtOriginalWordCount = new System.Windows.Forms.TextBox();
            this.txtFormattedWordCount = new System.Windows.Forms.TextBox();
            this.txtFormattedLineCount = new System.Windows.Forms.TextBox();
            this.lstWordOccurrences = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstWordOccurrencesInorder = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOriginalContent = new System.Windows.Forms.TextBox();
            this.txtFormattedContent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(658, 300);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(108, 45);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtOrialLineCoun
            // 
            this.txtOrialLineCoun.AutoSize = true;
            this.txtOrialLineCoun.Location = new System.Drawing.Point(1355, 81);
            this.txtOrialLineCoun.Name = "txtOrialLineCoun";
            this.txtOrialLineCoun.Size = new System.Drawing.Size(0, 18);
            this.txtOrialLineCoun.TabIndex = 1;
            this.txtOrialLineCoun.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtOriginalLineCount
            // 
            this.txtOriginalLineCount.Location = new System.Drawing.Point(954, 99);
            this.txtOriginalLineCount.Name = "txtOriginalLineCount";
            this.txtOriginalLineCount.Size = new System.Drawing.Size(110, 28);
            this.txtOriginalLineCount.TabIndex = 2;
            // 
            // txtOriginalWordCount
            // 
            this.txtOriginalWordCount.Location = new System.Drawing.Point(954, 201);
            this.txtOriginalWordCount.Name = "txtOriginalWordCount";
            this.txtOriginalWordCount.Size = new System.Drawing.Size(110, 28);
            this.txtOriginalWordCount.TabIndex = 3;
            // 
            // txtFormattedWordCount
            // 
            this.txtFormattedWordCount.Location = new System.Drawing.Point(1330, 204);
            this.txtFormattedWordCount.Name = "txtFormattedWordCount";
            this.txtFormattedWordCount.Size = new System.Drawing.Size(96, 28);
            this.txtFormattedWordCount.TabIndex = 5;
            // 
            // txtFormattedLineCount
            // 
            this.txtFormattedLineCount.Location = new System.Drawing.Point(1330, 102);
            this.txtFormattedLineCount.Name = "txtFormattedLineCount";
            this.txtFormattedLineCount.Size = new System.Drawing.Size(96, 28);
            this.txtFormattedLineCount.TabIndex = 4;
            // 
            // lstWordOccurrences
            // 
            this.lstWordOccurrences.FormattingEnabled = true;
            this.lstWordOccurrences.ItemHeight = 18;
            this.lstWordOccurrences.Location = new System.Drawing.Point(133, 61);
            this.lstWordOccurrences.Name = "lstWordOccurrences";
            this.lstWordOccurrences.Size = new System.Drawing.Size(236, 202);
            this.lstWordOccurrences.TabIndex = 6;
            this.lstWordOccurrences.SelectedIndexChanged += new System.EventHandler(this.lstWordOccurrences_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "OriginalLineCount：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "OriginalWordCount：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1136, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "formattedWordCount：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1136, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "formattedLineCount：";
            // 
            // lstWordOccurrencesInorder
            // 
            this.lstWordOccurrencesInorder.FormattingEnabled = true;
            this.lstWordOccurrencesInorder.ItemHeight = 18;
            this.lstWordOccurrencesInorder.Location = new System.Drawing.Point(442, 61);
            this.lstWordOccurrencesInorder.Name = "lstWordOccurrencesInorder";
            this.lstWordOccurrencesInorder.Size = new System.Drawing.Size(280, 202);
            this.lstWordOccurrencesInorder.TabIndex = 11;
            this.lstWordOccurrencesInorder.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "单词统计：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "统计排列：";
            // 
            // txtOriginalContent
            // 
            this.txtOriginalContent.Location = new System.Drawing.Point(133, 430);
            this.txtOriginalContent.Multiline = true;
            this.txtOriginalContent.Name = "txtOriginalContent";
            this.txtOriginalContent.Size = new System.Drawing.Size(589, 473);
            this.txtOriginalContent.TabIndex = 15;
            // 
            // txtFormattedContent
            // 
            this.txtFormattedContent.Location = new System.Drawing.Point(777, 430);
            this.txtFormattedContent.Multiline = true;
            this.txtFormattedContent.Name = "txtFormattedContent";
            this.txtFormattedContent.Size = new System.Drawing.Size(649, 473);
            this.txtFormattedContent.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(769, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "修改文本：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 17;
            this.label8.Text = "原始文本：";
            // 
            // txtOriginalLineCoun1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 915);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFormattedContent);
            this.Controls.Add(this.txtOriginalContent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstWordOccurrencesInorder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstWordOccurrences);
            this.Controls.Add(this.txtFormattedWordCount);
            this.Controls.Add(this.txtFormattedLineCount);
            this.Controls.Add(this.txtOriginalWordCount);
            this.Controls.Add(this.txtOriginalLineCount);
            this.Controls.Add(this.txtOrialLineCoun);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "txtOriginalLineCoun1";
            this.Text = "txtFormattedWordCount";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label txtOrialLineCoun;
        private System.Windows.Forms.TextBox txtOriginalLineCount;
        private System.Windows.Forms.TextBox txtOriginalWordCount;
        private System.Windows.Forms.TextBox txtFormattedWordCount;
        private System.Windows.Forms.TextBox txtFormattedLineCount;
        private System.Windows.Forms.ListBox lstWordOccurrences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstWordOccurrencesInorder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOriginalContent;
        private System.Windows.Forms.TextBox txtFormattedContent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

