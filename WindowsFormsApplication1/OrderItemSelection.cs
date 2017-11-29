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
    public partial class OrderItemSelection : Form
    {
        public OrderForm parent;

        public Dictionary<string, OrderItem> orderItemRegistry;
        public OrderItem selected;
        public int selectedQuantity;
        public float selectedPrice;

        static SqlConnection cnn;

        public OrderItemSelection(OrderForm parent)
        {
            InitializeComponent();
            this.parent = parent;

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

            orderItemRegistry = new Dictionary<string, OrderItem>();
            loadItems();
        }
        
        private void loadItems()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID, ProductName, Price FROM Products";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> customerList = new List<string>();
                                                
                        while (reader.Read())
                        {
                            string displayString = reader[0].ToString() + " - " + reader[1] + " - " + reader[2];
                            customerList.Add(displayString);
                            orderItemRegistry.Add(displayString, new OrderItem(int.Parse(reader[0].ToString()), float.Parse(reader[2].ToString()), reader[1].ToString()));
                        }

                        cmb_orderItemSelect.Items.AddRange(customerList.ToArray());
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not open Products.");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderItemRegistry.TryGetValue(((ComboBox)sender).Text, out selected);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            selected.Quantity = (int) num_quantity.Value;
            parent.addOrderItem(selected);

            cnn.Close();
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }
    }
}
