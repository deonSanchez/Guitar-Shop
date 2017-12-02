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
    public partial class CustomerForm : Form
    {
        SqlConnection cnn;

        bool creating = true;
        int editItemID;

        Customer customer;

        public CustomerForm(bool creating, int editItemID)
        {
            InitializeComponent();

            customer = new Customer();

            lv_addresses.Columns.Add("", -2, HorizontalAlignment.Left); // Checkbox column
            lv_addresses.Columns.Add("Line 1", -2, HorizontalAlignment.Left);
            lv_addresses.Columns.Add("Line 2", -2, HorizontalAlignment.Left);

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

            if(!creating)
            {
                btn_add.Text = "Update";
                PreloadData();
            }
        }

        private void PreloadData()
        {
            customer = new Customer();

            customer.CustomerID = editItemID;

            // Load in Customer details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT FirstName, LastName, EmailAddress, Password, EmployeeContact FROM Customers WHERE CustomerID = @CustomerID";

                command.Parameters.AddWithValue("@CustomerID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer.firstName = reader[0].ToString();
                        customer.lastName = reader[1].ToString();
                        customer.emailAddress = reader[2].ToString();
                        customer.password = reader[3].ToString();
                        customer.employeeContact = Convert.ToInt32(reader[4]);
                    }
                }

                txt_firstName.Text = customer.firstName;
                txt_lastName.Text = customer.lastName;
                txt_email.Text = customer.emailAddress;
                txt_password.Text = customer.password;

                Constants.SetComboBoxToItemWithID(cmb_employeeContact, customer.employeeContact);

            }

            // Load in Address details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Line1, Line2, City, State, Phone, ZipCode FROM CustAddresses WHERE CustAddressID = @CustAddressID";

                command.Parameters.AddWithValue("@CustAddressID", editItemID);

                List<Address> addrList = new List<Address>();

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Address addr = new Address();

                        addr.line1 = reader[0].ToString();
                        addr.line2 = reader[1].ToString();
                        addr.city = reader[2].ToString();
                        addr.state = reader[3].ToString();
                        addr.phoneNumber = reader[4].ToString();
                        addr.zip = Convert.ToInt32(reader[5]);
                        
                        addrList.Add(addr);
                    }
                }

                foreach (Address addr in addrList)
                {
                    AddAddress(addr);
                }
            }
        }

        public void AddAddress(Address address)
        {
            ListViewItem aLV = new ListViewItem();

            aLV.Tag = address;
            aLV.SubItems.AddRange(new String[] {
                address.line1,
                address.line2
            });

            lv_addresses.Items.Add(aLV);
            lv_addresses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void cmb_employeeContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer.employeeContact = (cmb_employeeContact.SelectedItem as ComboBoxItem).IdentifyingValue;
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
                            ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString() + " " + reader[2].ToString(), Convert.ToInt32(reader[0]));
                            cmb_employeeContact.Items.Add(cbi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }

        private void btn_cancel(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }

        private void btn_submit(object sender, EventArgs e)
        {
            CreateCustomer();
        }

        private void CreateCustomer()
        {
            int autoCustomerID = 0;

            customer.emailAddress = txt_email.Text;
            customer.password = txt_password.Text;
            customer.firstName = txt_firstName.Text;
            customer.lastName = txt_lastName.Text;

            if (creating)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Customers (EmailAddress, Password, FirstName, LastName, EmployeeContact) VALUES (@EmailAddress, @Password, @FirstName, @LastName, @EmployeeContact); SELECT SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("@EmailAddress", customer.emailAddress);
                    command.Parameters.AddWithValue("@Password", customer.password);
                    command.Parameters.AddWithValue("@FirstName", customer.firstName);
                    command.Parameters.AddWithValue("@LastName", customer.lastName);
                    command.Parameters.AddWithValue("@EmployeeContact", customer.employeeContact);

                    try
                    {
                        autoCustomerID = Convert.ToInt32(command.ExecuteScalar());
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
                    command.CommandText = "UPDATE Customers SET EmailAddress = @EmailAddress, Password = @Password, FirstName = @FirstName, LastName = @LastName, EmployeeContact = @EmployeeContact WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    command.Parameters.AddWithValue("@EmailAddress", customer.emailAddress);
                    command.Parameters.AddWithValue("@Password", customer.password);
                    command.Parameters.AddWithValue("@FirstName", customer.firstName);
                    command.Parameters.AddWithValue("@LastName", customer.lastName);
                    command.Parameters.AddWithValue("@EmployeeContact", customer.employeeContact);

                    try
                    {
                        autoCustomerID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Customer successfully updated!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write customer.");
                        return;
                    }
                }
            }

            if (creating)
            {
                foreach (ListViewItem item in lv_addresses.Items)
                {
                    Address address = item.Tag as Address;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO CustAddresses(CustomerID, Line1, Line2, City, State, ZipCode, Phone) VALUES (@CustomerID, @Line1, @Line2, @City, @State, @ZipCode, @Phone)";

                        command.Parameters.AddWithValue("@CustomerID", autoCustomerID);
                        command.Parameters.AddWithValue("@Line1", address.line1);
                        command.Parameters.AddWithValue("@Line2", address.line2);
                        command.Parameters.AddWithValue("@City", address.city);
                        command.Parameters.AddWithValue("@State", address.state);
                        command.Parameters.AddWithValue("@ZipCode", address.zip.ToString());
                        command.Parameters.AddWithValue("@Phone", address.phoneNumber);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Could not write Address.");
                        }
                    }
                }
            }
            else
            {
                // Delete OrderItems
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "DELETE FROM CustAddresses WHERE CustomerID = @CustomerID";

                    command.Parameters.AddWithValue("@CustomerID", editItemID);

                    command.ExecuteNonQuery();
                }

                foreach (ListViewItem item in lv_addresses.Items)
                {
                    Address address = item.Tag as Address;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO CustAddresses(CustomerID, Line1, Line2, City, State, ZipCode, Phone) VALUES (@CustomerID, @Line1, @Line2, @City, @State, @ZipCode, @Phone)";

                        command.Parameters.AddWithValue("@CustomerID", editItemID);
                        command.Parameters.AddWithValue("@Line1", address.line1);
                        command.Parameters.AddWithValue("@Line2", address.line2);
                        command.Parameters.AddWithValue("@City", address.city);
                        command.Parameters.AddWithValue("@State", address.state);
                        command.Parameters.AddWithValue("@ZipCode", address.zip.ToString());
                        command.Parameters.AddWithValue("@Phone", address.phoneNumber);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }

            cnn.Close();
            Close();
        }

        private void lv_addresses_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // If at least one item is checked, then the user may remove checked items from the list.
            if (lv_addresses.CheckedItems.Count > 0)
            {
                btn_addressRemove.Enabled = true;
            }
            else
            {
                btn_addressRemove.Enabled = false;
            }
        }

        private void btn_addressRemove_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = lv_addresses.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                lv_addresses.Items.Remove(item);
                lv_addresses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void btn_addressAdd_Click(object sender, EventArgs e)
        {
            AddressForm af = new AddressForm(this);
            af.Show();
        }
    }
}
