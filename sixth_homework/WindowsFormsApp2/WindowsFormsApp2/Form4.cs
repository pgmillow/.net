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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // 当Form4窗体加载时触发的事件
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                // 获取所有班级并填充到 ComboBox
                List<Class> classes = DatabaseHelper.GetClassesFromDatabase();
                foreach (var classObj in classes)
                {
                    // 获取学校名称
                    School school = DatabaseHelper.GetSchoolById(classObj.SchoolId);
                    if (school != null)
                    {
                        string schoolName = school.Name;

                        // 创建组合信息
                        string displayText = $"学校：{schoolName} 班级：{classObj.ClassName}";

                        comboBox1.Items.Add(new ComboBoxItem(displayText, classObj.ClassId, schoolId: classObj.SchoolId));
                    }
                    else
                    {
                        // 处理找不到学校的情况
                        string displayText = $"***Unknown School ***{classObj.ClassName}";
                        comboBox1.Items.Add(new ComboBoxItem(displayText, classObj.ClassId, schoolId: classObj.SchoolId));
                    }
                }
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("加载班级列表时发生错误：" + ex.Message);
            }
        }

        // 当label1被点击时触发的事件
        private void label1_Click(object sender, EventArgs e)
        {
            // 目前无操作
        }

        // 添加学生信息到数据库
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取输入的学生信息
                string studentName = txtStudentName.Text;
                if (string.IsNullOrWhiteSpace(studentName))
                {
                    MessageBox.Show("学生姓名不能为空！");
                    return;
                }

                ComboBoxItem selectedClass = comboBox1.SelectedItem as ComboBoxItem;
                if (selectedClass == null)
                {
                    MessageBox.Show("请选择一个班级！");
                    return;
                }

                int classId = selectedClass.Value;
                int age;
                if (!int.TryParse(txtAge.Text, out age) || age <= 0)
                {
                    MessageBox.Show("请输入有效的年龄！");
                    return;
                }

                // 创建新的学生对象
                Student newStudent = new Student
                {
                    Name = studentName,
                    ClassId = classId,
                    Age = age
                };

                // 添加学生到数据库
                DatabaseHelper.AddStudent(newStudent);

                MessageBox.Show("学生添加成功");

                // 关闭当前窗体
                this.Close();
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("添加学生时发生错误：" + ex.Message);
            }
        }

        // 当ComboBox的选中项发生变化时触发的事件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 获取选中的班级
                ComboBoxItem selectedClass = (ComboBoxItem)comboBox1.SelectedItem;
                if (selectedClass == null)
                {
                    return;
                }

                // 获取学校ID
                int selectedSchoolId = selectedClass.SchoolId;

                // 获取学校名称
                School selectedSchool = DatabaseHelper.GetSchoolById(selectedSchoolId);
                if (selectedSchool != null)
                {
                    string schoolName = selectedSchool.Name;

                    // 输出格式为 "***学校 ***班"
                    MessageBox.Show($"***{schoolName} ***{selectedClass.Text}");
                }
                else
                {
                    MessageBox.Show("未找到选中的班级对应的学校");
                }
            }
            catch (Exception ex)
            {
                // 显示错误消息
                MessageBox.Show("处理班级选择时发生错误：" + ex.Message);
            }
        }
    }

    // ComboBoxItem类用于存储ComboBox中的项目
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public int SchoolId { get; set; }

        public ComboBoxItem(string text, int value, int schoolId)
        {
            Text = text;
            Value = value;
            SchoolId = schoolId;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}