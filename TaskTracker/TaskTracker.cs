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

        private async void LoadTaskList(object sender, EventArgs e) 
        {
            if (categoriesBox.SelectedIndex != 0)
            {
                List<string> tasks = await task.FindTaskNames(categoriesBox.SelectedItem.ToString());
                taskListBox.DataSource = tasks;    
            }            
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadCategoryList();
        }

        private void AddCategoryBtn(object sender, EventArgs e)
        {
            AddCategory addCat = new AddCategory();
            DialogResult res = (DialogResult)addCat.ShowDialog();
            if (res ==DialogResult.OK)           
                LoadCategoryList();                                                   
        }

        private async void DeleteCategoryBtn(object sender, EventArgs e)
        {
            if (categoriesBox.SelectedIndex == 0)
                MessageBox.Show("Please have the drop down list on a valid category in order to delete");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the category: '" + categoriesBox.SelectedItem.ToString() + "'?", "Delete Category", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    await task.DeleteCategory(categoriesBox.SelectedItem.ToString());
                    LoadCategoryList();
                    taskListBox.DataSource = null;
                }
            }
        }

        private async void AddTaskBtn(object sender, EventArgs e) 
        {                        
            if (taskTextBox.Text == string.Empty)
                MessageBox.Show("Please enter a valid task name.");
            else if (categoriesBox.SelectedIndex == 0)
                MessageBox.Show("Please have a valid category selected.");
            else
            {
                await task.InsertNewTask(taskTextBox.Text, categoriesBox.SelectedItem.ToString());
                LoadTaskList(sender,e);
            }
        }
    }
}
