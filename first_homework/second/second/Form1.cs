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
        private int timeLimit = 10; // ÿ��10��
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // ÿ�봥��һ��
            timer.Tick += Timer_Tick;
            buttonRestart.Click += buttonRestart_Click; // ȷ���¼������
            StartQuiz();
        }
        private void StartQuiz()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(StartQuiz));
                return;
            }
            currentQuestion++;
            timeLimit = 10; // ����ʱ��
            if (currentQuestion > totalQuestions)
            {
                EndQuiz();
                return;
            }
            labelQuestionNumber.Text = $"�� {currentQuestion} ��";
            timer.Start();
            GenerateQuestion();
        }
        private void GenerateQuestion()
        {
            int a = random.Next(1, 101);
            int b = random.Next(1, 101);
            string operation = random.Next(0, 2) == 0 ? "+" : "-";
            labelQuestion.Text = $"{a} {operation} {b} = ?";
            labelFeedback.Text = "������";
            textBoxAnswer.Clear();
            textBoxAnswer.BackColor = SystemColors.Window; // ���ñ�����ɫ
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
                        labelFeedback.Text = "��ȷ��";
                        labelFeedback.ForeColor = Color.Green;
                        score++;
                    }
                    else
                    {
                        labelFeedback.Text = $"������ȷ���� {correctAnswer}";
                        labelFeedback.ForeColor = Color.Red;
                    }
                }
                else
                {
                    labelFeedback.Text = "��������Ч�����֣�";
                    labelFeedback.ForeColor = Color.Red;
                }
                textBoxAnswer.BackColor = (userAnswer == correctAnswer) ? Color.LightGreen : Color.LightCoral;
                timer.Stop();
                await Task.Delay(1000);
                StartQuiz();
            }
            else
            {
                labelFeedback.Text = "�����ʽ��Ч��";
                labelFeedback.ForeColor = Color.Red;
            }
        }
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            score = 0;
            currentQuestion = 0;
            labelFeedback.Text = "������";
            labelQuestion.Text = string.Empty;
            textBoxAnswer.Clear();
            textBoxAnswer.BackColor = SystemColors.Window;
            buttonSubmit.Text = "�ύ";
            buttonSubmit.Enabled = true; // ȷ����ť����
            StartQuiz();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLimit--;
            labelTime.Text = $"ʣ��ʱ�䣺{timeLimit} ��";
            if (timeLimit <= 0)
            {
                labelFeedback.Text = "��ʱ��";
                labelFeedback.ForeColor = Color.Red;
                timer.Stop();
                Task.Delay(1000).ContinueWith(t => StartQuiz());
            }
        }
        private void EndQuiz()
        {
            timer.Stop();
            labelQuestion.Text = $"�÷֣�{score}/{totalQuestions}";
            labelFeedback.Text = "���Խ�����";
            labelFeedback.ForeColor = Color.Black;
            buttonRestart.Text = "���¿�ʼ";
            labelQuestionNumber.Text = $"�� {totalQuestions} ��";
            buttonSubmit.Enabled = false; // �����ύ��ť
        }
    }
}