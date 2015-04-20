namespace TaskTracker
{
    partial class AddCategory
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
            this.categoryName = new System.Windows.Forms.TextBox();
            this.addCategoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // categoryName
            // 
            this.categoryName.Location = new System.Drawing.Point(12, 12);
            this.categoryName.Name = "categoryName";
            this.categoryName.Size = new System.Drawing.Size(184, 20);
            this.categoryName.TabIndex = 0;
            // 
            // addCategoryBtn
            // 
            this.addCategoryBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addCategoryBtn.Location = new System.Drawing.Point(202, 10);
            this.addCategoryBtn.Name = "addCategoryBtn";
            this.addCategoryBtn.Size = new System.Drawing.Size(63, 23);
            this.addCategoryBtn.TabIndex = 1;
            this.addCategoryBtn.Text = "Add";
            this.addCategoryBtn.UseVisualStyleBackColor = true;
            this.addCategoryBtn.Click += new System.EventHandler(this.AddCategoryBtn);
            // 
            // AddCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 43);
            this.Controls.Add(this.addCategoryBtn);
            this.Controls.Add(this.categoryName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCategory";
            this.Text = "Add Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox categoryName;
        private System.Windows.Forms.Button addCategoryBtn;
    }
}