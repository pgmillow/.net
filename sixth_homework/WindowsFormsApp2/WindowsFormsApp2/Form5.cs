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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            LoadSchoolsIntoComboBox();
        }

        // 在构造函数中调用，用于初始化ComboBox中的学校列表
        private void LoadSchoolsIntoComboBox()
        {
            try
            {
                // 获取学校列表
                List<School> schools = DatabaseHelper.GetSchoolsFromDatabase();

                // 将学校名添加到 ComboBox
                foreach (var school in schools)
                {
                    comboBox1.Items.Add(school.Name);
                }
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("加载学校列表时发生错误：" + ex.Message);
            }
        }

        // 当Form5窗体加载时触发的事件
        private void Form5_Load(object sender, EventArgs e)
        {
            // 窗体加载时执行的初始化操作（如果有）
        }

        // 更新学校信息的按钮点击事件
        private void buttonUpdateSchool_Click(object sender, EventArgs e)
        {
            // 获取选中的学校名称
            string selectedSchoolName = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedSchoolName))
            {
                MessageBox.Show("请选择一个学校。");
                return;
            }

            // 获取新名称和新信息
            string newName = textBoxNewName.Text;
            string newInfo = textBoxNewInfo.Text;

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newInfo))
            {
                MessageBox.Show("请输入新名称和新信息。");
                return;
            }

            // 更新学校信息
            try
            {
                DatabaseHelper.UpdateSchoolInfo(selectedSchoolName, newName, newInfo);
                MessageBox.Show("学校信息更新成功。");
                this.Close();
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("学校信息更新失败: " + ex.Message);
            }
        }

        // 删除学校班级的按钮点击事件
        private void BtnDeleteClass_Click(object sender, EventArgs e)
        {
            // 获取选中的学校对象
            School school = comboBox1.SelectedItem as School;
            if (school == null)
            {
                MessageBox.Show("请选择一个学校。");
                return;
            }

            try
            {
                // 删除学校
                DatabaseHelper.DeleteSchool(school.SchoolId);
                MessageBox.Show("学校已删除！");
                this.Close();
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("删除学校失败: " + ex.Message);
            }
        }
    }
}