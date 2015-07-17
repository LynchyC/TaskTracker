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
        ITaskContext task = null;
        private static NLog.Logger _logger = null;
        private bool startUp = true;
        private bool functionCalled = false;
        private string body = "";
        private string selectedCategory = "";
        private List<string> controlNames = new List<string>(new string[] { "taskNametextBox", "taskNamelbl", "taskBodyTextBox", "saveBtn", "currentRadioButton", "completedRadioButton", "statusLbl" });

        public taskTracker()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
            InitializeComponent();
            try
            {
                task = new MongoTaskContext();
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Could not connect to MongoDB: {0}", ex.InnerException.ToString()));
                MessageBox.Show("Could not connect to MongoDB, would you like to switch to a local JSON file instead?",
                                "Connection Error", MessageBoxButtons.YesNo);
            }

        }

        private async void FormLoad(object sender, EventArgs e)
        {
            // Sets the program to start in Mini-Mode
            this.Width = 246;
            this.Height = 380;

            // Go grabs the Categories of the user
            await LoadCategoryList();
        }

        #region Task Methods
        private async void TaskLoad(object sender, EventArgs e)
        {
            // Go grabs the tasks of the category that was selected by the user
            await LoadTaskList();
        }

        private async Task<bool> LoadTaskList()
        {
            try
            {   
                // Ignores 'Select a category...' - Invalid category!
                if (categoriesBox.SelectedIndex != 0)
                {
                    // Grabs all the CURRENT task names from the array inside the mongo collection
                    List<string> currentTasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "current");

                    // Loads the CURRENT tasks in the appropriate list box
                    currentTaskListBox.DataSource = currentTasks;

                    // Grabs all the COMPLETED task names from the array inside the mongo collection
                    List<string> completedTasks = await task.FindTaskNamesByTab(categoriesBox.SelectedItem.ToString(), "completed");

                    // Loads the COMPLETED tasks in the appropriate list box
                    completedTaskListBox.DataSource = completedTasks;

                    // Sets the index so no task is selected once it loads in the list box
                    currentTaskListBox.SelectedIndex = -1;
                    completedTaskListBox.SelectedIndex = -1;
                    functionCalled = false;
                }
                //else
                //{                    
                //    currentTaskListBox.DataSource = null;
                //    completedTaskListBox.DataSource = null;
                //}
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

            return true;
        }

        private async void AddTaskBtn(object sender, EventArgs e)
        {
            try
            {
                // Make sure the user does not input an empty Task Name                
                if (string.IsNullOrWhiteSpace(addTaskTextBox.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid task name.");
                    return;
                }
                // In addition to the user adding a task to 'Select a Category'
                else if (categoriesBox.SelectedIndex == 0)
                {
                    MessageBox.Show("Please have a valid category selected.");
                    return;
                }
                // If the user does everything right, the program will go off to the database 
                // and create the task with the Name they inputted in the category that is selected. 
                else
                {
                    await task.InsertNewTask(addTaskTextBox.Text, categoriesBox.SelectedItem.ToString(), "current");
                    await LoadTaskList();
                }

                // Will clear the text box where the Task name is inputted by the user!
                addTaskTextBox.Clear();

            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }

        private void taskListMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int index = 0;
                if (categoriesBox.SelectedIndex != 0)
                {
                    ContextMenuStrip cm = new ContextMenuStrip();
                    tasksTab.ContextMenuStrip = cm;

                    // Will change the context menu option of the task status to the appropriate output
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
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }

        private async void delTaskClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = new DialogResult();
                string taskName = WhichTabIsTaskSelected();
                result = MessageBox.Show("Are you sure you want to delete the Task: '" + taskName + "'?", "Delete Task", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    await task.DeleteTask(categoriesBox.SelectedItem.ToString(), taskName);

                    // Removes the task from the List Box so the user can no longer see it!
                    await LoadTaskList();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }

        private async void LoadTaskDetails(object sender, EventArgs e)
        {
            try
            {
                // Makes sure that the user clicks a task in the list box instead of an empty space.
                string taskToLoad = WhichTabIsTaskSelected();
                if (string.IsNullOrWhiteSpace(taskToLoad))
                    return;

                // Gets the selected Task details from the database
                Task doc = await task.GetTasksDetails(categoriesBox.SelectedItem.ToString(), taskToLoad);

                // Saves the Category Name in case the user makes changes to task without saving and tries to go off 
                // to a different category.
                selectedCategory = categoriesBox.SelectedItem.ToString();
                if (functionCalled == true)
                {
                    // Grabs the checked radio button and compares it with the status of that is in the db.
                    var radioCheck = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                    string statusCheck = await status();

                    // Check if the user made any changes to the Task body or status without saving.
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
                // Selects the appropriate radio button depending on the task status.
                if (doc.Status == Task._Status.Current.ToString())
                    currentRadioButton.Select();
                else
                    completedRadioButton.Select();

                body = taskBodyTextBox.Text;

                // Sets the program into full mode (not full screen though!)
                if (this.Width == 249)
                {
                    startUp = false;
                    functionCalled = true;
                    windowSize(sender, e);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
        }

        private async void taskStatus(object sender, EventArgs e)
        {
            try
            {
                // Grabs the status of the Task and changes it in the db to the opposite
                string tab = tasksTab.SelectedTab.Tag.ToString() == "current" ? Task._Status.Current.ToString() : Task._Status.Completed.ToString();
                await task.TaskStatus(categoriesBox.SelectedItem.ToString(), WhichTabIsTaskSelected(), tab);

                // Refreshs the task list to move the task that was just changed into the appropriate list box. 
                await LoadTaskList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
        }

        private async void saveChanges(object sender, EventArgs e)
        {
            try
            {
                body = taskBodyTextBox.Text;
                var radioCheck = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                string statusCheck = await status();

                // Depending on if the user has changed the status of the task when saving, it will go off to the db and change it accordingly. 
                // It will then present the user with a message box declaring that the task status has changed.
                if (statusCheck != radioCheck.Text)
                {
                    await task.TaskStatus(categoriesBox.SelectedItem.ToString(), taskNametextBox.Text, statusCheck);
                    await LoadTaskList();
                    string taskStatus = radioCheck.Text == "Current" ? "Task set back to Current." : "Task set to Completed.";
                    MessageBox.Show(taskStatus, "Task Status");
                }

                // If the user is not in Mini-Mode at this point in time, then the label declaring 'Progress Saved' will be presented 
                // at the bottom right of the window for 2 seconds to let the user know.
                await task.SaveChanges(taskBodyTextBox.Text, taskNametextBox.Text, selectedCategory);
                saveLbl.Visible = true;
                timer.Interval = 2000;
                timer.Tick += new System.EventHandler(this.timerTick);
                saveLbl.Visible = true;
                timer.Start();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
        }

        private async Task<string> status()
        {
            try
            {
                // Goes off to the db to check what the status of the task is there.
                string radioStatus = await task.CheckStatus(categoriesBox.SelectedItem.ToString(), taskNametextBox.Text);
                return radioStatus;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
                MessageBox.Show("Could not fulfill request.", "Error");
                return "";
            }
        }

        #endregion

        #region Category Methods
        private async Task<bool> LoadCategoryList()
        {
            try
            {
                // Grabs all the category names from the mongo collection
                List<string> categories = await task.FindCategoryNames();

                // Create the default value to guide the user. 
                categories.Insert(0, "Select a category...");
                categoriesBox.DataSource = categories;

            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

            return true;
        }

        private async void AddCategoryBtn(object sender, EventArgs e)
        {
            try
            {
                AddCategory addCat = new AddCategory();
                // Runs AddCategory form - gets string value for created category.
                if (addCat.ShowDialog(this) == DialogResult.OK)
                {
                    await task.InsertCategory(addCat.CategoryName);
                    await LoadCategoryList();
                    // Sets the drop down list to go directly to newly created category.
                    categoriesBox.SelectedIndex = categoriesBox.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }

        private async void DeleteCategoryBtn(object sender, EventArgs e)
        {
            try
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
                        if (this.Width != 246)
                        {
                            taskNametextBox.Text = "";
                            taskBodyTextBox.Text = "";
                            currentRadioButton.Checked = false;
                            completedRadioButton.Checked = false;
                        }
                        currentTaskListBox.DataSource = null;
                        completedTaskListBox.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }
        #endregion

        #region Bevel Image on hover
        private void BevelImage(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
        }

        private void UnBevelImage(object sender, EventArgs e)
        {
            try
            {
                ((PictureBox)sender).BorderStyle = BorderStyle.None;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }
        #endregion

        #region Form Size Methods
        private void windowSize(object sender, EventArgs e)
        {
            try
            {
                if (startUp == true)
                    return;
                if (this.WindowState == FormWindowState.Normal)
                {
                    startUp = true;
                    this.Width = 851;
                    this.Height = 659;
                    taskNametextBox.Visible = true;
                    taskNamelbl.Visible = true;
                    taskBodyTextBox.Visible = true;
                    saveBtn.Visible = true;
                    currentRadioButton.Visible = true;
                    completedRadioButton.Visible = true;
                    statusLbl.Visible = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }
        }

        private void MiniMode(object sender, EventArgs e)
        {
            try
            {
                this.Width = 246;
                this.Height = 380;
                taskNametextBox.Visible = false;
                taskNamelbl.Visible = false;
                taskBodyTextBox.Visible = false;
                saveBtn.Visible = false;
                currentRadioButton.Visible = false;
                completedRadioButton.Visible = false;
                statusLbl.Visible = false;
                functionCalled = false;
                saveLbl.Visible = false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
            }

        }

        private void ControlTrigger(bool controlView)
        {

        }
        #endregion

        private string WhichTabIsTaskSelected()
        {
            try
            {
                string taskName = "";
                if (tasksTab.SelectedTab.Tag.ToString() == "current")
                    taskName = currentTaskListBox.SelectedIndex != -1 ? currentTaskListBox.SelectedItem.ToString() : "";
                else
                    taskName = completedTaskListBox.SelectedIndex != -1 ? completedTaskListBox.SelectedItem.ToString() : "";

                return taskName;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());
                return "";
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

        private void TabChange(object sender, EventArgs e)
        {
            currentTaskListBox.SelectedIndex = -1;
            completedTaskListBox.SelectedIndex = -1;
        }
    }
}
