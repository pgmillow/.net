using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            TreeNode rootNode = new TreeNode("C:");
            rootNode.Tag = "C:\\"; // 设置根节点的 Tag
            treeView1.Nodes.Add(rootNode);
            LoadDirectories("C:\\", rootNode);
        }

        private void LoadDirectories(string path, TreeNode node)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    TreeNode newNode = new TreeNode(Path.GetFileName(dir))
                    {
                        Tag = dir // 将路径存储在节点的 Tag 属性中
                    };
                    node.Nodes.Add(newNode);
                    newNode.Nodes.Add(new TreeNode()); // 添加一个虚拟节点用于懒加载
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 忽略无法访问的目录
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载目录时发生错误: " + ex.Message);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            // 检查节点是否已经加载了子目录
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "" && node.Nodes[0].Tag == null)
            {
                node.Nodes.Clear();
                LoadDirectories(node.Tag.ToString(), node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = GetFullPath(e.Node);
            LoadFiles(selectedPath);
        }

        private string GetFullPath(TreeNode node)
        {
            string path = node.Tag.ToString();
            while (node.Parent != null)
            {
                node = node.Parent;
                path = Path.Combine(node.Tag.ToString(), path);
            }
            return path;
        }

        private void LoadFiles(string path)
        {
            listView1.Items.Clear();
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    listView1.Items.Add(new ListViewItem(Path.GetFileName(dir)) { Tag = dir });
                }
                foreach (var file in Directory.GetFiles(path))
                {
                    listView1.Items.Add(new ListViewItem(Path.GetFileName(file)) { Tag = file });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载文件时发生错误: " + ex.Message);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedFilePath = listView1.SelectedItems[0].Tag.ToString();
                if (File.Exists(selectedFilePath))
                {
                    string extension = Path.GetExtension(selectedFilePath).ToLower();
                    try
                    {
                        if (extension == ".exe")
                        {
                            Process.Start(selectedFilePath);
                        }
                        else if (extension == ".txt")
                        {
                            Process.Start("notepad.exe", selectedFilePath);
                        }
                        else
                        {
                            // 对于其他文件类型，可以添加相应的处理
                            Process.Start(selectedFilePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打开文件时发生错误: " + ex.Message);
                    }
                }
                else if (Directory.Exists(selectedFilePath))
                {
                    // 如果双击的是文件夹，加载该文件夹的内容
                    LoadFiles(selectedFilePath);
                }
            }
        }
    }
}
