using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Form for creating and modifying Categories.
    /// </summary>
    public partial class CategoryForm : Form
    {
        static SqlConnection cnn;

        bool creating = true;
        int editItemID;

        public CategoryForm(bool creating, int editItemID)
        {
            InitializeComponent();

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

            this.creating = creating;
            this.editItemID = editItemID;

            if(!creating)
            {
                btn_add.Text = "Update";
            }

            PreloadData();
        }

        /// <summary>
        /// If editing a previously existing order, preload all fields.
        /// </summary>
        private void PreloadData()
        {
            // Load Category
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CategoryName FROM Categories WHERE CategoryID = @CategoryID";

                command.Parameters.AddWithValue("@CategoryID", editItemID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txt_name.Text = reader[0].ToString();
                    }
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (creating)
            {
                // Insert Category
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName);";

                    command.Parameters.AddWithValue("@CategoryName", txt_name.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Category Succefully Created!");
                }
            }
            else
            {
                // Insert Category

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;";

                    command.Parameters.AddWithValue("@CategoryID", editItemID);
                    command.Parameters.AddWithValue("@CategoryName", txt_name.Text);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Category succefully Updated!");
                    }
                    catch (SqlException)
                    {

                    }
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

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            if(txt_name.Text != "")
            {
                btn_add.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
            }
        }
    }
}
