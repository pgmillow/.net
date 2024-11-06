using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // 当label1被点击时触发的事件
        private void label1_Click(object sender, EventArgs e)
        {
            // 目前无操作
        }

        // 当按钮1被点击时触发的事件，用于添加学校信息到数据库
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 从文本框获取学校名称和地址
                string schoolName = txtSchoolName.Text;
                string address = txtAddress.Text;

                // 检查学校名称和地址是否为空
                if (string.IsNullOrWhiteSpace(schoolName) || string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show("学校名称和地址不能为空！");
                    return;
                }

                // 调用数据库帮助类创建学校
                DatabaseHelper.CreateSchool(schoolName, address);
                MessageBox.Show("添加成功");

                // 关闭当前窗体
                this.Close();
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("添加学校时发生错误：" + ex.Message);
            }
        }

        // 当文本框1的内容发生变化时触发的事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        // 当label4被点击时触发的事件
        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        // 当Form2窗体加载时触发的事件
        private void Form2_Load(object sender, EventArgs e)
        {
            // 窗体加载时执行的初始化操作（如果有）
        }
    }
}