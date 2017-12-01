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

        private bool promoCodeIsValid = true;

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

            lbl_validation.Visible = false;
        }
        
        private void loadItems()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID, ProductName, Price FROM Products WHERE ProductType = 'instrument';";

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
                            orderItemRegistry.Add(displayString, new OrderItem(int.Parse(reader[0].ToString()), decimal.Parse(reader[2].ToString()), reader[1].ToString()));
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

        private void ValidateForm()
        {
            if(promoCodeIsValid && selected != null)
            {
                btn_add.Enabled = true;
            } 
            else
            {
                btn_add.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderItemRegistry.TryGetValue(((ComboBox)sender).Text, out selected);
            txtb_promoCode.Enabled = true;
            CheckPromoCode();
            ValidateForm();
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

        private void CheckPromoCode()
        {
            int promoCode = 0;

            // If nothing is entered, don't worry about promo code or validation.
            if (txtb_promoCode.Text == "")
            {
                lbl_validation.Visible = false;
                promoCodeIsValid = true;
                ValidateForm();

                return;
            }

            try
            {
                promoCode = Convert.ToInt32(txtb_promoCode.Text);
            }
            catch (FormatException)
            {
                lbl_validation.Visible = true;
                lbl_validation.ForeColor = Color.Maroon;
                lbl_validation.Text = "The code entered is not valid. Please remove or try again.";
                promoCodeIsValid = false;
                ValidateForm();

                return;
            }

            // Check if promo code is valid.
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Promotions WHERE ProductID = @ProductID AND PromotionCode = @PromotionCode AND CURRENT_TIMESTAMP BETWEEN StartDate AND EndDate";

                command.Parameters.AddWithValue("@ProductID", selected.ProductID);
                command.Parameters.AddWithValue("@PromotionCode", Convert.ToInt32(txtb_promoCode.Text));

                // TODO: Exception handling
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine(command.CommandText);

                    if (reader.Read())
                    {
                        decimal discountAmount = (decimal)reader[2];
                        lbl_validation.Visible = true;
                        lbl_validation.ForeColor = Color.DarkGreen;
                        lbl_validation.Text = string.Format("Promo code valid for ${0} off.", discountAmount.ToString("F"));
                        promoCodeIsValid = true;

                        selected.PromotionCode = Convert.ToInt32(txtb_promoCode.Text);

                        ValidateForm();
                    }
                    else
                    {
                        lbl_validation.Visible = true;
                        lbl_validation.ForeColor = Color.Maroon;
                        lbl_validation.Text = "The code entered is not valid. Please remove or try again.";
                        promoCodeIsValid = false;
                        ValidateForm();
                    }
                }
            }
        }

        private void txtb_promoCode_TextChanged(object sender, EventArgs e)
        {
            CheckPromoCode();
        }
    }
}
