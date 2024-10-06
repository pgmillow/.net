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
                        lblMessage.Text = "��¼�ɹ���";
                        OpenForm2(username);
                    }
                    else
                    {
                        lblMessage.Text = "�������";
                    }
                }
                else
                {
                    DatabaseHelper.CreateUser(username, password);
                    lblMessage.Text = "�˻������ɹ����ѵ�¼��";
                    OpenForm2(username);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "��������" + ex.Message;
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
            // �����ı������¼�
        }

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
