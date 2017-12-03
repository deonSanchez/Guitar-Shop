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
    public partial class AddressForm : Form
    {
        public Form parent;

        static SqlConnection cnn;

        public Address address;

        public AddressForm(Form parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            address = new Address();

            address.line1 = txt_addrLine1.Text;
            address.line2 = txt_addrLine2.Text;
            address.city = txt_city.Text;
            address.state = txt_state.Text;
            address.zip = Convert.ToInt32(txt_zip.Text);
            address.phoneNumber = txt_phone.Text;

            (parent as CustomerForm).AddAddress(address);
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
