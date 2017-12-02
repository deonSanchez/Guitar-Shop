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
/// Payments
/// Repairs
/// RepairItems
/// Products
/// Promotions
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
    public partial class RepairForm : Form
    {
        private Repair repair;

        bool creating = true;
        int editItemID;

        SqlConnection cnn;

        public RepairForm(bool creating, int editItemID)
        {
            InitializeComponent();

            lv_repairItems.Columns.Add("", -2, HorizontalAlignment.Left); // Checkbox column
            lv_repairItems.Columns.Add("Item", -2, HorizontalAlignment.Left);
            lv_repairItems.Columns.Add("Repair Type", -2, HorizontalAlignment.Left);
            lv_repairItems.Columns.Add("Price", -2, HorizontalAlignment.Left);

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

            if (creating)
            {
                repair = new Repair();
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
        {;
            repair = new Repair();
            repair.RepairID = editItemID;

            // Load in Repair details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustomerID, CompletionDate, Description FROM Repairs WHERE RepairID = @RepairID";

                command.Parameters.AddWithValue("@RepairID", editItemID);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        repair.CustomerID = Convert.ToInt32(reader[0]);
                        repair.CompletionDate = Convert.ToDateTime(reader[1]);
                        repair.Description = reader[2].ToString();
                    }
                }
            }

            // Load in RepairItem details
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT RepairItemID, ProductID, RepairType, LaborPrice FROM RepairItems WHERE RepairID = @RepairID";

                command.Parameters.AddWithValue("@RepairID", editItemID);

                List<RepairItem> riList = new List<RepairItem>();

                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RepairItem ri = new RepairItem();

                        ri.RepairItemID = Convert.ToInt32(reader[0]);
                        ri.ProductID = Convert.ToInt32(reader[1]);
                        ri.RepairType = reader[2].ToString();
                        ri.LaborPrice = Convert.ToDecimal(reader[3]);
                        
                        riList.Add(ri);
                    }
                }

                foreach (RepairItem ri in riList)
                {
                    AddRepairItem(ri);
                }
            }

            Constants.SetComboBoxToItemWithID(cmb_customer, repair.CustomerID);

            datetimePickCompleted.Value = repair.CompletionDate;
            txt_description.Text = repair.Description;

            ValidateForm();
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

        private void ValidateForm()
        {
            if (lv_repairItems.Items.Count > 0
                && cmb_customer.SelectedIndex > -1
                && txt_description.Text != "")
            {
                btn_add.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
            }
        }

        private void cmb_customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmbox = (ComboBox)sender;

            int custId = (cmbox.SelectedItem as ComboBoxItem).IdentifyingValue;
            repair.CustomerID = custId;

            ValidateForm();
        }

        private void btn_sumbit_Click(object sender, EventArgs e)
        {
            ProcessRepair();
        }

        public void AddRepairItem(RepairItem ri)
        {
            ListViewItem riLV = new ListViewItem();

            decimal discountAmount = 0;
            string productName = "";

            // Get the product name
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductName FROM Products WHERE ProductID = @ProductID";

                command.Parameters.AddWithValue("@ProductID", ri.ProductID);

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
            

            riLV.Tag = ri;
            riLV.SubItems.AddRange(new String[] {
                productName,
                ri.RepairType,
                ri.LaborPrice.ToString("F")
            });

            lv_repairItems.Items.Add(riLV);
            lv_repairItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            ValidateForm();
        }
     
        private void ProcessRepair()
        {
            int autoRepairID = 0;

            if (creating)
            {
                // Insert Repair
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO Repairs (CustomerID, CompletionDate, Description) VALUES (@CustomerID, @CompletionDate, @Description); SELECT SCOPE_IDENTITY()";

                    command.Parameters.AddWithValue("@CustomerID", repair.CustomerID);
                    command.Parameters.AddWithValue("@CompletionDate", repair.CompletionDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Description", repair.Description);

                    try
                    {
                        autoRepairID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Repair succefully placed!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write repair.");
                        return;
                    }
                }
            }
            else
            {
                // Edit Repair
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Repairs SET CustomerID = @CustomerID, CompletionDate = @CompletionDate, Description = @Description WHERE RepairID = @RepairID";

                    command.Parameters.AddWithValue("@RepairID", editItemID);
                    command.Parameters.AddWithValue("@CustomerID", repair.CustomerID);
                    command.Parameters.AddWithValue("@CompletionDate", repair.CompletionDate.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Description", repair.Description);

                    try
                    {
                        autoRepairID = Convert.ToInt32(command.ExecuteScalar());
                        MessageBox.Show("Repair succefully updated!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not write repair.");
                        return;
                    }
                }
            }

            if (creating)
            {
                // Insert OrderItems
                foreach (ListViewItem item in lv_repairItems.Items)
                {
                    RepairItem ri = item.Tag as RepairItem;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO RepairItems(RepairID, ProductID, RepairType, LaborPrice) VALUES (@RepairID, @ProductID, @RepairType, @LaborPrice)";

                        command.Parameters.AddWithValue("@RepairID", autoRepairID);
                        command.Parameters.AddWithValue("@ProductID", ri.ProductID);
                        command.Parameters.AddWithValue("@RepairType", ri.RepairType);
                        command.Parameters.AddWithValue("@LaborPrice", ri.LaborPrice);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Could not write RepairItem.");
                        }
                    }
                }
            }
            else
            {
                // Delete RepairItems
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = cnn;
                    command.CommandText = "DELETE FROM RepairItems WHERE RepairID = @RepairID ";

                    command.Parameters.AddWithValue("@RepairID ", repair.RepairID);

                    command.ExecuteNonQuery();
                }

                // Re-insert RepairItems
                foreach (ListViewItem item in lv_repairItems.Items)
                {
                    RepairItem ri = item.Tag as RepairItem;

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = cnn;
                        command.CommandText = "INSERT INTO RepairItems(RepairID, ProductID, RepairType, LaborPrice) VALUES (@RepairID, @ProductID, @RepairType, @LaborPrice)";

                        command.Parameters.AddWithValue("@RepairID", editItemID);
                        command.Parameters.AddWithValue("@ProductID", ri.ProductID);
                        command.Parameters.AddWithValue("@RepairType", ri.RepairType);
                        command.Parameters.AddWithValue("@LaborPrice", ri.LaborPrice);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
          
            cnn.Close();
            Close();
        }

        private void btn_orderItemsAdd_Click(object sender, EventArgs e)
        {
            RepairItemSelection ris = new RepairItemSelection(this);
            ris.Show();
        }

        private void lv_repairItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // If at least one item is checked, then the user may remove checked items from the list.
            if (lv_repairItems.CheckedItems.Count > 0)
            {
                btn_repairItemsRemove.Enabled = true;
            }
            else
            {
                btn_repairItemsRemove.Enabled = false;
            }
        }

        private void btn_repairItemsRemove_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = lv_repairItems.CheckedItems;

            foreach (ListViewItem item in checkedItems)
            {
                lv_repairItems.Items.Remove(item);
                lv_repairItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            ValidateForm();
        }

        private void datetimePickCompleted_ValueChanged(object sender, EventArgs e)
        {
            repair.CompletionDate = datetimePickCompleted.Value;
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {
            repair.Description = txt_description.Text;
            ValidateForm();
        }

        private void cmb_customer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ValidateForm();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ProcessRepair();
        }
    }
}
