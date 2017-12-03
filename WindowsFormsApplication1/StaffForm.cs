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
        SqlConnection cnn;

        bool creating = true;
        int editItemID;

        Employees employees;
    
        public Staff(bool creating, int editItemID)
        {
            InitializeComponent();

            employees = new Employees();

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

            LoadEmployees();

            this.creating = creating;
            this.editItemID = editItemID;

            if (!creating)
            {
                button1.Text = "Update";
                PreloadData();
            }
        }

        private void PreloadData()
        {
            employees = new Employees();

            employees.EmployeeID = editItemID;

            // Load in Customer details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, birthDate FROM Employees WHERE EmployeeID = @EmployeeID";

                command.Parameters.AddWithValue("@EmployeeID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employees.title = reader[0].ToString();
                        employees.firstName = reader[1].ToString();
                        employees.lastName = reader[2].ToString();
                        employees.emailAddress = reader[3].ToString();
                        employees.password = reader[4].ToString();
                        employees.birthDate = Convert.ToInt32(reader[5]);
                        employees.employeeType = reader[6].ToString();
                        employees.privilegeLevel = reader[7].ToString();
                        employees.dateHired = Convert.ToInt32(reader[8]);
                    }
                }

                titleComboBox.Text = employees.title;
                textBox1.Text = employees.firstName;
                textBox2.Text = employees.lastName;
                textBox4.Text = employees.emailAddress;
                textBox5.Text = employees.password;
                textBox8.Text = employees.birthDate.ToString();
                EmployeeTypeComboBox.Text = employees.employeeType;
                //employees.privilegeLevel;
                textBox7.Text = employees.dateHired.ToString();

                //Constants.SetComboBoxToItemWithID(EmployeeTypeComboBox, employees.employeeType);
            }
        }

       
        private void LoadEmployees()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT EmployeeID, FirstName, LastName FROM Employees";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString() + " " + reader[2].ToString(), Convert.ToInt32(reader[0]));
                            //cmb_employeeContact.Items.Add(cbi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }

        private void CreateEmployees()
        {
            int autoEmployeeID = 0;

            employees.title = titleComboBox.Text;
            employees.firstName = textBox1.Text;
            employees.lastName = textBox2.Text;
            employees.emailAddress = textBox4.Text;
            employees.password = textBox5.Text;
            //employees.birthDate = textBox8.Text;
            employees.employeeType = EmployeeTypeComboBox.Text;
            //employees.privilegeLevel = reader[7].ToString();
            //employees.dateHired = textBox7.Text;

            if (creating)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Employee (Title, FirstName, LastName, EmailAddress, Password, EmployeeType, DateHired, PrivilegeLevel, birthDate) VALUES (@Title, @FirstName, @LastName, @EmailAddress, @Password, @EmployeeType, @DateHired, @PrivilegeLevel, @birthDate); SELECT SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("@Title", employees.title);
                    command.Parameters.AddWithValue("@FirstName", employees.firstName);
                    command.Parameters.AddWithValue("@LastName", employees.lastName);
                    command.Parameters.AddWithValue("@EmailAddress", employees.emailAddress);
                    command.Parameters.AddWithValue("@Password", employees.password);
                    command.Parameters.AddWithValue("@EmployeeType", employees.employeeType);
                    command.Parameters.AddWithValue("@DateHired", employees.dateHired);
                    command.Parameters.AddWithValue("@PrivilegeLevel", employees.privilegeLevel);
                    command.Parameters.AddWithValue("@birthDate", employees.birthDate);

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

                    command.Parameters.AddWithValue("@Title", employees.title);
                    command.Parameters.AddWithValue("@FirstName", employees.firstName);
                    command.Parameters.AddWithValue("@LastName", employees.lastName);
                    command.Parameters.AddWithValue("@EmailAddress", employees.emailAddress);
                    command.Parameters.AddWithValue("@Password", employees.password);
                    command.Parameters.AddWithValue("@EmployeeType", employees.employeeType);
                    command.Parameters.AddWithValue("@DateHired", employees.dateHired);
                    command.Parameters.AddWithValue("@PrivilegeLevel", employees.privilegeLevel);
                    command.Parameters.AddWithValue("@birthDate", employees.birthDate);

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
    }
}
