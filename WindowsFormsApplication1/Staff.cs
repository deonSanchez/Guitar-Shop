using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarShop
{
    public partial class Staff : Form
    {
    
        private static string[] TitleField = new string[] {"Cashier",
            "Guitar Specialist",
            "Salesmen",
            "Inverntory Clerk",
            "Quality Assurance",
            "Manager" };

        private static string[] EmployeeTypeField = new string[] {"Full Time", "Part Time"};

        public Staff()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            titleComboBox.Items.Add(TitleField);
        }

        private void EmployeeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeTypeComboBox.Items.Add(EmployeeTypeField);
        }

        private void AdminPrivilege_CheckedChanged(object sender, EventArgs e)
        {
            if (AdminPrivilege.Checked) {
                //has admin privileges
                //should display Override Code
            }
            else
            {
                //has normal privileges
            }
        }
    }
}
