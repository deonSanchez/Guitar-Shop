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

        SqlConnection cnn;

        public OrderForm()
        {
            InitializeComponent();

            order = new Order();

            lv_orderItems.Columns.Add("", -2, HorizontalAlignment.Left); // Checkbox column
            lv_orderItems.Columns.Add("Item", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Price", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Quantity", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Discount", -2, HorizontalAlignment.Left);
            lv_orderItems.Columns.Add("Line Total", -2, HorizontalAlignment.Left);

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
                        while (reader.Read())
                        {
                            ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString(), Convert.ToInt32(reader[0]));
                            cmb_customer.Items.Add(cbi);                            
                        }
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

            int custId = (cmbox.SelectedItem as ComboBoxItem).IdentifyingValue;
            order.CustomerID = custId;

            // Load the selected customer's avaliable addresses
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustAddressID, Line1, City, State, ZipCode FROM CustAddresses WHERE CustomerID = @CustomerID";

                command.Parameters.AddWithValue("@CustomerID", custId);

                // TODO: Exception handling
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    cmb_billlingAddress.Items.Clear();
                    cmb_shippingAddress.Items.Clear();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            string addressString = string.Format(
                                "{0} {1}, {2} {3}",
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString()
                            );

                            ComboBoxItem cbi = new ComboBoxItem(addressString, Convert.ToInt32(reader[0]));
                            cmb_billlingAddress.Items.Add(cbi);
                            cmb_shippingAddress.Items.Add(cbi);
                        }

                        cmb_billlingAddress.Enabled = true;
                        cmb_shippingAddress.Enabled = true;
                    }
                    else
                    {
                        cmb_billlingAddress.Enabled = false;
                        cmb_shippingAddress.Enabled = false;
                    }
                }
            }
        }

        private void btn_sumbit_Click(object sender, EventArgs e)
        {
            ProcessOrder();
        }

        public void addOrderItem(OrderItem oi)
        {
            ListViewItem oiLV = new ListViewItem();

            decimal discountAmount = 0;

            // If has a promo code, get the discount amount
            if (oi.PromotionCode != 0)
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT DiscountAmount FROM Promotions WHERE ProductID = @ProductID AND PromotionCode = @PromotionCode AND CURRENT_TIMESTAMP BETWEEN StartDate AND EndDate";

                    command.Parameters.AddWithValue("@ProductID", oi.ProductID);
                    command.Parameters.AddWithValue("@PromotionCode", oi.PromotionCode);

                    // TODO: Exception handling
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Should always be true
                        if (reader.Read())
                        {
                            discountAmount = (decimal)reader[0];
                        }
                        else
                        {
                            // Somehow there was an error applying the promo code to the order (perhaps it just expired)
                        }
                    }
                }
            }

            decimal lineTotal = (oi.ItemPrice * oi.Quantity) - discountAmount;

            oiLV.Tag = oi;
            oiLV.SubItems.AddRange(new String[] {
                oi.ProductName,
                oi.ItemPrice.ToString(),
                oi.Quantity.ToString(),
                discountAmount.ToString("F"),
                lineTotal.ToString("F")
            });

            lv_orderItems.Items.Add(oiLV);
            lv_orderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            CalcTotals();
        }

        public void CalcTotals()
        {
            decimal totalPrice = 0;

            foreach(ListViewItem item in lv_orderItems.Items)
            {
                OrderItem oi = item.Tag as OrderItem;
                totalPrice += decimal.Parse(item.SubItems[5].Text);
            }

            txtb_subtotal.Text = totalPrice.ToString("F");

            order.TaxAmount = totalPrice * (decimal)0.07;
            txtb_tax.Text = order.TaxAmount.ToString("F");

            txtb_orderTotal.Text = ((totalPrice + order.TaxAmount) + updn_shipping.Value).ToString("F");
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

            foreach (ListViewItem item in lv_orderItems.Items)
            {
                OrderItem oi = item.Tag as OrderItem;

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "INSERT INTO OrderItems(OrderID, ProductID, ItemPrice, PromotionCode, Quantity) VALUES (@OrderID, @ProductID, @ItemPrice, 101, @Quantity)";

                    command.Parameters.AddWithValue("@OrderID", autoOrderID);
                    command.Parameters.AddWithValue("@ProductID", oi.ProductID);
                    command.Parameters.AddWithValue("@ItemPrice", oi.ItemPrice);
                    command.Parameters.AddWithValue("@Quantity", oi.Quantity);

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
        
        private void lv_orderItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // If at least one item is checked, then the user may remove checked items from the list.
            if(lv_orderItems.CheckedItems.Count > 0) 
            {
                btn_orderItemsRemove.Enabled = true;
            }
            else
            {
                btn_orderItemsRemove.Enabled = false;
            }
        }

        private void btn_orderItemsRemove_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = lv_orderItems.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                lv_orderItems.Items.Remove(item);
                lv_orderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            CalcTotals();
        }

        private void updn_shipping_ValueChanged(object sender, EventArgs e)
        {
            order.ShipAmount = updn_shipping.Value;
            CalcTotals();
        }
    }
}
