namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.学校管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加学校ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学校展示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择学校ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级展示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息修改ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.学生管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加学生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生展示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.信息修改ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.日志查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学校管理ToolStripMenuItem,
            this.班级管理ToolStripMenuItem,
            this.学生管理ToolStripMenuItem,
            this.日志查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 学校管理ToolStripMenuItem
            // 
            this.学校管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加学校ToolStripMenuItem,
            this.学校展示ToolStripMenuItem,
            this.信息修改ToolStripMenuItem});
            this.学校管理ToolStripMenuItem.Name = "学校管理ToolStripMenuItem";
            this.学校管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.学校管理ToolStripMenuItem.Text = "学校管理";
            // 
            // 添加学校ToolStripMenuItem
            // 
            this.添加学校ToolStripMenuItem.Name = "添加学校ToolStripMenuItem";
            this.添加学校ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.添加学校ToolStripMenuItem.Text = "添加学校";
            this.添加学校ToolStripMenuItem.Click += new System.EventHandler(this.添加学校ToolStripMenuItem_Click);
            // 
            // 学校展示ToolStripMenuItem
            // 
            this.学校展示ToolStripMenuItem.Name = "学校展示ToolStripMenuItem";
            this.学校展示ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.学校展示ToolStripMenuItem.Text = "学校展示";
            this.学校展示ToolStripMenuItem.Click += new System.EventHandler(this.学校展示ToolStripMenuItem_Click);
            // 
            // 信息修改ToolStripMenuItem
            // 
            this.信息修改ToolStripMenuItem.Name = "信息修改ToolStripMenuItem";
            this.信息修改ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.信息修改ToolStripMenuItem.Text = "信息修改";
            this.信息修改ToolStripMenuItem.Click += new System.EventHandler(this.信息修改ToolStripMenuItem_Click);
            // 
            // 班级管理ToolStripMenuItem
            // 
            this.班级管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择学校ToolStripMenuItem,
            this.班级展示ToolStripMenuItem,
            this.信息修改ToolStripMenuItem1});
            this.班级管理ToolStripMenuItem.Name = "班级管理ToolStripMenuItem";
            this.班级管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.班级管理ToolStripMenuItem.Text = "班级管理";
            // 
            // 选择学校ToolStripMenuItem
            // 
            this.选择学校ToolStripMenuItem.Name = "选择学校ToolStripMenuItem";
            this.选择学校ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.选择学校ToolStripMenuItem.Text = "添加班级";
            this.选择学校ToolStripMenuItem.Click += new System.EventHandler(this.选择学校ToolStripMenuItem_Click);
            // 
            // 班级展示ToolStripMenuItem
            // 
            this.班级展示ToolStripMenuItem.Name = "班级展示ToolStripMenuItem";
            this.班级展示ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.班级展示ToolStripMenuItem.Text = "班级展示";
            this.班级展示ToolStripMenuItem.Click += new System.EventHandler(this.班级展示ToolStripMenuItem_Click);
            // 
            // 信息修改ToolStripMenuItem1
            // 
            this.信息修改ToolStripMenuItem1.Name = "信息修改ToolStripMenuItem1";
            this.信息修改ToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.信息修改ToolStripMenuItem1.Text = "信息修改";
            this.信息修改ToolStripMenuItem1.Click += new System.EventHandler(this.信息修改ToolStripMenuItem1_Click);
            // 
            // 学生管理ToolStripMenuItem
            // 
            this.学生管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加学生ToolStripMenuItem,
            this.学生展示ToolStripMenuItem,
            this.信息修改ToolStripMenuItem2});
            this.学生管理ToolStripMenuItem.Name = "学生管理ToolStripMenuItem";
            this.学生管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.学生管理ToolStripMenuItem.Text = "学生管理";
            // 
            // 添加学生ToolStripMenuItem
            // 
            this.添加学生ToolStripMenuItem.Name = "添加学生ToolStripMenuItem";
            this.添加学生ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.添加学生ToolStripMenuItem.Text = "添加学生";
            this.添加学生ToolStripMenuItem.Click += new System.EventHandler(this.添加学生ToolStripMenuItem_Click);
            // 
            // 学生展示ToolStripMenuItem
            // 
            this.学生展示ToolStripMenuItem.Name = "学生展示ToolStripMenuItem";
            this.学生展示ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.学生展示ToolStripMenuItem.Text = "学生展示";
            this.学生展示ToolStripMenuItem.Click += new System.EventHandler(this.学生展示ToolStripMenuItem_Click);
            // 
            // 信息修改ToolStripMenuItem2
            // 
            this.信息修改ToolStripMenuItem2.Name = "信息修改ToolStripMenuItem2";
            this.信息修改ToolStripMenuItem2.Size = new System.Drawing.Size(270, 34);
            this.信息修改ToolStripMenuItem2.Text = "信息修改";
            this.信息修改ToolStripMenuItem2.Click += new System.EventHandler(this.信息修改ToolStripMenuItem2_Click);
            // 
            // 日志查询ToolStripMenuItem
            // 
            this.日志查询ToolStripMenuItem.Name = "日志查询ToolStripMenuItem";
            this.日志查询ToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.日志查询ToolStripMenuItem.Text = "日志查询";
            this.日志查询ToolStripMenuItem.Click += new System.EventHandler(this.日志查询ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(835, 615);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 662);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 学校管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生管理ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 日志查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加学校ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学校展示ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem 选择学校ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级展示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加学生ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生展示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 信息修改ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 信息修改ToolStripMenuItem2;
    }
}

