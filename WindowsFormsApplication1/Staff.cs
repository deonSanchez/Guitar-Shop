using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarShop
{
    public partial class Staff : Form
    {
        SqlConnection cnn;
    
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

            string query = "select * from employees where name ='"+ stuff +"' ;";
            SqlConnection cnn = new SqlConnection(Constants.ConnectionString);
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader dataReader;
            
            try
            {
                cnn.Open();
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                { 
                    textBox1.Text = dataReader["EmployeeID"].ToString();
                    titleComboBox.Text = dataReader["title"].ToString();
                    textBox1.Text = dataReader["firstname"].ToString();
                    textBox2.Text = dataReader["lastname"].ToString();
                    textBox5.Text = dataReader["password"].ToString();
                    textBox4.Text = dataReader["emailaddress"].ToString();
                    textBox7.Text = dataReader["datehired"].ToString();
                    textBox8.Text = dataReader["birthdate"].ToString();
                    EmployeeTypeComboBox.Text = dataReader["employeetype"].ToString();
                }

            } catch (SqlException ex)
            {
                MessageBox.Show(ex);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //idnumber

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //firstname
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
