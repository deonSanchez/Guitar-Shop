using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Form for creating and modifying Promotions.
    /// </summary>
    public partial class PromotionForm : Form
    {
        private Promotion promotion;

        bool creating = true;
        int editItemID;

        SqlConnection cnn;

        public PromotionForm(bool creating, int editItemID)
        {
            InitializeComponent();

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
            
            LoadProducts();

            if (creating)
            {
                promotion = new Promotion();
                promotion.StartDate = dt_start.Value;
                promotion.EndDate = dt_end.Value;
            }
            else
            {
                this.creating = false;
                this.editItemID = editItemID;

                btn_add.Text = "Update";

                PreloadData();
            }

        }

        private void ValidateForm()
        {
            if (cmb_product.SelectedIndex > -1
                && txt_description.Text != "")
            {
                btn_add.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
            }
        }

        private void LoadProducts()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID, ProductName FROM Products";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString(), Convert.ToInt32(reader[0]));
                        cmb_product.Items.Add(cbi);
                    }
                }
            }
        }

        private void PreloadData()
        {
            promotion = new Promotion();

            promotion.ProductID = editItemID;

            // Load in Promotion details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT PromotionCode, ProductID, DiscountAmount, Description, StartDate, EndDate FROM Promotions WHERE PromotionCode = @PromotionCode";

                command.Parameters.AddWithValue("@PromotionCode", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        promotion.PromotionCode = Convert.ToInt32(reader[0]);
                        promotion.ProductID = Convert.ToInt32(reader[1]);
                        promotion.DiscountAmount = Convert.ToDecimal(reader[2]);
                        promotion.Description = reader[3].ToString();
                        promotion.StartDate = Convert.ToDateTime(reader[4]);
                        promotion.EndDate = Convert.ToDateTime(reader[5]);
                    }
                }
            }

            Constants.SetComboBoxToItemWithID(cmb_product, promotion.ProductID);

            num_discountAmount.Value = promotion.DiscountAmount;
            txt_description.Text = promotion.Description;
            dt_start.Value = promotion.StartDate;
            dt_end.Value = promotion.EndDate;   
        }

        private void ProcessPromotion()
        {
            if (creating)
            {
                // Insert Promotion
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Promotions (ProductID, DiscountAmount, Description, StartDate, EndDate) VALUES (@ProductID, @DiscountAmount, @Description, @StartDate, @EndDate)";

                    command.Parameters.AddWithValue("@ProductID", promotion.ProductID);
                    command.Parameters.AddWithValue("@DiscountAmount", promotion.DiscountAmount);
                    command.Parameters.AddWithValue("@Description", promotion.Description);
                    command.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                    command.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                    command.ExecuteScalar();
                    MessageBox.Show("Promotion succefully created!");
                }
            }
            else
            {
                // Edit Promotion
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Promotions SET ProductID = @ProductID, DiscountAmount = @DiscountAmount, Description = @Description, StartDate = @StartDate, EndDate = @EndDate WHERE PromotionCode = @PromotionCode";

                    command.Parameters.AddWithValue("@PromotionCode", editItemID);
                    command.Parameters.AddWithValue("@ProductID", promotion.ProductID);
                    command.Parameters.AddWithValue("@DiscountAmount", promotion.DiscountAmount);
                    command.Parameters.AddWithValue("@Description", promotion.Description);
                    command.Parameters.AddWithValue("@StartDate", promotion.StartDate);
                    command.Parameters.AddWithValue("@EndDate", promotion.EndDate);

                    command.ExecuteScalar();
                    MessageBox.Show("Promotion succefully created!");
                }
            }

            cnn.Close();
            Close();
        }
        
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ProcessPromotion();
        }

        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            promotion.ProductID = (cmb_product.SelectedItem as ComboBoxItem).IdentifyingValue;
            ValidateForm();
        }

        private void num_discountAmount_ValueChanged(object sender, EventArgs e)
        {
            promotion.DiscountAmount = num_discountAmount.Value;
            ValidateForm();
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {
            promotion.Description = txt_description.Text;
            ValidateForm();
        }

        private void dt_start_ValueChanged(object sender, EventArgs e)
        {
            promotion.StartDate = dt_start.Value;
            ValidateForm();
        }

        private void dt_end_ValueChanged(object sender, EventArgs e)
        {
            promotion.EndDate = dt_end.Value;
            ValidateForm();
        }
    }
}
