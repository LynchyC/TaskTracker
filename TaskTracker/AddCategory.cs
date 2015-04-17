using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTracker
{
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        public async void AddCategoryBtn(object sender, EventArgs e) 
        {
            TaskContext task = new TaskContext();
            if (categoryName.Text == string.Empty)            
                MessageBox.Show("Please insert a valid Category name");
            else            
                await task.InsertCategory(categoryName.Text);                            
        }
    }
}
