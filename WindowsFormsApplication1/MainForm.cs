using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Entry point for the GUI.
    /// </summary>
    public partial class MainForm : Form
    {
        private Dictionary<string, string> tableRegistry;
        private Dictionary<string, string> queryRegistry;
        private Dictionary<string, Type> formRegistry;

        private string tableState = "Orders";

        public MainForm()
        {
            InitializeComponent();

            // Stored values/procedures for specific user-facing tables
            tableRegistry = new Dictionary<string, string>();
            queryRegistry = new Dictionary<string, string>();
            formRegistry = new Dictionary<string, Type>();

            tableRegistry.Add("Categories", "Categories");
            formRegistry.Add("Categories", typeof(CategoryForm));

            tableRegistry.Add("Instruments", "Instruments");
            formRegistry.Add("Instruments", typeof(ProductForm));

            tableRegistry.Add("Parts", "Parts");
            formRegistry.Add("Parts", typeof(ProductForm));

            tableRegistry.Add("Promotions", "Promotions");
            formRegistry.Add("Promotions", typeof(PromotionForm));

            tableRegistry.Add("Orders", "Orders");
            formRegistry.Add("Orders", typeof(OrderForm));

            tableRegistry.Add("Repairs", "Repairs");
            formRegistry.Add("Repairs", typeof(RepairForm));

            tableRegistry.Add("Customers", "Customers");
            formRegistry.Add("Customers", typeof(CustomerForm));

            tableRegistry.Add("Suppliers", "Suppliers");
            formRegistry.Add("Suppliers", typeof(SupplierForm));

            tableRegistry.Add("Employees", "Employees");
            formRegistry.Add("Employees", typeof(StaffForm));

            tableRegistry.Add("Administrators", "Administrators");
            formRegistry.Add("Administrators", typeof(StaffForm));


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
                JOIN CustAddresses ON CustAddresses.CustAddressID = Orders.ShipAddressID
                ORDER BY [Order Date] DESC;"
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
	                CONVERT(DECIMAL(10, 2), DiscountAmount) AS 'Discount Amount',
	                Promotions.Description,
	                StartDate AS 'Start Date',
	                EndDate AS 'End Date'
                FROM Promotions
                JOIN Products ON Products.ProductID = Promotions.ProductID
                ORDER BY [Start Date] DESC;"
            );

            queryRegistry.Add(
                "Repairs",
                @"SELECT
                    RepairID AS ID,
                    Customers.FirstName + ' ' + Customers.LastName AS 'Customer Name',
                    CompletionDate AS 'Completion Date',
                    Description
                FROM Repairs
                JOIN Customers ON Customers.CustomerID = Repairs.CustomerID
                ORDER BY [Completion Date] DESC;"
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

            queryRegistry.Add(
                "Employees",
                @"SELECT
	                EmployeeID AS ID,
	                Title,
	                '********' AS [Password],
	                EmailAddress AS 'Email Address',
	                FirstName + ' ' + LastName AS 'Full Name',
	                BirthDate AS 'Birth Date',
	                EmployeeType AS Type,
	                DateHired AS 'Date Hired',
	                PrivilegeLevel AS 'Privilege Level'
                FROM Employees;"
            );

            queryRegistry.Add(
                "Administrators",
                @"SELECT
	                EmployeeID AS ID,
	                Title,
	                '********' AS [Password],
	                EmailAddress AS 'Email Address',
	                FirstName + ' ' + LastName AS 'Full Name',
	                BirthDate AS 'Birth Date',
	                EmployeeType AS Type,
	                DateHired AS 'Date Hired',
	                PrivilegeLevel AS 'Privilege Level',
	                OverideCode AS 'Override Code'
                FROM Employees
                JOIN Administrators ON AdminID = EmployeeID;"
            );
        }

        /// <summary>
        /// Load data for the selected table.
        /// </summary>
        private void LoadTableData(string tableName)
        {

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
                    MessageBox.Show("Error: the connection could not be opened. Please specify initialize a new connection.");
                    return;
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

                        // Set columns
                        for (int i = 0; i < columNames.Length; i++)
                        {
                            columNames[i] = tableSchema.Rows[i]["ColumnName"].ToString();
                        }

                        foreach (string column in columNames)
                        {
                            lvProducts.Columns.Add(column, -2, HorizontalAlignment.Left);
                        }

                        // While there is another record present
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedTable;
            if (tableRegistry.TryGetValue(e.Node.Text, out selectedTable))
            {
                LoadTableData(selectedTable);
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
            of.FormClosed += tableForm_closed;
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
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

                        int idColumn = int.Parse(lvi.SubItems[0].Text);

                        command.CommandText = "DELETE FROM " + escTableName + " WHERE " + IDColumn + " = @IDColumn";
                        command.Parameters.AddWithValue("@IDColumn", idColumn);
                        
                        try
                        {
                            if (MessageBox.Show(
                                "Are you sure you want to delete the selected records?",
                                "Confirm Record Deletion", 
                                MessageBoxButtons.YesNo
                            ) == DialogResult.Yes)
                            {
                                command.ExecuteNonQuery();
                                LoadTableData(tableState);
                            }
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show(
                                "One or more of the selected entries could not be deleted because other items in the database depend on them.", 
                                "Error"
                            );
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No such table exists, doing nothing.");
            }
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

            Form form = (Form)Activator.CreateInstance(formRegistry[tableState], false, selectedItemID);
            form.FormClosed += tableForm_closed;
            form.Show();
        }
        
        private void toolStripNew_Click(object sender, EventArgs e)
        {
            Form form = (Form)Activator.CreateInstance(formRegistry[tableState], true, 0);
            form.FormClosed += tableForm_closed;
            form.Show();
        }

        public void tableForm_closed(object sender, EventArgs e)
        {
            LoadTableData(tableState);
        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            InitConn ic = new InitConn();
            ic.Show();
        }
    }
}
