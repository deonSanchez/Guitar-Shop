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
/// General TODOS:
/// 
/// - Abstract SQL connection prep/teardown. Because we have to repeat the same steps so many times
///   let's find a way to not re-write so much code.
/// 
/// - Better data source management. Pull directly from application properties, avoid duplicating sources.
/// 
/// - Clean up event handlers accidentally created in form designer.
/// 
/// - Either make forms more rigid or more responsive.
/// 
/// </summary>
namespace GuitarShop
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> tableRegistry;
        private Dictionary<string, string> queryRegistry;

        private string tableState = "Orders";

        public MainForm()
        {
            InitializeComponent();
            tableRegistry = new Dictionary<string, string>();
            tableRegistry.Add("Categories", "Categories");
            tableRegistry.Add("Instruments", "Instruments");
            tableRegistry.Add("Promotions", "Promotions");
            tableRegistry.Add("Parts", "Parts");
            tableRegistry.Add("Orders", "Orders");
            tableRegistry.Add("Repairs", "Repairs");
            tableRegistry.Add("Customers", "Customers");
            tableRegistry.Add("Suppliers", "Suppliers");
            tableRegistry.Add("Administrators", "Administrators");

            queryRegistry = new Dictionary<string, string>();
            queryRegistry.Add(
                "Orders",
                @"SELECT 
	                OrderID AS ID,
	                Customers.FirstName + ' ' + Customers.LastName AS 'Full Name',
	                OrderDate AS 'Order Date',
	                CONVERT(DECIMAL(10, 2), ShipAmount) as 'Ship Amount',
	                CONVERT(DECIMAL(10, 2), TaxAmount) as 'TaxAmount',
	                ShipDate AS 'Ship Date',
	                Line1 + ' ' + Line2 + ' ' + City + ', ' + [State] + ' ' + ZipCode as 'Shipping Address'
                FROM Orders
                JOIN Customers ON Orders.CustomerID = Customers.CustomerID
                JOIN CustAddresses ON CustAddresses.CustAddressID = Customers.CustomerID;"
            );

            queryRegistry.Add(
                "Customers",
                @"SELECT
	                Customers.CustomerID AS ID,
	                Customers.EmailAddress AS 'Email Address',
	                '*******' AS [Password],
	                Customers.FirstName + ' ' + Customers.LastName AS 'Full Name',
	                Employees.FirstName + ' ' + Employees.LastName AS 'Employee Contact'
                FROM Customers
                JOIN Employees ON Customers.EmployeeContact = Employees.EmployeeID;"
            );

            queryRegistry.Add(
                "Instruments",
                @"SELECT
                    ProductID AS ID,
                    CategoryName AS 'Category',
                    SupplierName AS 'Supplier Name',
                    ProductName AS 'Product Name',
                    AmountInStock As 'Amount In Stock',
                    CONVERT(DECIMAL(10, 2), Price) AS Price,
                    DateAdded AS 'Date Added',
                    [Description]
                FROM Products
                JOIN Categories ON Products.CategoryID = Categories.CategoryID
                JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
                WHERE ProductType = 'instrument';"
            );

            queryRegistry.Add(
                "Parts",
                @"SELECT
                    ProductID AS ID,
                    CategoryName AS 'Category',
                    SupplierName AS 'Supplier Name',
                    ProductName AS 'Product Name',
                    AmountInStock As 'Amount In Stock',
                    CONVERT(DECIMAL(10, 2), Price) AS Price,
                    DateAdded AS 'Date Added',
                    [Description]
                FROM Products
                JOIN Categories ON Products.CategoryID = Categories.CategoryID
                JOIN Suppliers ON Products.SupplierID = Suppliers.SupplierID
                WHERE ProductType = 'part';"
            );

            queryRegistry.Add(
                "Categories",
                @"SELECT 
	                CategoryID AS ID,
	                CategoryName AS Name
                FROM Categories;"
            );

            queryRegistry.Add(
                "Promotions",
                @"SELECT
	                PromotionCode AS 'Promo Code',
	                ProductName AS 'Product',
	                DiscountAmount AS 'Discount Amount',
	                Promotions.Description,
	                StartDate AS 'Start Date',
	                EndDate AS 'End Date'
                FROM Promotions
                JOIN Products ON Products.ProductID = Promotions.ProductID;"
            );

            queryRegistry.Add(
                "Repairs",
                @"SELECT
                    RepairID AS ID,
                    Customers.FirstName + ' ' + Customers.LastName AS 'Customer Name',
                    CompletionDate AS 'Completion Date',
                    Description
                FROM Repairs
                JOIN Customers ON Customers.CustomerID = Repairs.CustomerID;"
            );

            queryRegistry.Add(
                "Suppliers",
                @"SELECT
	                SupplierID AS ID,
	                SupplierName AS 'Supplier Name',
	                ContactFirstName + ' ' + ContactLastName AS 'Contact Full Name',
	                PhoneNumber As 'Phone Number',
	                Employees.FirstName + ' ' + Employees.LastName AS 'Employee Contact'
                FROM Suppliers
                JOIN Employees ON Suppliers.EmployeeContact = Employees.EmployeeID;"
            );
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(Constants.ConnectionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection successful.");
                cnn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: the connection could not be opened.");
            }
        }

        private void loadDataForInventory(string tableName)
        {
            //SqlConnection cnn = new SqlConnection(Constants.ConnectionString);

            //SqlCommandBuilder builder = new SqlCommandBuilder();
            //string escTableName = builder.QuoteIdentifier(tableName);

            //SqlCommand command = new SqlCommand();
            //command.Connection = cnn;
            //command.CommandType = CommandType.Text;
            //command.CommandText = "SELECT * FROM " + escTableName;

            //try
            //{
            //    sqlDataAdapter = new SqlDataAdapter();
            //    sqlDataAdapter.SelectCommand = command;

            //    dataTable = new DataTable();
            //    sqlDataAdapter.Fill(dataTable);

            //    bindingSource = new BindingSource();
            //    bindingSource.DataSource = dataTable;
            //    dataGridView1.DataSource = bindingSource;
            //    sqlDataAdapter.Update(dataTable);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            // Clear the ListView of existing data

            tableState = tableName;
            lvProducts.Items.Clear();
            lvProducts.Columns.Clear();

            SqlConnection cnn = new SqlConnection(Constants.ConnectionString);

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

                SqlCommandBuilder builder = new SqlCommandBuilder();
                string escTableName = builder.QuoteIdentifier(tableName);

                command.Connection = cnn;
                command.CommandType = CommandType.Text;

                try
                {
                    command.CommandText = queryRegistry[tableState];
                }
                catch (Exception)
                {
                    command.CommandText = "SELECT * FROM " + escTableName;
                }

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable tableSchema = reader.GetSchemaTable();
                        string[] columNames = new string[tableSchema.Rows.Count];

                        for (int i = 0; i < columNames.Length; i++)
                        {
                            columNames[i] = tableSchema.Rows[i]["ColumnName"].ToString();
                        }

                        foreach (string column in columNames)
                        {
                            lvProducts.Columns.Add(column, -2, HorizontalAlignment.Left);
                        }

                        // while there is another record present
                        while (reader.Read())
                        {
                            string[] rowData = new string[columNames.Length];
                            for (int i = 0; i < rowData.Length; i++)
                            {
                                rowData[i] = reader[i].ToString();
                            }

                            lvProducts.Items.Add(new ListViewItem(rowData));
                        }

                        lvProducts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not open specificed category.");
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedTable;
            if (tableRegistry.TryGetValue(e.Node.Text, out selectedTable))
            {
                loadDataForInventory(selectedTable);
            }
            else
            {
                Console.WriteLine("Could database table for \"" + e.Node.Text + "\"");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm(true, 0);
            of.Show();
            of.FormClosed += orderForm_closed;
        }

        private void orderForm_closed(object sender, EventArgs e)
        {
            Console.WriteLine("Orderform closed");
            loadDataForInventory(tableState);
        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDataForInventory("Orders");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // TODO: This ought to be contextual
            OrderForm of = new OrderForm(true, 0);
            of.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            // Looks like we're gonna need specific deletion queries for each table to deal with FK contraints. Nuts.


            string selectedTable;
            if (tableRegistry.TryGetValue(tableState, out selectedTable))
            {
                foreach (ListViewItem lvi in lvProducts.CheckedItems)
                {
                    Console.WriteLine(lvi.SubItems[0].Text);

                    SqlConnection cnn = new SqlConnection(Constants.ConnectionString);

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

                        SqlCommandBuilder builder = new SqlCommandBuilder();
                        string escTableName = builder.QuoteIdentifier(selectedTable);
                        command.Connection = cnn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM " + escTableName;

                        String IDColumn;
                        
                        // Create new SqlDataReader object and read data from the command.
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                DataTable tableSchema = reader.GetSchemaTable();
                                string[] columNames = new string[tableSchema.Rows.Count];

                                for (int i = 0; i < columNames.Length; i++)
                                {
                                    columNames[i] = tableSchema.Rows[i]["ColumnName"].ToString();
                                }

                                IDColumn = columNames[0];
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error.");
                            return;
                        }

                        command.CommandText = "DELETE FROM " + escTableName + " WHERE " + IDColumn + " = @IDColumn";
                        command.Parameters.AddWithValue("@IDColumn", int.Parse(lvi.SubItems[0].Text));
                        
                        try
                        {
                            if (MessageBox.Show("Are you sure you want to delete the selected records?", "Confirm Record Deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                command.ExecuteNonQuery();
                                loadDataForInventory(tableState);
                            }
                        }
                        catch (SqlException ex)
                        {
                            throw (ex);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No such table exists, doing nothing.");
            }
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm cf = new CustomerForm();
            cf.Show();
            cf.FormClosed += orderForm_closed;
        }

        private void lvProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lvProducts_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // If at least one item is checked, then the user may remove or edit checked items from the list.
            if (lvProducts.CheckedItems.Count == 1)
            {
                toolStripEdit.Enabled = true;
            } 
            else
            {
                toolStripEdit.Enabled = false;
            }

            if (lvProducts.CheckedItems.Count > 0)
            {
                toolStripDelete.Enabled = true;
            }
            else
            {
                toolStripDelete.Enabled = false;
            }
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            int selectedItemID = Convert.ToInt32(lvProducts.CheckedItems[0].SubItems[0].Text);

            OrderForm of = new OrderForm(false, selectedItemID);
            of.Show();
        }
    }
}
