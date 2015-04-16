using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace TaskTracker
{
    public partial class taskTracker : Form
    {
        TaskContext task = new TaskContext();

        public taskTracker()
        {
            InitializeComponent();
        }

        private async void LoadCategoryList() 
        {
            List<string> categories = await task.FindCategoryNames();
            categories.Insert(0, "Select a category...");
            categoriesBox.DataSource = categories;
        }

        private void OnLoad(object sender, EventArgs e) 
        {
            LoadCategoryList();
        }

        private async void AddCategoryBtn(object sender, EventArgs e) 
        {
            
            if (categoryTextBox.Text == string.Empty)
	        {
                MessageBox.Show("Please insert a valid Category Name");
                return;
	        }
            else
            {
                await task.InsertCategory(categoryTextBox.Text);
                LoadCategoryList();
            }                        
        }
    }
}
