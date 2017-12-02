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
        private static string[] cardTypes = new string[] {"Visa", "Discover", "Mastercard", "American Express"};

        private Order order;
        private Payment payment;

        bool creating = true;
        int editItemID;

        SqlConnection cnn;

        public OrderForm(bool creating, int editItemID)
        {
            InitializeComponent();

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

            if (creating)
            {
                order = new Order();
                payment = new Payment();
            }
            else
            {
                this.creating = false;
                this.editItemID = editItemID;

                btn_sumbit.Text = "Update";

                PreloadData();
            }
        }

        private void PreloadData()
        {
            order = new Order();
            payment = new Payment();

            order.OrderID = editItemID;

            // Load in Order details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustomerID, ShipAmount, TaxAmount, ShipAddressID FROM Orders WHERE OrderId = @OrderID";

                command.Parameters.AddWithValue("@OrderID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.CustomerID = Convert.ToInt32(reader[0]);
                        order.ShipAmount = Convert.ToDecimal(reader[1]);
                        order.TaxAmount = Convert.ToDecimal(reader[2]);
                        order.ShippingAddressID = Convert.ToInt32(reader[3]);
                    }
                }
            }

            // Load in OrderItem details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ItemID, ProductID, ItemPrice, PromotionCode, Quantity FROM OrderItems WHERE OrderId = @OrderID";

                command.Parameters.AddWithValue("@OrderID", editItemID);

                List<OrderItem> oiList = new List<OrderItem>();

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        OrderItem oi = new OrderItem();

                        oi.OrderItemID = Convert.ToInt32(reader[0]);
                        oi.ProductID = Convert.ToInt32(reader[1]);
                        oi.ItemPrice = Convert.ToDecimal(reader[2]);

                        if (reader[3] is DBNull)
                        {
                            oi.PromotionCode = 0;                            
                        }
                        else
                        {
                            oi.PromotionCode = Convert.ToInt32(reader[3]);
                        }
                        
                        oi.Quantity = Convert.ToInt32(reader[4]);
                        oiList.Add(oi);
                    }
                }

                foreach(OrderItem oi in oiList)
                {
                    addOrderItem(oi);
                }
            }

            // Load in Payment details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT PaymentID, CardType, CardNumber, BillingAddressID FROM Payments WHERE OrderId = @OrderID";

                command.Parameters.AddWithValue("@OrderID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        payment.PaymentID = Convert.ToInt32(reader[0]);
                        payment.CardType = reader[1].ToString();
                        payment.CardNumber = reader[2].ToString();
                        payment.BillingAddressID = Convert.ToInt32(reader[3]);
                    }
                }
            }

            LoadShippingAddresses(order.CustomerID);

            SetComboBoxToItemWithID(cmb_customer, order.CustomerID);
            SetComboBoxToItemWithID(cmb_billlingAddress, payment.BillingAddressID);
            SetComboBoxToItemWithID(cmb_shippingAddress, order.ShippingAddressID);

            txtb_cardNumber.Text = payment.CardNumber;
            cmb_cardType.Text = payment.CardType;
            updn_shipping.Value = order.ShipAmount;
            txtb_tax.Text = order.TaxAmount.ToString("F");

        }

        private void SetComboBoxToItemWithID(ComboBox cm, int ID)
        {
            foreach (ComboBoxItem cbi in cm.Items)
            {
                if(cbi.IdentifyingValue == ID)
                {
                    cm.SelectedItem = cbi;
                    return;
                }
            }
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
        private void LoadShippingAddresses(int custId)
        {
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
                    cmb_billlingAddress.SelectedIndex = -1;
                    cmb_billlingAddress.Text = "";
                    cmb_shippingAddress.Items.Clear();
                    cmb_shippingAddress.SelectedIndex = -1;
                    cmb_shippingAddress.Text = "";

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

        private void ValidateForm()
        {
            if (lv_orderItems.Items.Count > 0
                && cmb_billlingAddress.SelectedIndex > -1
                && cmb_shippingAddress.SelectedIndex > -1
                && cmb_customer.SelectedIndex > -1
                && cmb_cardType.SelectedIndex > -1) {
                btn_sumbit.Enabled = true;
            } else
            {
                btn_sumbit.Enabled = false;
            }
        }

        private void cmb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbox = (ComboBox) sender;

            int custId = (cmbox.SelectedItem as ComboBoxItem).IdentifyingValue;
            order.CustomerID = custId;

            LoadShippingAddresses(custId);

            ValidateForm();
        }

        private void btn_sumbit_Click(object sender, EventArgs e)
        {
            ProcessOrder();
        }

        public void addOrderItem(OrderItem oi)
        {
            ListViewItem oiLV = new ListViewItem();

            decimal discountAmount = 0;
            string productName = "";

            // Get the product name
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductName FROM Products WHERE ProductID = @ProductID";

                command.Parameters.AddWithValue("@ProductID", oi.ProductID);

                // TODO: Exception handling
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Should always be true
                    if (reader.Read())
                    {
                        productName = reader[0].ToString();
                    }
                    else
                    {
                        // Somehow there was an error applying the promo code to the order (perhaps it just expired)
                    }
                }
            }

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
                productName,
                oi.ItemPrice.ToString(),
                oi.Quantity.ToString(),
                discountAmount.ToString("F"),
                lineTotal.ToString("F")
            });

            lv_orderItems.Items.Add(oiLV);
            lv_orderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            CalcTotals();
            ValidateForm();
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

            if (creating)
            {
                // Insert Order
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Orders (CustomerID, OrderDate, ShipAmount, TaxAmount, ShipDate, ShipAddressID) VALUES (@CustomerID, CURRENT_TIMESTAMP, @ShipAmount, @TaxAmount, CURRENT_TIMESTAMP, @ShipAddressID); SELECT SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    command.Parameters.AddWithValue("@ShipAmount", order.ShipAmount);
                    command.Parameters.AddWithValue("@TaxAmount", order.TaxAmount);
                    command.Parameters.AddWithValue("@ShipAddressID", order.ShippingAddressID);

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
            }
            else
            {
                // Edit Order
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Orders SET CustomerID = @CustomerID, OrderDate = CURRENT_TIMESTAMP, ShipAmount = @ShipAmount, TaxAmount = @TaxAmount, ShipDate = CURRENT_TIMESTAMP, ShipAddressID = @ShipAddressID WHERE OrderID = @OrderID";

                    command.Parameters.AddWithValue("@OrderID", order.OrderID);
                    command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    command.Parameters.AddWithValue("@ShipAmount", order.ShipAmount);
                    command.Parameters.AddWithValue("@TaxAmount", order.TaxAmount);
                    command.Parameters.AddWithValue("@ShipAddressID", order.ShippingAddressID);

                    try
                    {
                        autoOrderID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Order Succefully Updated!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write order.");
                        return;
                    }
                }
            }

            if (creating)
            {
                // Insert OrderItems
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
            }
            else
            {
                // Delete OrderItems
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "DELETE FROM OrderItems WHERE OrderID = @OrderID";

                    command.Parameters.AddWithValue("@OrderID", order.OrderID);

                    command.ExecuteNonQuery();
                }

                // Re-insert OrderItems
                foreach (ListViewItem item in lv_orderItems.Items)
                {
                    OrderItem oi = item.Tag as OrderItem;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO OrderItems(OrderID, ProductID, ItemPrice, PromotionCode, Quantity) VALUES (@OrderID, @ProductID, @ItemPrice, 101, @Quantity)";

                        command.Parameters.AddWithValue("@OrderID", order.OrderID);
                        command.Parameters.AddWithValue("@ProductID", oi.ProductID);
                        command.Parameters.AddWithValue("@ItemPrice", oi.ItemPrice);
                        command.Parameters.AddWithValue("@Quantity", oi.Quantity);

                        command.ExecuteNonQuery();
                    }
                }
            }

            if (creating)
            {
                // Insert Payment
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Payments (OrderID, Timestamp, Status, CardType, CardNumber, CardExpires, BillingAddressID) VALUES (@OrderID, CURRENT_TIMESTAMP, 'complete', @CardType, @CardNumber, CURRENT_TIMESTAMP, @BillingAddressID);";

                    command.Parameters.AddWithValue("@OrderID", autoOrderID);
                    command.Parameters.AddWithValue("@CardType", payment.CardType);
                    command.Parameters.AddWithValue("@CardNumber", payment.CardNumber);
                    command.Parameters.AddWithValue("@BillingAddressID", payment.BillingAddressID);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write payment.");
                        return;
                    }
                }
            }
            else
            {
                // Edit Payment
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Payments SET OrderID = @OrderID, Timestamp = CURRENT_TIMESTAMP, Status = 'revised', CardType = @CardType, CardNumber = @CardNumber, CardExpires = CURRENT_TIMESTAMP, BillingAddressID = @BillingAddressID WHERE PaymentID = @PaymentID";

                    command.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                    command.Parameters.AddWithValue("@OrderID", order.OrderID);
                    command.Parameters.AddWithValue("@CardType", payment.CardType);
                    command.Parameters.AddWithValue("@CardNumber", payment.CardNumber);
                    command.Parameters.AddWithValue("@BillingAddressID", payment.BillingAddressID);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write payment.");
                        return;
                    }
                }
            }

            cnn.Close();
            Close();
        }

        private void cmb_cardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbox = (ComboBox)sender;
            payment.CardType = (string)cmbox.SelectedItem;
            ValidateForm();
        }

        private void txtb_cardNumber_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            payment.CardNumber = txtbox.Text;
            ValidateForm();
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
            ValidateForm();
        }

        private void updn_shipping_ValueChanged(object sender, EventArgs e)
        {
            order.ShipAmount = updn_shipping.Value;
            CalcTotals();
        }

        private void cmb_billlingAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            payment.BillingAddressID = (cmb_billlingAddress.SelectedItem as ComboBoxItem).IdentifyingValue;
            ValidateForm();
        }

        private void cmb_shippingAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            order.ShippingAddressID = (cmb_shippingAddress.SelectedItem as ComboBoxItem).IdentifyingValue;
            ValidateForm();
        }
    }
}
