using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form7 : Form
    {
        public string NewClassName { get; private set; }

        public Form7()
        {
            InitializeComponent();
            LoadSchools();  // 初始加载学校列表
        }

        // 加载学校列表
        private void LoadSchools()
        {
            try
            {
                List<School> schools = DatabaseHelper.GetSchoolsFromDatabase();
                comboBoxSchool.Items.Clear();
                comboBoxSchool.DisplayMember = "Name";
                comboBoxSchool.ValueMember = "SchoolId";
                foreach (var school in schools)
                {
                    comboBoxSchool.Items.Add(school);
                }
                comboBoxSchool.SelectedIndex = -1; // 清空默认选择
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学校列表时发生错误：" + ex.Message);
            }
        }

        // 学校选择发生改变时，加载相应的班级列表
        private void comboBoxSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 清空班级选择和文本框
                comboBoxClass.Items.Clear();
                textBoxName.Clear();

                School selectedSchool = comboBoxSchool.SelectedItem as School;
                if (selectedSchool != null)
                {
                    LoadClasses(selectedSchool.SchoolId);  // 加载班级列表
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载班级列表时发生错误：" + ex.Message);
            }
        }

        // 加载班级列表
        private void LoadClasses(int schoolId)
        {
            try
            {
                List<Class> classes = DatabaseHelper.GetClassesBySchoolId(schoolId);
                comboBoxClass.Items.Clear();
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ClassId";
                foreach (var classObj in classes)
                {
                    comboBoxClass.Items.Add(classObj);
                }
                comboBoxClass.SelectedIndex = -1;  // 清空默认选择
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载班级列表时发生错误：" + ex.Message);
            }
        }

        // label4的点击事件处理
        private void label4_Click(object sender, EventArgs e)
        {
            // 处理 label4 的点击事件
        }

        // Form7的加载事件处理
        private void Form7_Load(object sender, EventArgs e)
        {
            // 处理 Form7 的加载事件
        }

        // 更新班级名称
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxClass.SelectedItem == null || string.IsNullOrEmpty(textBoxName.Text))
                {
                    MessageBox.Show("请选择一个班级并输入新的班级名称。");
                    return;
                }

                Class selectedClass = comboBoxClass.SelectedItem as Class;
                if (selectedClass != null)
                {
                    NewClassName = textBoxName.Text;
                    DatabaseHelper.UpdateClass(selectedClass.ClassId, NewClassName);
                    MessageBox.Show("班级名称已更新");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新班级名称时发生错误：" + ex.Message);
            }
        }

        // 班级选择发生改变时的事件处理
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 此事件处理程序可以留空，或者添加其他逻辑
        }

        // 删除班级
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Class selectedClass = comboBoxClass.SelectedItem as Class;
                if (selectedClass == null)
                {
                    MessageBox.Show("请选择一个班级。");
                    return;
                }
                else
                {
                    DatabaseHelper.DeleteClass(selectedClass.ClassId);
                    MessageBox.Show("班级已删除！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除班级时发生错误：" + ex.Message);
            }
        }
    }
}