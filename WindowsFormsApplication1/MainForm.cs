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
            SqlConnection cnn;
            connetionString = "Data Source=DEONSANCHEZEB14;Initial Catalog=MyGuitarShop;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open!");

                SqlCommand command = new SqlCommand("SELECT * FROM Products", cnn);
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

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open connection !");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm();
            of.Show();
        }
    }
}
