using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarShop
{
    class Constants
    {
        public static string ConnectionString {
            get { return @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=MyGuitarShop;Integrated Security=True"; }
        }

        public static void SetComboBoxToItemWithID(ComboBox cm, int ID)
        {
            foreach (ComboBoxItem cbi in cm.Items)
            {
                if (cbi.IdentifyingValue == ID)
                {
                    cm.SelectedItem = cbi;
                    return;
                }
            }
        }
    }
}
