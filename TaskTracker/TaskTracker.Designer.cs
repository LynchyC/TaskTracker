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
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            this.delCategoryBtn = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
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
            // 
            // categoryListBox
            // 
            this.categoryListBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.Location = new System.Drawing.Point(13, 40);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.Size = new System.Drawing.Size(259, 212);
            this.categoryListBox.TabIndex = 1;
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.Location = new System.Drawing.Point(140, 256);
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(54, 23);
            this.addCategoryBtn.TabIndex = 2;
            this.addCategoryBtn.Text = "Add";
            this.addCategoryBtn.UseVisualStyleBackColor = true;
            this.addCategoryBtn.Click += new System.EventHandler(this.AddCategoryBtn);
            // 
            // delCategoryBtn
            // 
            this.delCategoryBtn.Location = new System.Drawing.Point(140, 12);
            this.delCategoryBtn.Name = "delCategoryBtn";
            this.delCategoryBtn.Size = new System.Drawing.Size(54, 22);
            this.delCategoryBtn.TabIndex = 3;
            this.delCategoryBtn.Text = "Delete";
            this.delCategoryBtn.UseVisualStyleBackColor = true;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(13, 258);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(121, 20);
            this.categoryTextBox.TabIndex = 4;
            // 
            // taskTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 290);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.delCategoryBtn);
            this.Controls.Add(this.addCategoryBtn);
            this.Controls.Add(this.categoryListBox);
            this.Controls.Add(this.categoriesBox);
            this.Name = "taskTracker";
            this.Text = "Task Tracker";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoriesBox;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Button addCategoryBtn;
        private System.Windows.Forms.Button delCategoryBtn;
        private System.Windows.Forms.TextBox categoryTextBox;
    }
}

