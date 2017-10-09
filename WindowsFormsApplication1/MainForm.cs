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

        SqlConnection cnn;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            connetionString = "Data Source=CEIT2553214X016\\LOCAL;Initial Catalog=MyGuitarShop;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !");
            }
        }

        private void loadDataForInventory(string tableName)
        {

            lvProducts.Items.Clear();
            lvProducts.Columns.Clear();

            SqlCommand command = new SqlCommand(String.Format("SELECT * FROM {0}", tableName), cnn);
            // Create new SqlDataReader object and read data from the command.
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Text == "Categories")
            {
                loadDataForInventory("Categories");
            }

            if (e.Node.Text == "Instruments")
            {
                loadDataForInventory("Products");
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
