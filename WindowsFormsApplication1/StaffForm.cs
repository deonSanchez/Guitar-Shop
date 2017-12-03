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
    public partial class StaffForm : Form
    {
        private static string[] employeeTypes = new string[] { "FULLTIME", "PARTTIME" };
        private static string[] employeePrivileges = new string[] { "normal", "admin" };

        SqlConnection cnn;

        bool creating = true;
        int editItemID;

        Employees employee;
    
        public StaffForm(bool creating, int editItemID)
        {
            InitializeComponent();

            employee = new Employees();

            // Initialize SQL connection for this form.
            cnn = new SqlConnection(Constants.ConnectionString);
            try
            {
                cnn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: the connection could not be opened.");
                Close();
            }

            cmb_priv.Items.AddRange(employeePrivileges);
            cmb_type.Items.AddRange(employeeTypes);

            this.creating = creating;
            this.editItemID = editItemID;

            if (!creating)
            {
                btn_add.Text = "Update";
                PreloadData();
            }
            else
            {
                employee.BirthDate = dt_birth.Value;
                employee.DateHired = dt_hired.Value;
            }
        }

        /// <summary>
        /// Ensure that form is ready to submit before allowing the user to do so,
        /// </summary>
        private void ValidateForm()
        {
            if (cmb_type.SelectedIndex > -1
                && cmb_priv.SelectedIndex > -1
                && cmb_type.SelectedIndex > -1
                && txt_title.Text != ""
                && txt_firstname.Text != ""
                && txt_lastname.Text != ""
                && txt_email.Text != ""
                && txt_pass.Text != "")
            {
                if (cmb_priv.SelectedItem.ToString() == "admin")
                {
                    btn_add.Enabled = txt_code.Text != "";
                }
                else
                {
                    btn_add.Enabled = true;
                }
            }
            else
            {
                btn_add.Enabled = false;
            }
        }

        private void PreloadData()
        {
            employee = new Employees();

            employee.EmployeeID = editItemID;

            // Load in Customer details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, BirthDate FROM Employees WHERE EmployeeID = @EmployeeID";

                command.Parameters.AddWithValue("@EmployeeID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee.Title = reader[0].ToString();
                        employee.FirstName = reader[1].ToString();
                        employee.LastName = reader[2].ToString();
                        employee.EmailAddress = reader[3].ToString();
                        employee.Password = reader[4].ToString();
                        employee.EmployeeType = reader[5].ToString();
                        employee.DateHired = Convert.ToDateTime(reader[6]);
                        employee.PrivilegeLevel = reader[7].ToString();
                        employee.BirthDate = Convert.ToDateTime(reader[8]);
                    }
                }

                txt_title.Text = employee.Title;
                txt_firstname.Text = employee.FirstName;
                txt_lastname.Text = employee.LastName;
                txt_email.Text = employee.EmailAddress;
                txt_pass.Text = employee.Password;
                dt_birth.Value = employee.BirthDate;
                dt_hired.Value = employee.DateHired;
                cmb_type.Text = employee.EmployeeType;
                cmb_priv.Text = employee.PrivilegeLevel;

                txt_code.Enabled = cmb_priv.SelectedItem.ToString() == "admin";
            }
        }

        private void CreateEmployees()
        {
            int autoEmployeeID = 0;

            employee.Title = txt_title.Text;
            employee.FirstName = txt_firstname.Text;
            employee.LastName = txt_lastname.Text;
            employee.EmailAddress = txt_email.Text;
            employee.Password = txt_pass.Text;
            employee.BirthDate = dt_birth.Value;
            employee.EmployeeType = cmb_type.Text;
            employee.PrivilegeLevel = cmb_priv.Text;
            employee.DateHired = dt_hired.Value;

            if (creating)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Employee (Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, birthDate) VALUES (@Title, @FirstName, @LastName, @EmailAddress, @Password, @EmployeeType, @DateHired, @PrivilegeLevel, @birthDate); SELECT SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("@Title", employee.Title);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                    command.Parameters.AddWithValue("@DateHired", employee.DateHired);
                    command.Parameters.AddWithValue("@PrivilegeLevel", employee.PrivilegeLevel);
                    command.Parameters.AddWithValue("@birthDate", employee.BirthDate);

                    try
                    {
                        autoEmployeeID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Customer successfully created!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write customer.");
                        return;
                    }
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Employees SET EmailAddress = @EmailAddress, Password = @Password, FirstName = @FirstName, LastName = @LastName, EmployeeContact = @EmployeeContact WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@Title", employee.Title);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                    command.Parameters.AddWithValue("@DateHired", employee.DateHired);
                    command.Parameters.AddWithValue("@PrivilegeLevel", employee.PrivilegeLevel);
                    command.Parameters.AddWithValue("@birthDate", employee.BirthDate);

                    try
                    {
                        autoEmployeeID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Customer successfully updated!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write customer.");
                        return;
                    }
                }
            }
            cnn.Close();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }

        private void cmb_priv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code.Enabled = cmb_priv.SelectedItem.ToString() == "admin";
            ValidateForm();
        }

        private void dt_hired_ValueChanged(object sender, EventArgs e)
        {
            employee.DateHired = dt_hired.Value;
        }

        private void dt_birth_ValueChanged(object sender, EventArgs e)
        {
            employee.DateHired = dt_birth.Value;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            CreateEmployees();
        }

        private void txt_title_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txt_firstname_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txt_lastname_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            ValidateForm();
        }
    }
}
