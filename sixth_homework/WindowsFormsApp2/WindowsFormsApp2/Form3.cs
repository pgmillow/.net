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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadSchoolsIntoComboBox();
        }

        // 加载学校列表到ComboBox
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

        // 当ComboBox的选中项发生变化时触发的事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 获取选中的学校名
                string selectedSchoolName = comboBox1.SelectedItem?.ToString();

                // 检查是否选中了学校
                if (string.IsNullOrEmpty(selectedSchoolName))
                {
                    MessageBox.Show("请选择一个学校");
                    return;
                }

                // 在这里处理选中的学校名
                MessageBox.Show($"选中的学校是: {selectedSchoolName}");
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("处理选中学校时发生错误：" + ex.Message);
            }
        }

        // 当Form3窗体加载时触发的事件
        private void Form3_Load(object sender, EventArgs e)
        {
            // 窗体加载时执行的初始化操作（如果有）
        }

        // 添加班级到数据库
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取选中的学校名
                string selectedSchoolName = comboBox1.SelectedItem?.ToString();

                // 检查是否选中了学校
                if (string.IsNullOrEmpty(selectedSchoolName))
                {
                    MessageBox.Show("请选择一个学校");
                    return;
                }

                // 从学校名获取学校ID
                List<School> schools = DatabaseHelper.GetSchoolsFromDatabase();
                School selectedSchool = schools.FirstOrDefault(s => s.Name == selectedSchoolName);

                if (selectedSchool == null)
                {
                    MessageBox.Show("未找到选中的学校");
                    return;
                }

                int schoolId = selectedSchool.SchoolId;

                // 创建新的班级对象并设置属性
                Class newClass = new Class
                {
                    ClassName = txtClassName.Text,
                    SchoolId = schoolId
                };

                // 检查班级名称是否为空
                if (string.IsNullOrWhiteSpace(newClass.ClassName))
                {
                    MessageBox.Show("班级名称不能为空！");
                    return;
                }

                // 添加班级到数据库
                DatabaseHelper.AddClass(newClass);

                MessageBox.Show("添加成功");

                // 关闭当前窗体
                this.Close();
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("添加班级时发生错误：" + ex.Message);
            }
        }

        // 当ComboBox的选中项发生变化时触发的另一个事件（可能是重复的事件处理器）
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 目前无操作
        }
    }
}