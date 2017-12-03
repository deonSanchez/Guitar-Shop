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
        SupplierAddress supplierAddress;

        public SupplierForm(bool creating, int editItemID)
        {
            this.creating = creating;
            this.editItemID = editItemID;

            InitializeComponent();

            supplier = new Supplier();

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

            //LoadSuppliers();

            if (!creating)
            {
                button1.Text = "Update";
                PreloadData();
            }
        }

        private void PreloadData()
        {
            supplier = new Supplier();
            supplierAddress = new SupplierAddress();

            supplier.SupplierID = editItemID;

            // Load in SUpplier details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SupplierName, ContactFirstName, ContactLastName, PhoneNumber, EmployeeContact FROM Supplier WHERE SupplierID = @SupplierID";

                command.Parameters.AddWithValue("@SupplierID", editItemID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier.SupplierName = reader[0].ToString();
                        supplier.ContactFirstName = reader[1].ToString();
                        supplier.ContactLastName = reader[2].ToString();
                        supplier.PhoneNumber = reader[3].ToString();
                    }
                }

                textBox2.Text = supplier.SupplierName;
                textBox3.Text = supplier.ContactFirstName;
                textBox4.Text = supplier.ContactLastName;
                textBox5.Text = supplier.PhoneNumber;
            }

            //Load Supplier Address
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Line1, Line2, city, state, zipcode FROM supplierAddress WHERE SupplierAddressID = @SupplierAddressID";

                command.Parameters.AddWithValue("@SupplierAddressID", editItemID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplierAddress.Line1 = reader[0].ToString();
                        supplierAddress.Line2 = reader[1].ToString();
                        supplierAddress.City = reader[2].ToString();
                        supplierAddress.State = reader[3].ToString();
                        supplierAddress.ZipCode = Convert.ToInt32(reader[4]);
                    }
                }

                textBox2.Text = supplier.SupplierName;
                textBox3.Text = supplier.ContactFirstName;
                textBox4.Text = supplier.ContactLastName;
                textBox5.Text = supplier.PhoneNumber;

                textBox7.Text = supplierAddress.Line1;
                textBox6.Text = supplierAddress.Line2;
                textBox8.Text = supplierAddress.City;
                textBox9.Text = supplierAddress.State;
                textBox10.Text = supplierAddress.ZipCode.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create suppliers
        }
    }
}
