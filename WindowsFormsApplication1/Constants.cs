using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Application-wide constants and utilites.
    /// </summary>
    class Constants
    {

        public static string ConnectionString {
            get { return @"Data Source=loalhost\Local;Initial Catalog=MyGuitarShop;Integrated Security=True"; }
            set { ConnectionString = value; }
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
