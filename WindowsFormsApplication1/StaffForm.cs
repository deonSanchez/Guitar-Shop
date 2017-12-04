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
    /// <summary>
    /// Form for creating and modifying Staff.
    /// </summary>
    public partial class StaffForm : Form
    {
        private static string[] employeeTypes = new string[] { "FULLTIME", "PARTTIME" };
        private static string[] employeePrivileges = new string[] { "normal", "admin" };

        SqlConnection cnn;

        bool creating = true;
        int editItemID;

        Employees employee;

        bool loadedAsAdmin = false;
        bool saveAsAdmin = false;
    
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
                command.CommandText = @"SELECT Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, BirthDate, OverideCode
                                        FROM Employees
                                        LEFT JOIN Administrators ON AdminID = EmployeeID WHERE EmployeeID = @EmployeeID";

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

                        if(reader[9] is DBNull)
                        {
                            loadedAsAdmin = false;
                            saveAsAdmin = false;
                        } 
                        else
                        {
                            loadedAsAdmin = true;
                            saveAsAdmin = true;
                            employee.OverrideCode = Convert.ToInt32(reader[9]);
                        }
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

                if(loadedAsAdmin)
                {
                    txt_code.Enabled = true;
                    txt_code.Text = employee.OverrideCode.ToString();
                }
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

            if(saveAsAdmin)
            {
                employee.OverrideCode = Convert.ToInt32(txt_code.Text);
            }

            if (creating)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Employee (Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, BirthDate) VALUES (@Title, @FirstName, @LastName, @EmailAddress, @Password, @EmployeeType, @DateHired, @PrivilegeLevel, @BirthDate);";

                    command.Parameters.AddWithValue("@Title", employee.Title);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                    command.Parameters.AddWithValue("@DateHired", employee.DateHired.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@PrivilegeLevel", employee.PrivilegeLevel);
                    command.Parameters.AddWithValue("@BirthDate", employee.BirthDate.ToString("yyyy-MM-dd"));

                    autoEmployeeID = Convert.ToInt32(command.ExecuteScalar());
                    
                    if (saveAsAdmin)
                    {
                        command.CommandText = "INSERT INTO Administrators (AdminID, OverideCode) VALUES (@AdminID, @OverideCode);";

                        command.Parameters.AddWithValue("@AdminID", autoEmployeeID);
                        command.Parameters.AddWithValue("@OverideCode", employee.OverrideCode);
                    }

                    MessageBox.Show("Staff member successfully created!");
                }
            }
            else
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Employees SET Title = @Title, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, Password = @Password, EmployeeType = @EmployeeType, DateHired = @DateHired, PrivilegeLevel = @PrivilegeLevel, BirthDate = @BirthDate WHERE EmployeeID = @EmployeeID";

                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@Title", employee.Title);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@EmployeeType", employee.EmployeeType);
                    command.Parameters.AddWithValue("@DateHired", employee.DateHired.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@PrivilegeLevel", employee.PrivilegeLevel);
                    command.Parameters.AddWithValue("@BirthDate", employee.BirthDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();

                    if (loadedAsAdmin && saveAsAdmin)
                    {
                        command.CommandText = "UPDATE Administrators SET OverideCode = @OverideCode WHERE AdminID = @AdminID;";

                        command.Parameters.AddWithValue("@AdminID", employee.EmployeeID);
                        command.Parameters.AddWithValue("@OverideCode", employee.OverrideCode);

                        command.ExecuteNonQuery();
                    }

                    if (!loadedAsAdmin && saveAsAdmin)
                    {
                        command.CommandText = "INSERT INTO Administrators (AdminID, OverideCode) VALUES (@AdminID, @OverideCode);";

                        command.Parameters.AddWithValue("@AdminID", employee.EmployeeID);
                        command.Parameters.AddWithValue("@OverideCode", employee.OverrideCode);

                        command.ExecuteNonQuery();
                    }

                    if (loadedAsAdmin && !saveAsAdmin)
                    {
                        command.CommandText = "DELETE FROM INTO Administrators WHERE AdminID = @AdminID;";

                        command.Parameters.AddWithValue("@AdminID", employee.EmployeeID);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Staff member successfully updated!");
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
            if(cmb_priv.SelectedItem.ToString() == "admin")
            {
                txt_code.Enabled = true;
                saveAsAdmin = true;
            }
            else
            {
                txt_code.Enabled = false;
                saveAsAdmin = false;
            }

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
