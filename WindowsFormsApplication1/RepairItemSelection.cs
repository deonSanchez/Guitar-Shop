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
    public partial class RepairItemSelection : Form
    {
        RepairForm parent;

        static SqlConnection cnn;

        public RepairItemSelection(RepairForm parent)
        {
            InitializeComponent();
            this.parent = parent;

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
        }

        private void loadItems()
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ProductID, ProductName, Price FROM Products WHERE ProductType = 'instrument';";

                // Create new SqlDataReader object and read data from the command.
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> customerList = new List<string>();

                        while (reader.Read())
                        {
                            string displayString = reader[0].ToString() + " - " + reader[1] + " - " + reader[2];
                            customerList.Add(displayString);
                            //orderItemRegistry.Add(displayString, new RepairItem(int.Parse(reader[0].ToString()), decimal.Parse(reader[2].ToString()), reader[1].ToString()));
                        }

                        //cmb_orderItemSelect.Items.AddRange(customerList.ToArray());
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Could not open Products.");
                }
            }
        }
    }
}
