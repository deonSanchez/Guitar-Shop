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
    public partial class SupplierForm : Form
    {
        SqlConnection cnn;

        bool creating = true;
        int editItemID;

        Supplier supplier;

        public SupplierForm(bool creating, int editItemID)
        {
            InitializeComponent();

            supplier = new Supplier();

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
            
            if (!creating)
            {
                button1.Text = "Update";
                PreloadData();
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
                            ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString() + " " + reader[2].ToString(), Convert.ToInt32(reader[0]));
                            cmb_emp.Items.Add(cbi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }


        private void PreloadData()
        {
            supplier = new Supplier();

            supplier.SupplierID = editItemID;

            // Load in Supplier details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SupplierName, ContactFirstName, ContactLastName, PhoneNumber, EmployeeContact FROM Suppliers WHERE SupplierID = @SupplierID";

                command.Parameters.AddWithValue("@SupplierID", editItemID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier.SupplierName = reader[0].ToString();
                        supplier.ContactFirstName = reader[1].ToString();
                        supplier.ContactLastName = reader[2].ToString();
                        supplier.PhoneNumber = reader[3].ToString();
                        supplier.EmployeeContact = Convert.ToInt32(reader[4]);
                    }
                }

                Constants.SetComboBoxToItemWithID(cmb_emp, supplier.EmployeeContact);

                textBox2.Text = supplier.SupplierName;
                textBox3.Text = supplier.ContactFirstName;
                textBox4.Text = supplier.ContactLastName;
                textBox5.Text = supplier.PhoneNumber;
            }

            // Load Supplier Addresses
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Line1, Line2, City, State, ZipCode FROM SupplierAddress WHERE SupplierID = @SupplierID";

                command.Parameters.AddWithValue("@SupplierID", editItemID);

                List<SupplierAddress> supAddrList = new List<SupplierAddress>();

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierAddress supAdd = new SupplierAddress();

                        supAdd.Line1 = reader[0].ToString();
                        supAdd.Line2 = reader[1].ToString();
                        supAdd.City = reader[2].ToString();
                        supAdd.State = reader[3].ToString();
                        supAdd.ZipCode = Convert.ToInt32(reader[4]);

                        supAddrList.Add(supAdd);
                    }
                }

                foreach (SupplierAddress supadd in supAddrList)
                {
                    AddSupAddress(supadd);
                }
            }
        }

        public void AddSupAddress(SupplierAddress supAddress)
        {
            ListViewItem spLV = new ListViewItem();

            spLV.Tag = supAddress;
            spLV.SubItems.AddRange(new String[] {
                supAddress.Line1,
                supAddress.Line2
            });

            lv_addresses.Items.Add(spLV);
            lv_addresses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void CreateSuppliers()
        {
            int autoSupplierID = 0;

            supplier.SupplierName = textBox2.Text;
            supplier.ContactFirstName = textBox3.Text;
            supplier.ContactLastName = textBox4.Text;
            supplier.PhoneNumber = textBox5.Text;

            if (creating)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Suppliers (SupplierName, ContactFirstName, ContactLastName, PhoneNumber, EmployeeContact) VALUES (@SupplierName, @ContactFirstName, @ContactLastName, @PhoneNumber, @EmployeeContact);";

                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@ContactFirstName", supplier.ContactFirstName);
                    command.Parameters.AddWithValue("@ContactLastName", supplier.ContactLastName);
                    command.Parameters.AddWithValue("@PhoneNumber", supplier.PhoneNumber);
                    command.Parameters.AddWithValue("@EmployeeContact", supplier.EmployeeContact);

                    try
                    {
                        autoSupplierID = Convert.ToInt32(command.ExecuteScalar());
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
                    command.CommandText = "UPDATE Suppliers SET SupplierName = @SupplierName, ContactFirstName = @ContactFirstName, ContactLastName = @ContactLastName, PhoneNumber = @PhoneNumber WHERE SupplierID = @SupplierID";

                    command.Parameters.AddWithValue("@SupplierID", editItemID);
                    command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                    command.Parameters.AddWithValue("@ContactFirstName", supplier.ContactFirstName);
                    command.Parameters.AddWithValue("@ContactLastName", supplier.ContactLastName);
                    command.Parameters.AddWithValue("@PhoneNumber", supplier.PhoneNumber);
                    command.Parameters.AddWithValue("@EmployeeContact", supplier.EmployeeContact);

                    autoSupplierID = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Customer successfully updated!");
                }
            }

            if (creating)
            {
                foreach (ListViewItem item in lv_addresses.Items)
                {
                    SupplierAddress supaddress = item.Tag as SupplierAddress;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO SupplierAddress(SupplierID, Line1, Line2, City, State, ZipCode) VALUES (@SupplierID, @Line1, @Line2, @City, @State, @ZipCode)";

                        command.Parameters.AddWithValue("@SupplierID", autoSupplierID);
                        command.Parameters.AddWithValue("@Line1", supaddress.Line1);
                        command.Parameters.AddWithValue("@Line2", supaddress.Line2);
                        command.Parameters.AddWithValue("@City", supaddress.City);
                        command.Parameters.AddWithValue("@State", supaddress.State);
                        command.Parameters.AddWithValue("@ZipCode", supaddress.ZipCode.ToString());

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
                // Delete Address
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "DELETE FROM SupplierAddress WHERE SupplierID = @SupplierID";

                    command.Parameters.AddWithValue("@SupplierID", editItemID);

                    command.ExecuteNonQuery();
                }

                foreach (ListViewItem item in lv_addresses.Items)
                {
                    SupplierAddress supaddress = item.Tag as SupplierAddress;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO SupplierAddress(SupplierID, Line1, Line2, City, State, ZipCode) VALUES (@SupplierID, @Line1, @Line2, @City, @State, @ZipCode)";

                        command.Parameters.AddWithValue("@SupplierID", editItemID);
                        command.Parameters.AddWithValue("@Line1", supaddress.Line1);
                        command.Parameters.AddWithValue("@Line2", supaddress.Line2);
                        command.Parameters.AddWithValue("@City", supaddress.City);
                        command.Parameters.AddWithValue("@State", supaddress.State);
                        command.Parameters.AddWithValue("@ZipCode", supaddress.ZipCode.ToString());
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
                button3.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSuppliers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddressForm af = new AddressForm(this, "suppliers");
            af.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = lv_addresses.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                lv_addresses.Items.Remove(item);
                lv_addresses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}
