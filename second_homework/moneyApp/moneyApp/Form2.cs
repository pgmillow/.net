using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace moneyApp
{
    public class Form2 : Form
    {
        public Form2(String username)
        {
            InitializeComponent();
            this.username = username;
        }
        private String username;
        private Label lbUsername;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private Button button2;
        private Button button3;
        private Label balancelabel;
        private Label Creditlb;
        private TextBox AmmounttextBox;
        private TextBox passwordtextBox;
        private Button Depositbutton;
        private Button Withdrawbutton;
        private Button Exitbutton;
        private Button exitbutton;
        private Button button1;
        private void InitializeComponent()
        {
            lbUsername = new Label();
            balancelabel = new Label();
            Creditlb = new Label();
            AmmounttextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            passwordtextBox = new TextBox();
            Depositbutton = new Button();
            Withdrawbutton = new Button();
            exitbutton = new Button();
            SuspendLayout();
            lbUsername.AutoSize = true;
            lbUsername.Location = new Point(81, 35);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(82, 24);
            lbUsername.TabIndex = 0;
            lbUsername.Text = "用户名：";
            lbUsername.Click += label1_Click;
            balancelabel.AutoSize = true;
            balancelabel.Location = new Point(427, 35);
            balancelabel.Name = "balancelabel";
            balancelabel.Size = new Size(118, 24);
            balancelabel.TabIndex = 1;
            balancelabel.Text = "余额（元）：";
            Creditlb.AutoSize = true;
            Creditlb.Location = new Point(740, 35);
            Creditlb.Name = "Creditlb";
            Creditlb.Size = new Size(154, 24);
            Creditlb.TabIndex = 2;
            Creditlb.Text = "信用额度（元）：";
            AmmounttextBox.Location = new Point(321, 170);
            AmmounttextBox.Name = "AmmounttextBox";
            AmmounttextBox.Size = new Size(340, 30);
            AmmounttextBox.TabIndex = 3;
            label3.AutoSize = true;
            label3.Location = new Point(220, 171);
            label3.Name = "label3";
            label3.Size = new Size(100, 24);
            label3.TabIndex = 4;
            label3.Text = "金额（元）";
            label4.AutoSize = true;
            label4.Location = new Point(220, 262);
            label4.Name = "label4";
            label4.Size = new Size(46, 24);
            label4.TabIndex = 6;
            label4.Text = "密码";
            passwordtextBox.Location = new Point(321, 261);
            passwordtextBox.Name = "passwordtextBox";
            passwordtextBox.Size = new Size(340, 30);
            passwordtextBox.TabIndex = 5;
            Depositbutton.BackColor = Color.PaleGreen;
            Depositbutton.Location = new Point(71, 392);
            Depositbutton.Name = "Depositbutton";
            Depositbutton.Size = new Size(112, 34);
            Depositbutton.TabIndex = 7;
            Depositbutton.Text = "存";
            Depositbutton.UseVisualStyleBackColor = false;
            Depositbutton.Click += Depositbutton_Click;
            Withdrawbutton.BackColor = SystemColors.ActiveCaption;
            Withdrawbutton.Location = new Point(427, 392);
            Withdrawbutton.Name = "Withdrawbutton";
            Withdrawbutton.Size = new Size(112, 34);
            Withdrawbutton.TabIndex = 8;
            Withdrawbutton.Text = "取";
            Withdrawbutton.UseVisualStyleBackColor = false;
            Withdrawbutton.Click += Withdrawbutton_Click;
            exitbutton.BackColor = Color.Salmon;
            exitbutton.Location = new Point(779, 392);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(112, 34);
            exitbutton.TabIndex = 9;
            exitbutton.Text = "退出";
            exitbutton.UseVisualStyleBackColor = false;
            exitbutton.Click += exitbutton_Click;
            ClientSize = new Size(1044, 564);
            Controls.Add(exitbutton);
            Controls.Add(Withdrawbutton);
            Controls.Add(Depositbutton);
            Controls.Add(label4);
            Controls.Add(passwordtextBox);
            Controls.Add(label3);
            Controls.Add(AmmounttextBox);
            Controls.Add(Creditlb);
            Controls.Add(balancelabel);
            Controls.Add(lbUsername);
            Name = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private void Exitbutton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Account newAccount = DatabaseHelper.GetAccountByUsername(username);
            lbUsername.Text += newAccount.Username;
            balancelabel.Text += newAccount.Balance;
            if (newAccount.CreditLimit == 0)
            {
                Creditlb.Text = "您不是信用卡客户";
            }
            else
            {
                Creditlb.Text = "信用额度(元）: " + newAccount.CreditLimit;
            }
        }
        private void exitbutton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void Depositbutton_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(AmmounttextBox.Text, out amount) && amount > 0)
            {
                Account account = DatabaseHelper.GetAccountByUsername(username);
                try
                {
                    account.Deposit(amount);
                    balancelabel.Text = "余额（元）：" + account.Balance; // 更新余额显示
                    DatabaseHelper.UpdateAccount(account); // 更新数据库
                    MessageBox.Show("存款成功！");
                }
                catch (BadCashException ex)
                {
                    MessageBox.Show(ex.Message); // 显示坏钞消息
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message); // 显示其他错误消息
                }
            }
            else
            {
                MessageBox.Show("请输入有效的存款金额！");
            }
            ClearTextBoxes();
        }
        private void Withdrawbutton_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(AmmounttextBox.Text, out amount) && amount > 0)
            {
                Account account = DatabaseHelper.GetAccountByUsername(username);
                try
                {
                    account.Withdraw(amount);
                    balancelabel.Text = "余额（元）：" + account.Balance; // 更新余额显示
                    DatabaseHelper.UpdateAccount(account); // 更新数据库（需要实现此方法）
                    MessageBox.Show("取款成功！");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message); // 显示错误消息
                }
            }
            else
            {
                MessageBox.Show("请输入有效的取款金额！");
            }
            ClearTextBoxes();
        }
        private void AmmounttextBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void ClearTextBoxes()
        {
            AmmounttextBox.Text = "";
            passwordtextBox.Text = "";
        }
    }
}