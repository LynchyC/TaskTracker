using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TaskTracker
{
    public partial class taskTracker : Form
    {
        TaskContext task = new TaskContext();

        public taskTracker()
        {
            InitializeComponent();
        }

        private bool startUp = true;

        private async void FormLoad(object sender, EventArgs e)
        {
            await LoadCategoryList();
            this.Width = 246;
            this.Height = 366;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            taskNametextBox.Visible = false;
            taskNamelbl.Visible = false;
            taskBodyTextBox.Visible = false;
            saveBodyBtn.Visible = false;
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
                List<string> currenttasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "current");
                currentTaskListBox.DataSource = currenttasks;

                List<string> completedTasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "completed");
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
            if (addTaskTextBox.Text == string.Empty)
                MessageBox.Show("Please enter a valid task name.");
            else if (categoriesBox.SelectedIndex == 0)
                MessageBox.Show("Please have a valid category selected.");
            else
            {
                await task.InsertNewTask(addTaskTextBox.Text, categoriesBox.SelectedItem.ToString(), "current");
                await LoadTaskList();
            }
            addTaskTextBox.Clear();
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
                            contextMenuStrip.Show(Cursor.Position);

                            break;
                    }
                }
            }
        }

        private async void delTaskClick(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            string taskName = WhichTabIsTaskSelected(tasksTab.SelectedTab.Tag.ToString());
            result = MessageBox.Show("Are you sure you want to delete the Task: '" + taskName + "'?", "Delete Task", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                await task.DeleteTask(categoriesBox.SelectedItem.ToString(), taskName);
                await LoadTaskList();
            }
        }

        private async void taskStatus(object sender, EventArgs e)
        {
            string tab = tasksTab.SelectedTab.Tag.ToString() == "current" ? Task._Status.Current.ToString() : Task._Status.Completed.ToString();
            await task.TaskStatus(categoriesBox.SelectedItem.ToString(), WhichTabIsTaskSelected(tasksTab.SelectedTab.Tag.ToString()), tab);
            await LoadTaskList();
        }

        private string WhichTabIsTaskSelected(string tag)
        {
            string taskName = tasksTab.SelectedTab.Tag.ToString() == "current" ? currentTaskListBox.SelectedItem.ToString() : completedTaskListBox.SelectedItem.ToString();
            return taskName;
        }

        private void windowSize(object sender, EventArgs e)
        {
            if (startUp == true)
            {
                return;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                this.Width = 851;
                this.Height = 624;
                taskNametextBox.Visible = true;
                taskNamelbl.Visible = true;
                taskBodyTextBox.Visible = true;
                saveBodyBtn.Visible = true;
            }
        }

        private async void loadTaskDetails(object sender, EventArgs e)
        {
            Task doc = await task.GetTasksDetails(categoriesBox.SelectedItem.ToString(), WhichTabIsTaskSelected(tasksTab.SelectedTab.ToString()));
            taskNametextBox.Text = doc.TaskName;
            taskBodyTextBox.Text = doc.TaskBody;
            if (this.Width == 249)
            {
                startUp = false;
                windowSize(sender, e);
            }
                
        }

        private async void saveChanges(object sender, EventArgs e)
        {
            await task.SaveChanges(taskBodyTextBox.Text, taskNametextBox.Text, categoriesBox.SelectedItem.ToString());
            saveLbl.Visible = true;
            timer.Interval = 2000;
            timer.Tick += new System.EventHandler(this.timerTick);
            saveLbl.Visible = true;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            saveLbl.Visible = false;
        }
    }
}
