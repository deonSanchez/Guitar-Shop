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
    public partial class OrderForm : Form
    {
        private static string connetionString = "Data Source=CEIT2551204X062\\LOCAL;Initial Catalog=MyGuitarShop;Integrated Security=True";
        private static string[] cardTypes = new string[] {"Credit", "Debit", "EagleID"};

        public OrderForm()
        {
            InitializeComponent();
            loadCustomers();
            cmb_cardType.Items.AddRange(cardTypes);
        }

        private void loadCustomers()
        {
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
                
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CustomerID, EmailAddress FROM Customers";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> customerList = new List<string>();

                       // while there is another record present
                        while (reader.Read())
                        {
                            customerList.Add(reader[0].ToString() + " - " + reader[1]);                            
                        }

                        cmb_Customer.Items.AddRange(customerList.ToArray());
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not open customers.");
                }
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
