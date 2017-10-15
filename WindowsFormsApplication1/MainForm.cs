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
    public partial class MainForm : Form
    {
        private static string connetionString = "Data Source=CEIT2551204X062\\LOCAL;Initial Catalog=MyGuitarShop;Integrated Security=True";
        private Dictionary<string, string> tableRegistry;

        public MainForm()
        {
            InitializeComponent();
            tableRegistry = new Dictionary<string, string>();
            tableRegistry.Add("Categories", "Categories");
            tableRegistry.Add("Instruments", "Products");
            tableRegistry.Add("Orders", "Orders");
            tableRegistry.Add("Customers", "Customers");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connetionString);
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
            // Clear the ListView of existing data 
            lvProducts.Items.Clear();
            lvProducts.Columns.Clear();

            SqlConnection cnn = new SqlConnection(connetionString);

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
                command.CommandText = "SELECT * FROM " + escTableName;

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
            OrderForm of = new OrderForm();
            of.Show();
        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
