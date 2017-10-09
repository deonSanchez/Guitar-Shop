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
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
            
        }
        private void Management_Load(object sender, EventArgs e)
        {
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
                            listView1.Columns.Add(column, -2, HorizontalAlignment.Left);
                        }

                        // while there is another record present
                        while (reader.Read())
                        {
                            string[] rowData = new string[columNames.Length];
                            for (int i = 0; i < rowData.Length; i++)
                            {
                                rowData[i] = reader[i].ToString();
                            }

                            listView1.Items.Add(new ListViewItem(rowData));
                        }

                        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }

                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot open connection !");
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void Payments_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
