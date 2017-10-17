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
      
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DEONSANCHEZEB14;Initial Catalog=MyGuitarShop;Integrated Security=True");

        public Management()
        {
            InitializeComponent();
            
        }
        private void Management_Load(object sender, EventArgs e)
        {
            
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
            //catergories button
            SqlCommand catCommand = new SqlCommand("select categoryName from categories ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = catCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //for instruments to appear in table
            SqlCommand instruCommand = new SqlCommand("select * from products ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = instruCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //button for customers
            SqlCommand custCommand = new SqlCommand("select * from customers ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = custCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            //opens administrators
            SqlCommand adminCommand = new SqlCommand("select * from administrators ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = adminCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Payments_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //open up another design for inputing data
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Addresses_Click(object sender, EventArgs e)
        {
            //command that opens addresses
            SqlCommand addressesCommand = new SqlCommand("select * from addresses ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = addressesCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderItems_Click(object sender, EventArgs e)
        {
            //button for order items to appear
            SqlCommand orderItemsCommand = new SqlCommand("select * from OrderItems ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = orderItemsCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            //for the orders to appear in table
            SqlCommand orderCommand = new SqlCommand("select * from Orders ;", sqlConnection);

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = orderCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                sqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Parts_Click(object sender, EventArgs e)
        {

        }
    }
}
