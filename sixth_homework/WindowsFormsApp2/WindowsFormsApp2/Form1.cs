
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 当窗体加载时触发的事件
        }

        private void 添加学校ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开添加学校的窗体
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加学校时发生错误：" + ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 当ListView选中项发生变化时触发的事件
        }

        private void 学校展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.View = View.Details;

                // 清除现有的列并添加新的列
                listView1.Columns.Clear();
                listView1.Items.Clear();
                listView1.Groups.Clear();
                this.listView1.Columns.Add("学校名称", 120, HorizontalAlignment.Center);
                this.listView1.Columns.Add("地址", 120, HorizontalAlignment.Center);

                // 获取学校列表
                List<School> list = DatabaseHelper.GetSchoolsFromDatabase();

                // 将学校信息添加到 ListView
                foreach (var school in list)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = school.Name;
                    lvi.SubItems.Add(school.Address);
                    this.listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("展示学校信息时发生错误：" + ex.Message);
            }
        }

        private void 选择学校ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开选择学校的窗体
                Form3 form3 = new Form3();
                form3.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择学校时发生错误：" + ex.Message);
            }
        }

        private void 班级展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 清除现有的列和项
                listView1.Columns.Clear();
                listView1.Items.Clear();
                listView1.Groups.Clear();

                // 添加列
                this.listView1.Columns.Add("班级名称", 120, HorizontalAlignment.Center);

                // 获取学校列表
                List<School> schools = DatabaseHelper.GetSchoolsFromDatabase();

                // 为每个学校创建一个组
                foreach (var school in schools)
                {
                    ListViewGroup group = new ListViewGroup(school.Name, HorizontalAlignment.Left);
                    listView1.Groups.Add(group);

                    // 获取该学校的班级列表
                    List<Class> classes = DatabaseHelper.GetClassesBySchoolId(school.SchoolId);

                    // 将班级添加到对应的组中
                    foreach (var classObj in classes)
                    {
                        ListViewItem item = new ListViewItem(classObj.ClassName);
                        item.Group = group;
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("展示班级信息时发生错误：" + ex.Message);
            }
        }

        private void 添加学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开添加学生的窗体
                Form4 form4 = new Form4();
                form4.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加学生时发生错误：" + ex.Message);
            }
        }

        private void 学生展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.View = View.Details;
                listView1.Columns.Clear();
                listView1.Items.Clear();
                listView1.Groups.Clear();

                // 添加列
                this.listView1.Columns.Add("学生ID", 60, HorizontalAlignment.Center);
                this.listView1.Columns.Add("学生姓名", 120, HorizontalAlignment.Center);
                this.listView1.Columns.Add("年龄", 60, HorizontalAlignment.Center);
                this.listView1.Columns.Add("班级ID", 60, HorizontalAlignment.Center);

                // 获取所有班级
                List<Class> classes = DatabaseHelper.GetClassesFromDatabase();

                // 为每个班级创建一个组
                foreach (var classObj in classes)
                {
                    ListViewGroup group = new ListViewGroup(DatabaseHelper.GetSchoolById(classObj.SchoolId).Name + " " + classObj.ClassName, HorizontalAlignment.Left);
                    listView1.Groups.Add(group);

                    // 获取该班级的学生列表
                    List<Student> students = DatabaseHelper.GetStudentsByClassId(classObj.ClassId);

                    // 将学生添加到对应的组中
                    foreach (var student in students)
                    {
                        ListViewItem item = new ListViewItem(student.StudentId.ToString());
                        item.SubItems.Add(student.Name);
                        item.SubItems.Add(student.Age.ToString());
                        item.SubItems.Add(student.ClassId.ToString());
                        item.Group = group;
                        listView1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("展示学生信息时发生错误：" + ex.Message);
            }
        }

        private void 信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开信息修改的窗体
                Form5 form5 = new Form5();
                form5.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改信息时发生错误：" + ex.Message);
            }
        }

        private void 信息修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开信息修改的另一个窗体
                Form7 form7 = new Form7();
                form7.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改信息时发生错误：" + ex.Message);
            }
        }

        private void 信息修改ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                // 打开信息修改的另一个窗体
                Form6 form6 = new Form6();
                form6.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改信息时发生错误：" + ex.Message);
            }
        }

        private void 日志查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.View = View.Details;
                // 清除现有的列和项
                listView1.Columns.Clear();
                listView1.Items.Clear();

                // 添加列
                this.listView1.Columns.Add("操作", 500, HorizontalAlignment.Left);

                // 获取日志数据
                DataTable logs = DatabaseHelper.GetLogs();

                // 将日志信息添加到 ListView
                foreach (DataRow row in logs.Rows)
                {
                    ListViewItem lvi = new ListViewItem(row["Action"].ToString());
                    this.listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询日志时发生错误：" + ex.Message);
            }
        }
    }
}
