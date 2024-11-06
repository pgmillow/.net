using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form6 : Form
    {
        public string NewStudentName { get; private set; }
        public string NewStudentAge { get; private set; }

        public Form6()
        {
            InitializeComponent();
            LoadSchools();  // 初始加载学校列表
        }

        // 当Form6窗体加载时触发的事件
        private void Form6_Load(object sender, EventArgs e)
        {
            // 如果需要窗体加载时的额外操作可以在这里做
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
                // 清空班级、学生选择和文本框
                comboBoxClass.Items.Clear();
                comboBoxStudent.Items.Clear();
                textBoxName.Clear();
                textBoxAge.Clear();

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

        // 班级选择发生改变时，加载相应的学生列表
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 清空学生选择和文本框
                comboBoxStudent.Items.Clear();
                textBoxName.Clear();
                textBoxAge.Clear();

                Class selectedClass = comboBoxClass.SelectedItem as Class;
                if (selectedClass != null)
                {
                    LoadStudents(selectedClass.ClassId);  // 加载学生列表
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学生列表时发生错误：" + ex.Message);
            }
        }

        // 加载学生列表
        private void LoadStudents(int classId)
        {
            try
            {
                List<Student> students = DatabaseHelper.GetStudentsByClassId(classId);
                comboBoxStudent.Items.Clear();
                comboBoxStudent.DisplayMember = "Name";
                comboBoxStudent.ValueMember = "StudentId";
                foreach (var student in students)
                {
                    comboBoxStudent.Items.Add(student);
                }
                comboBoxStudent.SelectedIndex = -1;  // 清空默认选择
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载学生列表时发生错误：" + ex.Message);
            }
        }

        // 学生选择发生改变时，显示学生的详细信息
        private void comboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            Student selectedStudent = comboBoxStudent.SelectedItem as Student;
            if (selectedStudent != null)
            {
                textBoxName.Text = selectedStudent.Name;
                textBoxAge.Text = selectedStudent.Age.ToString();
            }
            else
            {
                textBoxName.Clear();
                textBoxAge.Clear();
            }
        }

        // 点击按钮保存学生信息
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxName.Text) || !int.TryParse(textBoxAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("请输入有效的姓名和年龄。");
                    return;
                }

                NewStudentName = textBoxName.Text;
                NewStudentAge = textBoxAge.Text;

                Student selectedStudent = comboBoxStudent.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    DatabaseHelper.UpdateStudentInfo(selectedStudent.StudentId, NewStudentName, NewStudentAge);
                    MessageBox.Show("学生信息更新成功。");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请选择一个学生。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新学生信息时发生错误：" + ex.Message);
            }
        }

        // 删除学生
        private void BtnDeleteClass_Click(object sender, EventArgs e)
        {
            try
            {
                Student selectedStudent = comboBoxStudent.SelectedItem as Student;
                if (selectedStudent != null)
                {
                    DatabaseHelper.DeleteStudent(selectedStudent.StudentId);
                    MessageBox.Show("学生已删除！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请选择一个学生。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除学生时发生错误：" + ex.Message);
            }
        }
    }
}