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

        private async void LoadCategoryList(object sender, EventArgs e)
        {
            // Grabs all the category names from the mongo collection
            List<string> categories = await task.FindCategoryNames();
            // Create the default value to guide the user. 
            categories.Insert(0, "Select a category...");
            categoriesBox.DataSource = categories;
        }

        private async void LoadTaskList(object sender, EventArgs e)
        {
            // Ignores 'Select a category...' - Invalid category!
            if (categoriesBox.SelectedIndex != 0)
            {
                // Grabs all the task names from the array inside the mongo collection
                List<string> tasks = await task.FindTaskNames(categoriesBox.SelectedItem.ToString());
                taskListBox.DataSource = tasks;
            }
        }

        private void AddCategoryBtn(object sender, EventArgs e)
        {
            AddCategory addCat = new AddCategory();
            // Runs AddCategory form - gets string value for created category. 
            DialogResult res = (DialogResult)addCat.ShowDialog();
            if (res == DialogResult.OK)
                LoadCategoryList(sender, e);
            // Sets the drop down list to go directly to newly created category.
            int count = categoriesBox.Items.Count;
            categoriesBox.SelectedIndex = count - 1;
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
                    LoadCategoryList(sender, e);
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
                LoadTaskList(sender, e);
            }
            taskTextBox.Clear();
        }

        private void taskListMouseDown(object sender, MouseEventArgs e)
        {
            if (categoriesBox.SelectedIndex != 0)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                //ToolStripItem openTaskDetails = cm.Items.Add("Open Task Details");
                //ToolStripItem delTask = cm.Items.Add("Delete Task");
                //ToolStripItem completeTask = cm.Items.Add("Set Task as Completed");
                taskListBox.ContextMenuStrip = cm;
                int index = this.taskListBox.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    switch (e.Button)
                    {
                        case MouseButtons.Right:
                            {
                                contextMenuStrip.Show(this, new Point(e.X, e.Y));
                            }
                            break;
                    }
                }
            }
        }

        private async void delTaskClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete the Task: '" + taskListBox.SelectedItem.ToString() + "'?", "Delete Task", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                await task.DeleteTask(categoriesBox.SelectedItem.ToString(), taskListBox.SelectedItem.ToString());
                LoadTaskList(sender, e);
            }
        }
    }
}
