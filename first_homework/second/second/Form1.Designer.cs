namespace second
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
            buttonSubmit = new Button();
            textBoxAnswer = new TextBox();
            labelQuestion = new Label();
            labelFeedback = new Label();
            labelTime = new Label();
            buttonRestart = new Button();
            labelQuestionNumber = new Label();
            SuspendLayout();
            // 
            // buttonSubmit
            // 
            buttonSubmit.Location = new Point(446, 193);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(112, 34);
            buttonSubmit.TabIndex = 0;
            buttonSubmit.Text = "Submit";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(261, 197);
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(150, 30);
            textBoxAnswer.TabIndex = 1;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(150, 100);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(46, 24);
            labelQuestion.TabIndex = 2;
            labelQuestion.Text = "分数";
            //labelQuestion.Click += labelQuestion_Click;
            // 
            // labelFeedback
            // 
            labelFeedback.AutoSize = true;
            labelFeedback.Location = new Point(150, 310);
            labelFeedback.Name = "labelFeedback";
            labelFeedback.Size = new Size(63, 24);
            labelFeedback.TabIndex = 3;
            labelFeedback.Text = "label1";
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(384, 310);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(63, 24);
            labelTime.TabIndex = 4;
            labelTime.Text = "label1";
            //labelTime.Click += label1_Click;
            // 
            // buttonRestart
            // 
            buttonRestart.Location = new Point(591, 193);
            buttonRestart.Name = "buttonRestart";
            buttonRestart.Size = new Size(112, 34);
            buttonRestart.TabIndex = 5;
            buttonRestart.Text = "Restart";
            buttonRestart.UseVisualStyleBackColor = true;
            //buttonRestart.Click += buttonRestart_Click_1;
            // 
            // labelQuestionNumber
            // 
            labelQuestionNumber.AutoSize = true;
            labelQuestionNumber.Location = new Point(150, 203);
            labelQuestionNumber.Name = "labelQuestionNumber";
            labelQuestionNumber.Size = new Size(55, 24);
            labelQuestionNumber.TabIndex = 6;
            labelQuestionNumber.Text = "第x题";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(labelQuestionNumber);
            Controls.Add(buttonRestart);
            Controls.Add(labelTime);
            Controls.Add(labelFeedback);
            Controls.Add(labelQuestion);
            Controls.Add(textBoxAnswer);
            Controls.Add(buttonSubmit);
            Name = "Form1";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "第二题(考试系统）";
            //Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSubmit;
        private TextBox textBoxAnswer;
        private Label labelQuestion;
        private Label labelFeedback;
        private Label labelTime;
        private Button buttonRestart;
        private Label labelQuestionNumber;
    }
}
