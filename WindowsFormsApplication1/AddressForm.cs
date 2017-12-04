using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Form for creating aand modifying Addresses.
    /// </summary>
    public partial class AddressForm : Form
    {
        public Form parent;

        static SqlConnection cnn;

        public Address address;

        public string mode;

        public AddressForm(Form parent, string mode)
        {
            InitializeComponent();

            this.mode = mode;
            this.parent = parent;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            address = new Address();

            address.Line1 = txt_addrLine1.Text;
            address.Line2 = txt_addrLine2.Text;
            address.City = txt_city.Text;
            address.State = txt_state.Text;
            address.Zip = Convert.ToInt32(txt_zip.Text);
            address.PhoneNumber = txt_phone.Text;

            if (mode == "customer")
            {
                (parent as CustomerForm).AddAddress(address);
            }
            else if (mode == "suppliers")
            {
                SupplierAddress supAddr = new SupplierAddress();
                supAddr.Line1 = address.Line1;
                supAddr.Line2 = address.Line2;
                supAddr.City = address.City;
                supAddr.State = address.State;
                supAddr.ZipCode = address.Zip;

                (parent as SupplierForm).AddSupAddress(supAddr);
            }

            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
