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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(taskTracker));
            this.categoriesBox = new System.Windows.Forms.ComboBox();
            this.completedTaskListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTaskDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c = new System.Windows.Forms.ToolStripMenuItem();
            this.addTaskTextBox = new System.Windows.Forms.TextBox();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.tasksTab = new System.Windows.Forms.TabControl();
            this.currenttabPage = new System.Windows.Forms.TabPage();
            this.currentTaskListBox = new System.Windows.Forms.ListBox();
            this.completedtabPage = new System.Windows.Forms.TabPage();
            this.taskNamelbl = new System.Windows.Forms.Label();
            this.taskNametextBox = new System.Windows.Forms.TextBox();
            this.taskBodyTextBox = new System.Windows.Forms.RichTextBox();
            this.saveLbl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addCatImgBtn = new System.Windows.Forms.PictureBox();
            this.delCatImgBtn = new System.Windows.Forms.PictureBox();
            this.currentRadioButton = new System.Windows.Forms.RadioButton();
            this.completedRadioButton = new System.Windows.Forms.RadioButton();
            this.saveBtn = new System.Windows.Forms.Button();
            this.taskNameLabel = new System.Windows.Forms.Label();
            this.taskBodyLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.miniModeBtn = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.tasksTab.SuspendLayout();
            this.currenttabPage.SuspendLayout();
            this.completedtabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addCatImgBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delCatImgBtn)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // categoriesBox
            // 
            this.categoriesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriesBox.FormattingEnabled = true;
            this.categoriesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.categoriesBox.Location = new System.Drawing.Point(12, 27);
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
            this.completedTaskListBox.Size = new System.Drawing.Size(189, 469);
            this.completedTaskListBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.completedTaskListBox, "List of completed tasks");
            this.completedTaskListBox.Click += new System.EventHandler(this.LoadTaskDetails);
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
            this.openTaskDetailsToolStripMenuItem.Click += new System.EventHandler(this.LoadTaskDetails);
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
            // addTaskTextBox
            // 
            this.addTaskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addTaskTextBox.Location = new System.Drawing.Point(13, 593);
            this.addTaskTextBox.Name = "addTaskTextBox";
            this.addTaskTextBox.Size = new System.Drawing.Size(121, 20);
            this.addTaskTextBox.TabIndex = 4;
            this.addTaskTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // addTaskBtn
            // 
            this.addTaskBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addTaskBtn.Location = new System.Drawing.Point(140, 591);
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
            this.tasksTab.Location = new System.Drawing.Point(12, 70);
            this.tasksTab.Name = "tasksTab";
            this.tasksTab.SelectedIndex = 0;
            this.tasksTab.Size = new System.Drawing.Size(203, 501);
            this.tasksTab.TabIndex = 7;
            this.tasksTab.Tag = "";
            this.tasksTab.SelectedIndexChanged += new System.EventHandler(this.TabChange);
            // 
            // currenttabPage
            // 
            this.currenttabPage.Controls.Add(this.currentTaskListBox);
            this.currenttabPage.Location = new System.Drawing.Point(4, 22);
            this.currenttabPage.Name = "currenttabPage";
            this.currenttabPage.Padding = new System.Windows.Forms.Padding(3);
            this.currenttabPage.Size = new System.Drawing.Size(195, 475);
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
            this.currentTaskListBox.Size = new System.Drawing.Size(189, 469);
            this.currentTaskListBox.TabIndex = 0;
            this.toolTip.SetToolTip(this.currentTaskListBox, "List of current tasks");
            this.currentTaskListBox.Click += new System.EventHandler(this.LoadTaskDetails);
            this.currentTaskListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.taskListMouseDown);
            // 
            // completedtabPage
            // 
            this.completedtabPage.Controls.Add(this.completedTaskListBox);
            this.completedtabPage.Location = new System.Drawing.Point(4, 22);
            this.completedtabPage.Name = "completedtabPage";
            this.completedtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.completedtabPage.Size = new System.Drawing.Size(195, 475);
            this.completedtabPage.TabIndex = 1;
            this.completedtabPage.Tag = "completed";
            this.completedtabPage.Text = "Completed Tasks";
            this.completedtabPage.UseVisualStyleBackColor = true;
            // 
            // taskNamelbl
            // 
            this.taskNamelbl.AutoSize = true;
            this.taskNamelbl.Location = new System.Drawing.Point(251, 33);
            this.taskNamelbl.Name = "taskNamelbl";
            this.taskNamelbl.Size = new System.Drawing.Size(65, 13);
            this.taskNamelbl.TabIndex = 8;
            this.taskNamelbl.Text = "Task Name:";
            this.taskNamelbl.Visible = false;
            // 
            // taskNametextBox
            // 
            this.taskNametextBox.Location = new System.Drawing.Point(322, 30);
            this.taskNametextBox.Name = "taskNametextBox";
            this.taskNametextBox.ReadOnly = true;
            this.taskNametextBox.Size = new System.Drawing.Size(162, 20);
            this.taskNametextBox.TabIndex = 9;
            this.taskNametextBox.Visible = false;
            // 
            // taskBodyTextBox
            // 
            this.taskBodyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskBodyTextBox.Location = new System.Drawing.Point(257, 92);
            this.taskBodyTextBox.Name = "taskBodyTextBox";
            this.taskBodyTextBox.Size = new System.Drawing.Size(564, 477);
            this.taskBodyTextBox.TabIndex = 10;
            this.taskBodyTextBox.Text = "";
            this.taskBodyTextBox.Visible = false;
            // 
            // saveLbl
            // 
            this.saveLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveLbl.AutoSize = true;
            this.saveLbl.Location = new System.Drawing.Point(737, 596);
            this.saveLbl.Name = "saveLbl";
            this.saveLbl.Size = new System.Drawing.Size(82, 13);
            this.saveLbl.TabIndex = 12;
            this.saveLbl.Text = "Progress Saved";
            this.saveLbl.Visible = false;
            // 
            // addCatImgBtn
            // 
            this.addCatImgBtn.Image = ((System.Drawing.Image)(resources.GetObject("addCatImgBtn.Image")));
            this.addCatImgBtn.Location = new System.Drawing.Point(145, 24);
            this.addCatImgBtn.Name = "addCatImgBtn";
            this.addCatImgBtn.Size = new System.Drawing.Size(25, 24);
            this.addCatImgBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addCatImgBtn.TabIndex = 14;
            this.addCatImgBtn.TabStop = false;
            this.toolTip.SetToolTip(this.addCatImgBtn, "Add a new Category");
            this.addCatImgBtn.Click += new System.EventHandler(this.AddCategoryBtn);
            this.addCatImgBtn.MouseLeave += new System.EventHandler(this.UnBevelImage);
            this.addCatImgBtn.MouseHover += new System.EventHandler(this.BevelImage);
            // 
            // delCatImgBtn
            // 
            this.delCatImgBtn.Image = ((System.Drawing.Image)(resources.GetObject("delCatImgBtn.Image")));
            this.delCatImgBtn.Location = new System.Drawing.Point(187, 24);
            this.delCatImgBtn.Name = "delCatImgBtn";
            this.delCatImgBtn.Size = new System.Drawing.Size(25, 24);
            this.delCatImgBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delCatImgBtn.TabIndex = 15;
            this.delCatImgBtn.TabStop = false;
            this.toolTip.SetToolTip(this.delCatImgBtn, "Delete currently selected Category");
            this.delCatImgBtn.Click += new System.EventHandler(this.DeleteCategoryBtn);
            this.delCatImgBtn.MouseLeave += new System.EventHandler(this.UnBevelImage);
            this.delCatImgBtn.MouseHover += new System.EventHandler(this.BevelImage);
            // 
            // currentRadioButton
            // 
            this.currentRadioButton.AutoSize = true;
            this.currentRadioButton.Location = new System.Drawing.Point(544, 31);
            this.currentRadioButton.Name = "currentRadioButton";
            this.currentRadioButton.Size = new System.Drawing.Size(59, 17);
            this.currentRadioButton.TabIndex = 16;
            this.currentRadioButton.TabStop = true;
            this.currentRadioButton.Text = "Current";
            this.currentRadioButton.UseVisualStyleBackColor = true;
            this.currentRadioButton.Visible = false;
            // 
            // completedRadioButton
            // 
            this.completedRadioButton.AutoSize = true;
            this.completedRadioButton.Location = new System.Drawing.Point(609, 31);
            this.completedRadioButton.Name = "completedRadioButton";
            this.completedRadioButton.Size = new System.Drawing.Size(75, 17);
            this.completedRadioButton.TabIndex = 17;
            this.completedRadioButton.TabStop = true;
            this.completedRadioButton.Text = "Completed";
            this.completedRadioButton.UseVisualStyleBackColor = true;
            this.completedRadioButton.Visible = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(690, 28);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(60, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Visible = false;
            this.saveBtn.Click += new System.EventHandler(this.saveChanges);
            // 
            // taskNameLabel
            // 
            this.taskNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.taskNameLabel.AutoSize = true;
            this.taskNameLabel.Location = new System.Drawing.Point(13, 577);
            this.taskNameLabel.Name = "taskNameLabel";
            this.taskNameLabel.Size = new System.Drawing.Size(90, 13);
            this.taskNameLabel.TabIndex = 19;
            this.taskNameLabel.Text = "New Task Name:";
            // 
            // taskBodyLbl
            // 
            this.taskBodyLbl.AutoSize = true;
            this.taskBodyLbl.Location = new System.Drawing.Point(254, 70);
            this.taskBodyLbl.Name = "taskBodyLbl";
            this.taskBodyLbl.Size = new System.Drawing.Size(61, 13);
            this.taskBodyLbl.TabIndex = 20;
            this.taskBodyLbl.Text = "Task Body:";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(503, 33);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(40, 13);
            this.statusLbl.TabIndex = 21;
            this.statusLbl.Text = "Status:";
            this.statusLbl.Visible = false;
            // 
            // miniModeBtn
            // 
            this.miniModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("miniModeBtn.Image")));
            this.miniModeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miniModeBtn.Location = new System.Drawing.Point(758, 28);
            this.miniModeBtn.Name = "miniModeBtn";
            this.miniModeBtn.Size = new System.Drawing.Size(62, 23);
            this.miniModeBtn.TabIndex = 22;
            this.miniModeBtn.Text = " Mini";
            this.miniModeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.miniModeBtn.UseVisualStyleBackColor = true;
            this.miniModeBtn.Click += new System.EventHandler(this.MiniMode);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(835, 24);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionManagerToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // connectionManagerToolStripMenuItem
            // 
            this.connectionManagerToolStripMenuItem.Name = "connectionManagerToolStripMenuItem";
            this.connectionManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.connectionManagerToolStripMenuItem.Text = "Connection Manager";
            // 
            // taskTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 621);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.miniModeBtn);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.taskBodyLbl);
            this.Controls.Add(this.taskNameLabel);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.completedRadioButton);
            this.Controls.Add(this.currentRadioButton);
            this.Controls.Add(this.delCatImgBtn);
            this.Controls.Add(this.addCatImgBtn);
            this.Controls.Add(this.saveLbl);
            this.Controls.Add(this.taskBodyTextBox);
            this.Controls.Add(this.taskNametextBox);
            this.Controls.Add(this.taskNamelbl);
            this.Controls.Add(this.tasksTab);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.addTaskTextBox);
            this.Controls.Add(this.categoriesBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(249, 366);
            this.Name = "taskTracker";
            this.Text = "Task Tracker";
            this.Load += new System.EventHandler(this.FormLoad);
            this.SizeChanged += new System.EventHandler(this.windowSize);
            this.contextMenuStrip.ResumeLayout(false);
            this.tasksTab.ResumeLayout(false);
            this.currenttabPage.ResumeLayout(false);
            this.completedtabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addCatImgBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delCatImgBtn)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoriesBox;
        private System.Windows.Forms.ListBox completedTaskListBox;
        private System.Windows.Forms.TextBox addTaskTextBox;
        private System.Windows.Forms.Button addTaskBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openTaskDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem c;
        private System.Windows.Forms.TabControl tasksTab;
        private System.Windows.Forms.TabPage currenttabPage;
        private System.Windows.Forms.TabPage completedtabPage;
        private System.Windows.Forms.ListBox currentTaskListBox;
        private System.Windows.Forms.Label taskNamelbl;
        private System.Windows.Forms.TextBox taskNametextBox;
        private System.Windows.Forms.RichTextBox taskBodyTextBox;
        private System.Windows.Forms.Label saveLbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox addCatImgBtn;
        private System.Windows.Forms.PictureBox delCatImgBtn;
        private System.Windows.Forms.RadioButton currentRadioButton;
        private System.Windows.Forms.RadioButton completedRadioButton;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label taskNameLabel;
        private System.Windows.Forms.Label taskBodyLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Button miniModeBtn;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionManagerToolStripMenuItem;
    }
}

