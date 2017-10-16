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

/// <summary>
/// Create a new order with user-provided data values.
/// 
/// TODO: validation. Check out https://docs.microsoft.com/en-us/dotnet/framework/winforms/user-input-validation-in-windows-forms.
/// </summary>
namespace GuitarShop
{
    public partial class OrderForm : Form
    {
        private static string connetionString = "Data Source=CEIT2553214X016\\LOCAL;Initial Catalog=MyGuitarShop;Integrated Security=True";
        private static string[] cardTypes = new string[] {"Credit", "Debit", "EagleID"};

        private Order order;

        public OrderForm()
        {
            InitializeComponent();
            order = new Order();

            loadCustomers();
            cmb_cardType.Items.AddRange(cardTypes);
        }

        private void loadCustomers()
        {
            SqlConnection cnn = new SqlConnection(connetionString);

            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    cnn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: the connection could not be opened.");
                }
                
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustomerID, EmailAddress FROM Customers";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> customerList = new List<string>();

                       // while there is another record present
                        while (reader.Read())
                        {
                            customerList.Add(reader[0].ToString() + " - " + reader[1]);                            
                        }

                        cmb_customer.Items.AddRange(customerList.ToArray());
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }

        private void btn_customerCreate_Click(object sender, EventArgs e)
        {
            // TODO: This should open a CustomerForm which will be used to create and modify customers.
        }

        private void cmb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbox = (ComboBox) sender;
            string selectedCustomer = (string) cmbox.SelectedItem;
            int selectedCustomerID = int.Parse(selectedCustomer[0].ToString());
            order.CustomerID = selectedCustomerID;
        }

        private void btn_sumbit_Click(object sender, EventArgs e)
        {
            processOrder();
        }

        private void processOrder()
        {
            SqlConnection cnn = new SqlConnection(connetionString);

            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    cnn.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: the connection could not be opened.");
                }

                // https://stackoverflow.com/questions/19956533/sql-insert-query-using-c-sharp

                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Orders (CustomerID, OrderDate, ShipAmount, TaxAmount, ShipDate, ShipAddressID, CardType, CardNumber, CardExpires, BillingAddressID) VALUES (@CustomerID, CURRENT_TIMESTAMP, @ShipAmount, @TaxAmount, CURRENT_TIMESTAMP, 1, @CardType, @CardNumber, '04/2014', 1)";

                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@ShipAmount", order.ShipAmount);
                command.Parameters.AddWithValue("@TaxAmount", order.TaxAmount);
                command.Parameters.AddWithValue("@CardType", order.CardType);
                command.Parameters.AddWithValue("@CardNumber", order.CardNumber);

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Order Succefully Placed!");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not write order.");
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("Could not write order.");
                }
            }

            cnn.Close();
        }

        private void cmb_cardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbox = (ComboBox)sender;
            order.CardType = (string)cmbox.SelectedItem;
        }

        private void txtb_cardNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            order.CardNumber = txtbox.Text;
        }
    }
}
