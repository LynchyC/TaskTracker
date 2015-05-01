namespace TaskTracker
{
    partial class taskTracker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.categoriesBox = new System.Windows.Forms.ComboBox();
            this.completedTaskListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTaskDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.delCategoryBtn = new System.Windows.Forms.Button();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.tasksTab = new System.Windows.Forms.TabControl();
            this.currenttabPage = new System.Windows.Forms.TabPage();
            this.currentTaskListBox = new System.Windows.Forms.ListBox();
            this.completedtabPage = new System.Windows.Forms.TabPage();
            this.contextMenuStrip.SuspendLayout();
            this.tasksTab.SuspendLayout();
            this.currenttabPage.SuspendLayout();
            this.completedtabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoriesBox
            // 
            this.categoriesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriesBox.FormattingEnabled = true;
            this.categoriesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.categoriesBox.Location = new System.Drawing.Point(15, 12);
            this.categoriesBox.Name = "categoriesBox";
            this.categoriesBox.Size = new System.Drawing.Size(121, 21);
            this.categoriesBox.TabIndex = 0;
            this.categoriesBox.SelectedIndexChanged += new System.EventHandler(this.TaskLoad);
            // 
            // completedTaskListBox
            // 
            this.completedTaskListBox.ContextMenuStrip = this.contextMenuStrip;
            this.completedTaskListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completedTaskListBox.FormattingEnabled = true;
            this.completedTaskListBox.Location = new System.Drawing.Point(3, 3);
            this.completedTaskListBox.Name = "completedTaskListBox";
            this.completedTaskListBox.Size = new System.Drawing.Size(189, 207);
            this.completedTaskListBox.TabIndex = 1;
            this.completedTaskListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.taskListMouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTaskDetailsToolStripMenuItem,
            this.deleteTaskToolStripMenuItem,
            this.c});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(194, 70);
            // 
            // openTaskDetailsToolStripMenuItem
            // 
            this.openTaskDetailsToolStripMenuItem.Name = "openTaskDetailsToolStripMenuItem";
            this.openTaskDetailsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openTaskDetailsToolStripMenuItem.Tag = "details";
            this.openTaskDetailsToolStripMenuItem.Text = "Open Task Details";
            // 
            // deleteTaskToolStripMenuItem
            // 
            this.deleteTaskToolStripMenuItem.Name = "deleteTaskToolStripMenuItem";
            this.deleteTaskToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.deleteTaskToolStripMenuItem.Tag = "del";
            this.deleteTaskToolStripMenuItem.Text = "Delete Task";
            this.deleteTaskToolStripMenuItem.Click += new System.EventHandler(this.delTaskClick);
            // 
            // c
            // 
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(193, 22);
            this.c.Tag = "complete";
            this.c.Text = "Set Task as Completed";
            this.c.Click += new System.EventHandler(this.taskStatus);
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.Location = new System.Drawing.Point(142, 11);
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(28, 23);
            this.addCategoryBtn.TabIndex = 2;
            this.addCategoryBtn.Text = "+";
            this.addCategoryBtn.UseVisualStyleBackColor = true;
            this.addCategoryBtn.Click += new System.EventHandler(this.AddCategoryBtn);
            // 
            // taskTextBox
            // 
            this.taskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taskTextBox.Location = new System.Drawing.Point(13, 296);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(121, 20);
            this.taskTextBox.TabIndex = 4;
            // 
            // delCategoryBtn
            // 
            this.delCategoryBtn.Location = new System.Drawing.Point(176, 11);
            this.delCategoryBtn.Name = "delCategoryBtn";
            this.delCategoryBtn.Size = new System.Drawing.Size(28, 23);
            this.delCategoryBtn.TabIndex = 5;
            this.delCategoryBtn.Text = "-";
            this.delCategoryBtn.UseVisualStyleBackColor = true;
            this.delCategoryBtn.Click += new System.EventHandler(this.DeleteCategoryBtn);
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addTaskBtn.Location = new System.Drawing.Point(140, 294);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.addTaskBtn.TabIndex = 6;
            this.addTaskBtn.Text = "Add Task";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.AddTaskBtn);
            // 
            // tasksTab
            // 
            this.tasksTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tasksTab.Controls.Add(this.currenttabPage);
            this.tasksTab.Controls.Add(this.completedtabPage);
            this.tasksTab.Location = new System.Drawing.Point(12, 40);
            this.tasksTab.Name = "tasksTab";
            this.tasksTab.SelectedIndex = 0;
            this.tasksTab.Size = new System.Drawing.Size(203, 239);
            this.tasksTab.TabIndex = 7;
            this.tasksTab.Tag = "";
            // 
            // currenttabPage
            // 
            this.currenttabPage.Controls.Add(this.currentTaskListBox);
            this.currenttabPage.Location = new System.Drawing.Point(4, 22);
            this.currenttabPage.Name = "currenttabPage";
            this.currenttabPage.Padding = new System.Windows.Forms.Padding(3);
            this.currenttabPage.Size = new System.Drawing.Size(195, 213);
            this.currenttabPage.TabIndex = 0;
            this.currenttabPage.Tag = "current";
            this.currenttabPage.Text = "Current Tasks";
            this.currenttabPage.UseVisualStyleBackColor = true;
            // 
            // currentTaskListBox
            // 
            this.currentTaskListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTaskListBox.FormattingEnabled = true;
            this.currentTaskListBox.Location = new System.Drawing.Point(3, 3);
            this.currentTaskListBox.Name = "currentTaskListBox";
            this.currentTaskListBox.Size = new System.Drawing.Size(189, 207);
            this.currentTaskListBox.TabIndex = 0;
            this.currentTaskListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.taskListMouseDown);
            // 
            // completedtabPage
            // 
            this.completedtabPage.Controls.Add(this.completedTaskListBox);
            this.completedtabPage.Location = new System.Drawing.Point(4, 22);
            this.completedtabPage.Name = "completedtabPage";
            this.completedtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completedtabPage.Size = new System.Drawing.Size(195, 213);
            this.completedtabPage.TabIndex = 1;
            this.completedtabPage.Tag = "completed";
            this.completedtabPage.Text = "Completed Tasks";
            this.completedtabPage.UseVisualStyleBackColor = true;
            // 
            // taskTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 328);
            this.Controls.Add(this.tasksTab);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.delCategoryBtn);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.addCategoryBtn);
            this.Controls.Add(this.categoriesBox);
            this.MinimumSize = new System.Drawing.Size(249, 366);
            this.Name = "taskTracker";
            this.Text = "Task Tracker";
            this.Load += new System.EventHandler(this.FormLoad);
            this.SizeChanged += new System.EventHandler(this.windowSize);
            this.contextMenuStrip.ResumeLayout(false);
            this.tasksTab.ResumeLayout(false);
            this.currenttabPage.ResumeLayout(false);
            this.completedtabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoriesBox;
        private System.Windows.Forms.ListBox completedTaskListBox;
        private System.Windows.Forms.Button addCategoryBtn;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button delCategoryBtn;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openTaskDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c;
        private System.Windows.Forms.TabControl tasksTab;
        private System.Windows.Forms.TabPage currenttabPage;
        private System.Windows.Forms.TabPage completedtabPage;
        private System.Windows.Forms.ListBox currentTaskListBox;
    }
}

