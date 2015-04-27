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
        public string CategoryName = "";

        public AddCategory()
        {
            InitializeComponent();
        }

        public void AddCategoryBtn(object sender, EventArgs e) 
        {
            if (catName.Text == string.Empty)
                MessageBox.Show("Please insert a valid Category name");
            else
                CategoryName = catName.Text;
        }
    }
}
