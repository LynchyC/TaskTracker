﻿using System;
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
        private bool functionCalled = false;
        private string body = "";

        private async void FormLoad(object sender, EventArgs e)
        {
            this.Width = 246;
            this.Height = 380;
            await LoadCategoryList();
        }
         
        private async void TaskLoad(object sender, EventArgs e)
        {
            await LoadTaskList();
        }

        #region Task Methods
        private async Task<bool> LoadTaskList()
        {
            // Ignores 'Select a category...' - Invalid category!
            if (categoriesBox.SelectedIndex != 0)
            {
                // Grabs all the task names from the array inside the mongo collection
                List<string> currenttasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "current");
                currentTaskListBox.DataSource = currenttasks;
                currentTaskListBox.SelectedIndex = -1;

                List<string> completedTasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "completed");
                completedTaskListBox.DataSource = completedTasks;
                completedTaskListBox.SelectedIndex = -1;
            }
            else
            {
                currentTaskListBox.DataSource = null;
                completedTaskListBox.DataSource = null;
            }

            return true;
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

        private async void LoadTaskDetails(object sender, EventArgs e)
        {
            Task doc = await task.GetTasksDetails(categoriesBox.SelectedItem.ToString(), WhichTabIsTaskSelected(tasksTab.SelectedTab.ToString()));
            if (functionCalled == true)
            {
                var radioCheck = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                string statusCheck = await status();
                if (changesMade(taskBodyTextBox.Text) == false || radioCheck.Text != statusCheck)
                {
                    DialogResult result = new DialogResult();
                    result = MessageBox.Show("You are about to change tasks without saving your progress. Are you sure you want to change?", "Save Changes", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
            }

            taskNametextBox.Text = doc.TaskName;
            taskBodyTextBox.Text = doc.TaskBody;
            if (doc.Status == Task._Status.Current.ToString())
                currentRadioButton.Select();
            else
                completedRadioButton.Select();

            body = taskBodyTextBox.Text;
            if (this.Width == 249)
            {
                startUp = false;
                functionCalled = true;
                windowSize(sender, e);
            }
        }

        private async void taskStatus(object sender, EventArgs e)
        {
            string tab = tasksTab.SelectedTab.Tag.ToString() == "current" ? Task._Status.Current.ToString() : Task._Status.Completed.ToString();
            await task.TaskStatus(categoriesBox.SelectedItem.ToString(), WhichTabIsTaskSelected(tasksTab.SelectedTab.Tag.ToString()), tab);
            await LoadTaskList();
        }

        private async void saveChanges(object sender, EventArgs e)
        {
            body = taskBodyTextBox.Text;
            var radioCheck = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            string statusCheck = await status();
            if (statusCheck != radioCheck.Text)
            {
                await task.TaskStatus(categoriesBox.SelectedItem.ToString(), taskNametextBox.Text, statusCheck);
                await LoadTaskList();
                string taskStatus = radioCheck.Text == "Current" ? "Task set back to Current." : "Task set to Completed.";
                MessageBox.Show(taskStatus, "Task Status");
            }

            await task.SaveChanges(taskBodyTextBox.Text, taskNametextBox.Text, categoriesBox.SelectedItem.ToString());
            saveLbl.Visible = true;
            timer.Interval = 2000;
            timer.Tick += new System.EventHandler(this.timerTick);
            saveLbl.Visible = true;
            timer.Start();
        }

        private async Task<string> status()
        {
            string radioStatus = await task.CheckStatus(categoriesBox.SelectedItem.ToString(), taskNametextBox.Text);
            return radioStatus;
        }

        #endregion

        #region Category Methods
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
        #endregion

        #region Bevel Image on hover
        private void BevelImage(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
        }

        private void UnBevelImage(object sender, EventArgs e)
        {
            ((PictureBox)sender).BorderStyle = BorderStyle.None;
        }
        #endregion

        private string WhichTabIsTaskSelected(string tag)
        {
            string taskName = tasksTab.SelectedTab.Tag.ToString() == "current" ? currentTaskListBox.SelectedItem.ToString() : completedTaskListBox.SelectedItem.ToString();
            return taskName;
        }

        private void windowSize(object sender, EventArgs e)
        {
            if (startUp == true)            
                return;
            
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Width = 851;
                this.Height = 624;
                taskNametextBox.Visible = true;
                taskNamelbl.Visible = true;
                taskBodyTextBox.Visible = true;
                saveBtn.Visible = true;
                currentRadioButton.Visible = true;
                completedRadioButton.Visible = true;
                statusLbl.Visible = true;
            }
        }

        private bool changesMade(string taskBody) 
        {
            if (body == taskBody)
                return true;
            else
                return false;
        }

        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            saveLbl.Visible = false;
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                addTaskBtn.PerformClick();
        }

    }
}
