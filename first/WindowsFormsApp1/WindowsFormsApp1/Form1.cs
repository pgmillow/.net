
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int num1, num2, correctAnswer;
        private int score = 0;
        private int totalQuestions = 5;  // 总题量
        private int questionCount = 0;
        private int timeLeft = 10;  // 每道题10秒限时

        // 界面控件
        private Label labelQuestion;     // 用于显示题目的Label
        private TextBox textBoxAnswer;   // 用户输入答案的TextBox
        private Button buttonSubmit;      // 提交答案的Button
        private Label labelFeedback;      // 显示反馈的Label
        private Label labelTimer;         // 显示剩余时间的Label
        private Timer timer1;             // 计时器

        public Form1()
        {
            InitializeComponent();
            InitializeControls();  // 调用初始化控件的方法
        }

        // 初始化控件
        private void InitializeControls()
        {
            // 创建题目Label
            labelQuestion = new Label();
            labelQuestion.Location = new System.Drawing.Point(30, 30);
            labelQuestion.AutoSize = true;
            this.Controls.Add(labelQuestion);

            // 创建答案TextBox
            textBoxAnswer = new TextBox();
            textBoxAnswer.Location = new System.Drawing.Point(30, 60);
            textBoxAnswer.Width = 200;
            this.Controls.Add(textBoxAnswer);

            // 创建提交Button
            buttonSubmit = new Button();
            buttonSubmit.Text = "提交答案";
            buttonSubmit.Location = new System.Drawing.Point(30, 90);
            buttonSubmit.Click += new EventHandler(buttonSubmit_Click); // 绑定点击事件
            this.Controls.Add(buttonSubmit);

            // 创建反馈Label
            labelFeedback = new Label();
            labelFeedback.Location = new System.Drawing.Point(30, 130);
            labelFeedback.AutoSize = true;
            this.Controls.Add(labelFeedback);

            // 创建剩余时间Label
            labelTimer = new Label();
            labelTimer.Location = new System.Drawing.Point(30, 160);
            labelTimer.AutoSize = true;
            this.Controls.Add(labelTimer);

            // 初始化计时器
            timer1 = new Timer();
            timer1.Interval = 1000; // 每秒触发一次
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        // 在窗体加载时启动程序
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateQuestion();  // 程序启动时生成第一道题
            timer1.Start();      // 启动计时器
        }

        // 生成随机加减法题目的方法
        private void GenerateQuestion()
        {
            timeLeft = 10;  // 重置时间
            labelFeedback.Text = "";  // 清空反馈信息
            labelFeedback.BackColor = DefaultBackColor;  // 恢复背景颜色

            num1 = random.Next(1, 101);
            num2 = random.Next(1, 101);

            // 随机生成加法或减法题目
            if (random.Next(2) == 0)
            {
                labelQuestion.Text = $"{num1} + {num2} = ?";
                correctAnswer = num1 + num2;
            }
            else
            {
                labelQuestion.Text = $"{num1} - {num2} = ?";
                correctAnswer = num1 - num2;
            }

            labelTimer.Text = $"剩余时间: {timeLeft} 秒";
        }

        // 提交答案的按钮点击事件
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int userAnswer;

            // 判断用户是否输入有效数字
            if (int.TryParse(textBoxAnswer.Text, out userAnswer))
            {
                // 使用 if 和 switch 判断答案是否正确
                switch (userAnswer == correctAnswer)
                {
                    case true:
                        score++;  // 答对得1分
                        labelFeedback.Text = "正确!";
                        labelFeedback.BackColor = System.Drawing.Color.Green;
                        break;

                    case false:
                        labelFeedback.Text = $"错误! 正确答案是 {correctAnswer}";
                        labelFeedback.BackColor = System.Drawing.Color.Red;
                        break;
                }

                NextQuestion();  // 进入下一题
            }
            else
            {
                MessageBox.Show("请输入有效的数字！");
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1180, 546);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        // 计时器事件，每秒调用一次
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelTimer.Text = $"剩余时间: {timeLeft} 秒";
            }
            else
            {
                // 时间到，显示正确答案并进入下一题
                labelFeedback.Text = $"超时！正确答案是 {correctAnswer}";
                labelFeedback.BackColor = System.Drawing.Color.Yellow;
                NextQuestion();
            }
        }

        // 进入下一题
        private void NextQuestion()
        {
            questionCount++;
            if (questionCount < totalQuestions)
            {
                textBoxAnswer.Clear();  // 清空输入框
                GenerateQuestion();     // 生成新题
            }
            else
            {
                timer1.Stop();  // 停止计时
                MessageBox.Show($"答题结束！你的得分：{score}/{totalQuestions}");
                Application.Exit();  // 结束程序
            }
        }
    }
}
