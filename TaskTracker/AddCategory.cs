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
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public AddCategory()
        {
            InitializeComponent();
        }

        public void AddCategoryBtn(object sender, EventArgs e) 
        {
            try
            {
                if (catName.Text == string.Empty)
                    MessageBox.Show("Please insert a valid Category name");
                else
                    CategoryName = catName.Text;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.InnerException.ToString());                
            }
            
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                addCategoryBtn.PerformClick();
        }
    }
}
