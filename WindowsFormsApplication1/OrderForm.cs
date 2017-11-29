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
using System.Configuration;

/// <summary>
/// Create a new order with user-provided data values.
/// 
/// TODO: validation. Check out https://docs.microsoft.com/en-us/dotnet/framework/winforms/user-input-validation-in-windows-forms.
/// 
/// TODO: Data binding - audio update total fields, etc.
/// 
/// Danny:
/// Orders
/// OrderItems
/// Repairs
/// RepairItems
/// Products
/// Promotions
/// Payments
/// 
/// Deon:
/// Employees
/// Cusomters
/// Administrators
/// Suppliers
/// Addreses
/// 
/// 
/// 
/// </summary>
namespace GuitarShop
{
    public partial class OrderForm : Form
    {
        private static string[] cardTypes = new string[] {"Credit", "Debit", "EagleID"};

        private Order order;
        private List<OrderItem> orderItems;

        SqlConnection cnn;

        public OrderForm()
        {
            InitializeComponent();

            order = new Order();
            orderItems = new List<OrderItem>();
            
            lv_orderItems.Columns.Add("Item", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Price", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Quantity", -2, HorizontalAlignment.Left);

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

            LoadCustomers();
            cmb_cardType.Items.AddRange(cardTypes);
        }

        private void LoadCustomers()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustomerID, EmailAddress FROM Customers";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> customerList = new List<string>();

                        while (reader.Read())
                        {
                            customerList.Add(reader[0].ToString() + " - " + reader[1]);                            
                        }

                        cmb_customer.Items.AddRange(customerList.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
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
            ProcessOrder();
        }

        public void addOrderItem(OrderItem oi)
        {
            orderItems.Add(oi);
            lv_orderItems.Items.Add(new ListViewItem(new String[] { oi.ProductName, oi.ItemPrice.ToString(), oi.Quantity.ToString() }));
            lv_orderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            CalcTotals();
        }

        public void CalcTotals()
        {
            float totalPrice = 0;

            foreach(OrderItem item in orderItems)
            {
                totalPrice += (item.ItemPrice * item.Quantity);
            }

            txtb_subtotal.Text = totalPrice.ToString();
            order.TaxAmount = (float) Math.Round(totalPrice * 0.07, 2);
            txtb_tax.Text = (Math.Round(totalPrice * 0.07, 2)).ToString();
            txtb_orderTotal.Text = (Math.Round(totalPrice * 1.07, 2) + float.Parse(txtb_shipping.Text)).ToString();
        }

        private void ProcessOrder()
        {
            int autoOrderID = 0;

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Orders (CustomerID, OrderDate, ShipAmount, TaxAmount, ShipDate, ShipAddressID) VALUES (@CustomerID, CURRENT_TIMESTAMP, @ShipAmount, @TaxAmount, CURRENT_TIMESTAMP, 1); SELECT SCOPE_IDENTITY()";

                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@ShipAmount", order.ShipAmount);
                command.Parameters.AddWithValue("@TaxAmount", order.TaxAmount);
                
                try
                {
                    autoOrderID = Convert.ToInt32(command.ExecuteScalar());
                    MessageBox.Show("Order Succefully Placed!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not write order.");
                    return;
                }
            }

            foreach (OrderItem item in orderItems)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "INSERT INTO OrderItems(OrderID, ProductID, ItemPrice, PromotionCode, Quantity) VALUES (@OrderID, @ProductID, @ItemPrice, 101, @Quantity)";

                    command.Parameters.AddWithValue("@OrderID", autoOrderID);
                    command.Parameters.AddWithValue("@ProductID", item.ProductID);
                    command.Parameters.AddWithValue("@ItemPrice", item.ItemPrice);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Could not write OrderItem.");
                    }
                }
            }

            cnn.Close();
            Close();
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

        private void btn_orderItemsAdd_Click(object sender, EventArgs e)
        {
            OrderItemSelection ois = new OrderItemSelection(this);
            ois.Show();
        }

        private void txtb_shipping_TextChanged(object sender, EventArgs e)
        {
            order.ShipAmount = float.Parse(txtb_shipping.Text);
            CalcTotals();
        }
    }
}
