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
            this.categoriesBox = new System.Windows.Forms.ComboBox();
            this.taskListBox = new System.Windows.Forms.ListBox();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.delCategoryBtn = new System.Windows.Forms.Button();
            this.addTaskBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoriesBox
            // 
            this.categoriesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoriesBox.FormattingEnabled = true;
            this.categoriesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.categoriesBox.Location = new System.Drawing.Point(13, 13);
            this.categoriesBox.Name = "categoriesBox";
            this.categoriesBox.Size = new System.Drawing.Size(121, 21);
            this.categoriesBox.TabIndex = 0;
            this.categoriesBox.SelectedIndexChanged += new System.EventHandler(this.LoadTaskList);
            // 
            // taskListBox
            // 
            this.taskListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskListBox.FormattingEnabled = true;
            this.taskListBox.Location = new System.Drawing.Point(13, 40);
            this.taskListBox.Name = "taskListBox";
            this.taskListBox.Size = new System.Drawing.Size(259, 212);
            this.taskListBox.TabIndex = 1;
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.Location = new System.Drawing.Point(140, 13);
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
            this.taskTextBox.Location = new System.Drawing.Point(13, 258);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(121, 20);
            this.taskTextBox.TabIndex = 4;
            // 
            // delCategoryBtn
            // 
            this.delCategoryBtn.Location = new System.Drawing.Point(174, 13);
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
            this.addTaskBtn.Location = new System.Drawing.Point(140, 256);
            this.addTaskBtn.Name = "addTaskBtn";
            this.addTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.addTaskBtn.TabIndex = 6;
            this.addTaskBtn.Text = "Add Task";
            this.addTaskBtn.UseVisualStyleBackColor = true;
            this.addTaskBtn.Click += new System.EventHandler(this.AddTaskBtn);
            // 
            // taskTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.addTaskBtn);
            this.Controls.Add(this.delCategoryBtn);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.addCategoryBtn);
            this.Controls.Add(this.taskListBox);
            this.Controls.Add(this.categoriesBox);
            this.Name = "taskTracker";
            this.Text = "Task Tracker";
            this.Load += new System.EventHandler(this.LoadCategoryList);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoriesBox;
        private System.Windows.Forms.ListBox taskListBox;
        private System.Windows.Forms.Button addCategoryBtn;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button delCategoryBtn;
        private System.Windows.Forms.Button addTaskBtn;
    }
}

