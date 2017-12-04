using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Form for creating and modifying Product.
    /// </summary>
    public partial class ProductForm : Form
    {
        private static string[] productTypes = new string[] { "Instrument", "Part" };

        private Product product;

        bool creating = true;
        int editItemID;

        SqlConnection cnn;

        public ProductForm(bool creating, int editItemID)
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

            LoadCategories();
            LoadSuppliers();

            cmb_type.Items.AddRange(productTypes);

            if (creating)
            {
                product = new Product();
                product.DateAdded = dateTimePicker1.Value; // Today
            }
            else
            {
                this.creating = false;
                this.editItemID = editItemID;

                btn_add.Text = "Update";

                PreloadData();
            }
        }

        private void PreloadData()
        {
            product = new Product();

            product.ProductID = editItemID;

            // Load in Product details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID, CategoryID, SupplierID, ProductName, ProductType, Description, AmountInStock, Price, DateAdded FROM Products WHERE ProductID = @ProductID";

                command.Parameters.AddWithValue("@ProductID", editItemID);

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product.ProductID = Convert.ToInt32(reader[0]);
                        product.CategoryID = Convert.ToInt32(reader[1]);
                        product.SupplierID = Convert.ToInt32(reader[2]);
                        product.ProductName = reader[3].ToString();
                        product.ProductType = reader[4].ToString();
                        product.Description = reader[5].ToString();
                        product.AmountInStock = Convert.ToInt32(reader[6]);
                        product.Price = Convert.ToDecimal(reader[7]);
                        product.DateAdded = Convert.ToDateTime(reader[8]);
                    }
                }
            }

            Constants.SetComboBoxToItemWithID(cmb_cat, product.CategoryID);
            Constants.SetComboBoxToItemWithID(cmb_supplier, product.SupplierID);

            cmb_type.Text = product.ProductType;

            txt_name.Text = product.ProductName;
            txt_description.Text = product.Description;
            num_stock.Value = product.AmountInStock;
            num_price.Value = product.Price;
            dateTimePicker1.Value = product.DateAdded;
        }

        private void LoadCategories()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CategoryID, CategoryName FROM Categories";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString(), Convert.ToInt32(reader[0]));
                        cmb_cat.Items.Add(cbi);
                    }
                }
            }
        }

        private void LoadSuppliers()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT SupplierID, SupplierName FROM Suppliers";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComboBoxItem cbi = new ComboBoxItem(reader[1].ToString(), Convert.ToInt32(reader[0]));
                            cmb_supplier.Items.Add(cbi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }

        private void ValidateForm()
        {
            if (cmb_cat.SelectedIndex > -1
                && cmb_supplier.SelectedIndex > -1
                && cmb_type.Text != ""
                && txt_description.Text != ""
                && txt_name.Text != "")
            {
                btn_add.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
            }
        }
        
        private void ProcessProduct()
        {
            if (creating)
            {
                // Insert Product
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Products (CategoryID, SupplierID, ProductName, ProductType, Description, AmountInStock, Price, DateAdded) VALUES (@CategoryID, @SupplierID, @ProductName, @ProductType, @Description, @AmountInStock, @Price, @DateAdded);";

                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductType", product.ProductType);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@AmountInStock", product.AmountInStock);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@DateAdded", product.DateAdded);

                    command.ExecuteScalar();
                    MessageBox.Show("Product succefully created!");
                }
            }
            else
            {
                // Edit Product
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Update Products SET CategoryID = @CategoryID, SupplierID = @SupplierID, ProductName = @ProductName, ProductType = @ProductType, Description = @Description, AmountInStock = @AmountInStock, Price = @Price, DateAdded = @DateAdded WHERE ProductID = @ProductID";

                    command.Parameters.AddWithValue("@ProductID", editItemID);
                    command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductType", product.ProductType);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@AmountInStock", product.AmountInStock);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@DateAdded", product.DateAdded);

                    command.ExecuteScalar();
                    MessageBox.Show("Product succesfully updated!");
                }
            }

            cnn.Close();
            Close();
        }

        private void cmb_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.CategoryID = (cmb_cat.SelectedItem as ComboBoxItem).IdentifyingValue;
            ValidateForm();
        }

        private void cmb_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.SupplierID = (cmb_supplier.SelectedItem as ComboBoxItem).IdentifyingValue;
            ValidateForm();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            product.ProductName = txt_name.Text;
            ValidateForm();
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.ProductType = cmb_type.Text;
            ValidateForm();
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {
            product.Description = txt_description.Text;
            ValidateForm();
        }

        private void num_stock_ValueChanged(object sender, EventArgs e)
        {
            product.AmountInStock = Convert.ToInt32(num_stock.Value);
            ValidateForm();
        }

        private void num_price_ValueChanged(object sender, EventArgs e)
        {
            product.Price = num_price.Value;
            ValidateForm();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            product.DateAdded = dateTimePicker1.Value;
            ValidateForm();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ProcessProduct();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cnn.Close();
            Close();
        }
    }
}
