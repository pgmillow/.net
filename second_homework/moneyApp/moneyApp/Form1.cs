using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace moneyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize components if needed
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                if (DatabaseHelper.UserExists(username, out string storedPassword))
                {
                    if (storedPassword == password)
                    {
                        lblMessage.Text = "登录成功！";
                        OpenForm2(username);
                    }
                    else
                    {
                        lblMessage.Text = "密码错误！";
                    }
                }
                else
                {
                    DatabaseHelper.CreateUser(username, password);
                    lblMessage.Text = "账户创建成功并已登录！";
                    OpenForm2(username);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "发生错误：" + ex.Message;
            }
        }

        private void OpenForm2(string username)
        {
            Form2 form2 = new Form2(username);
            form2.Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            // 处理文本更改事件
        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
