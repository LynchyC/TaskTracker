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

        private async void FormLoad(object sender, EventArgs e) 
        {
            await LoadCategoryList();
        }

        private async void TaskLoad(object sender, EventArgs e) 
        {
            await LoadTaskList();
        }

        private async Task<bool> LoadCategoryList()
        {
            await task.CreateIndex();
            // Grabs all the category names from the mongo collection
            List<string> categories = await task.FindCategoryNames();
            // Create the default value to guide the user. 
            categories.Insert(0, "Select a category...");
            categoriesBox.DataSource = categories;
            return true;
        }

        private async Task<bool> LoadTaskList()
        {
            // Ignores 'Select a category...' - Invalid category!
            if (categoriesBox.SelectedIndex != 0)
            {
                // Grabs all the task names from the array inside the mongo collection
                List<string> currenttasks = await task.FindCurrentTaskNames(categoriesBox.SelectedItem.ToString());                                              
                currentTaskListBox.DataSource = currenttasks;

                List<string> completedTasks = await task.FindCompletedTaskNames(categoriesBox.SelectedItem.ToString());
                completedTaskListBox.DataSource = completedTasks;
            }
            else
            {
                currentTaskListBox.DataSource = null;
                completedTaskListBox.DataSource = null;
            }

            return true;
        }

        private async void AddCategoryBtn(object sender, EventArgs e)
        {
            AddCategory addCat = new AddCategory();
            // Runs AddCategory form - gets string value for created category. 
            DialogResult res = (DialogResult)addCat.ShowDialog();
            if (res == DialogResult.OK) 
            {
                await task.InsertCategory(addCat.CategoryName);
                await LoadCategoryList();
                // Sets the drop down list to go directly to newly created category.
                categoriesBox.SelectedIndex = categoriesBox.Items.Count - 1;
            }
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
                    await LoadCategoryList();
                    completedTaskListBox.DataSource = null;
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
                await task.InsertNewTask(taskTextBox.Text, categoriesBox.SelectedItem.ToString(), "0");
                await LoadTaskList();
            }
            taskTextBox.Clear();
        }

        private void taskListMouseDown(object sender, MouseEventArgs e)
        {
            int index = 0;
            if (categoriesBox.SelectedIndex != 0)
            {
                ContextMenuStrip cm = new ContextMenuStrip();                
                tasksTab.ContextMenuStrip = cm;
                if (tasksTab.SelectedTab.Tag.ToString() != "current")
                {
                    c.Text = "Set Task as Current";
                    index = this.completedTaskListBox.IndexFromPoint(e.Location);
                }
                else
                {
                    c.Text = "Set Task as Completed";
                    index = this.currentTaskListBox.IndexFromPoint(e.Location);
                }
                
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
            DialogResult result = new DialogResult();
            string taskName = WhichTab(tasksTab.SelectedTab.Tag.ToString());
            result = MessageBox.Show("Are you sure you want to delete the Task: '" + taskName + "'?", "Delete Task", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                await task.DeleteTask(categoriesBox.SelectedItem.ToString(),taskName);
                await LoadTaskList();
            }
        }

        private async void taskStatus(object sender, EventArgs e) 
        {
            string tab = tasksTab.SelectedTab.Tag.ToString() == "current" ? Task._Status.Current.ToString() : Task._Status.Completed.ToString();
            await task.TaskStatus(categoriesBox.SelectedItem.ToString(), WhichTab(tasksTab.SelectedTab.Tag.ToString()), tab);
            await LoadTaskList();
        }

        private string WhichTab(string tag) 
        {
            string taskName = tasksTab.SelectedTab.Tag.ToString() == "current" ? currentTaskListBox.SelectedItem.ToString() : completedTaskListBox.SelectedItem.ToString();
            return taskName;
        }
    }
}
