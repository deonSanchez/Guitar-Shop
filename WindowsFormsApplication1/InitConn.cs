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
    public partial class InitConn : Form
    {
        MainForm parent;

        public InitConn(MainForm parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(textBox1.Text);
                cnn.Open();

                Constants.ConnectionString = textBox1.Text;
                MessageBox.Show("Connection succesfully intialized.");
                parent.isConnected = true;

                cnn.Close();
                Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: the connection could not be opened.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: the connection could not be opened.");
            }
        }
    }
}
