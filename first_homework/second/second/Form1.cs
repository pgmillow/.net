using System;
using System.Drawing;
using System.Windows.Forms;

namespace second
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int score = 0;
        private int totalQuestions = 5;
        private int currentQuestion = 0;
        private int timeLimit = 10; // 每题10秒
        private System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 每秒触发一次
            timer.Tick += Timer_Tick;
            buttonRestart.Click += buttonRestart_Click; // 确保事件处理程
            StartQuiz();
        }

        private void StartQuiz()
        {
            //检查当前线程是否是创建控件的线程

            if (InvokeRequired)
            {
                Invoke(new Action(StartQuiz));
                return;
            }


            currentQuestion++;
            timeLimit = 10; // 重置时间
            if (currentQuestion > totalQuestions)
            {
                EndQuiz();
                return;
            }

            labelQuestionNumber.Text = $"第 {currentQuestion} 题";
            timer.Start();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int a = random.Next(1, 101);
            int b = random.Next(1, 101);
            string operation = random.Next(0, 2) == 0 ? "+" : "-";

            labelQuestion.Text = $"{a} {operation} {b} = ?";
            labelFeedback.Text = "请作答";
            textBoxAnswer.Clear();
            textBoxAnswer.BackColor = SystemColors.Window; // 重置背景颜色
        }
        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            string[] parts = labelQuestion.Text.Split(' ');
            if (parts.Length >= 3 && int.TryParse(parts[0], out int a) && int.TryParse(parts[2], out int b))
            {
                int correctAnswer = 0;
                if (parts[1] == "+")
                {
                    correctAnswer = a + b;
                }
                else if (parts[1] == "-")
                {
                    correctAnswer = a - b;
                }

                if (int.TryParse(textBoxAnswer.Text, out int userAnswer))
                {
                    if (userAnswer == correctAnswer)
                    {
                        labelFeedback.Text = "正确！";
                        labelFeedback.ForeColor = Color.Green;
                        score++;
                    }
                    else
                    {
                        labelFeedback.Text = $"错误！正确答案是 {correctAnswer}";
                        labelFeedback.ForeColor = Color.Red;
                    }
                }
                else
                {
                    labelFeedback.Text = "请输入有效的数字！";
                    labelFeedback.ForeColor = Color.Red;
                }

                textBoxAnswer.BackColor = (userAnswer == correctAnswer) ? Color.LightGreen : Color.LightCoral;
                timer.Stop();

                // 添加延迟以显示反馈
                await Task.Delay(1000);
                StartQuiz();
            }
            else
            {
                labelFeedback.Text = "问题格式无效！";
                labelFeedback.ForeColor = Color.Red;
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            score = 0;
            currentQuestion = 0;
            labelFeedback.Text = "请作答";
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Clear();
            textBoxAnswer.BackColor = SystemColors.Window;
            buttonSubmit.Text = "提交";
            buttonSubmit.Enabled = true; // 确保按钮可用
            StartQuiz();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLimit--;
            labelTime.Text = $"剩余时间：{timeLimit} 秒";
            if (timeLimit <= 0)
            {
                labelFeedback.Text = "超时！";
                labelFeedback.ForeColor = Color.Red;
                timer.Stop();

                // 添加延迟以显示超时反馈
                Task.Delay(1000).ContinueWith(t => StartQuiz());
            }
        }

        private void EndQuiz()
        {
            timer.Stop();
            labelQuestion.Text = $"得分：{score}/{totalQuestions}";
            labelFeedback.Text = "考试结束！";
            labelFeedback.ForeColor = Color.Black;
            buttonRestart.Text = "重新开始";
            labelQuestionNumber.Text = $"共 {totalQuestions} 题";
            buttonSubmit.Enabled = false; // 禁用提交按钮
        }



        //private void Form1_Load(object sender, EventArgs e)
        //{
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void label3_Click(object sender, EventArgs e)
        //{
        //}

        //private void labelQuestion_Click(object sender, EventArgs e)
        //{
        //}

        //private void label1_Click(object sender, EventArgs e)
        //{
        //}

        //private void buttonRestart_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}
