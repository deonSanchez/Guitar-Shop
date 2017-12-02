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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();

            //needs to have addressID in the query
            string query = "select * from supplier where name ='" + stuff + "' ;";
            SqlConnection cnn = new SqlConnection(Constants.ConnectionString);
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader dataReader;

            try
            {
                cnn.Open();
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    textBox2.Text = dataReader["suppliername"].ToString();
                    textBox3.Text = dataReader["contactfirstname"].ToString();
                    textBox4.Text = dataReader["contactlastname"].ToString();
                    textBox7.Text = dataReader["line1"].ToString();
                    textBox6.Text = dataReader["line2"].ToString();
                    textBox8.Text = dataReader["city"].ToString();
                    textBox9.Text = dataReader["state"].ToString();
                    textBox10.Text = dataReader["zipcode"].ToString();
                    textBox5.Text = dataReader["phonenumber"].ToString();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex);
            }
        }
    }
}
