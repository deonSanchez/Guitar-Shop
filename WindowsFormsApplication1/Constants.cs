using System.Windows.Forms;

namespace GuitarShop
{
    /// <summary>
    /// Application-wide constants and utilites.
    /// </summary>
    class Constants
    {
        public static string ConnectionString {
            get;
            set;
        }

        public static string DefaultConnectionString = @"Data Source=localhost\SQLEXPRESS01;Initial Catalog=MyGuitarShop;Integrated Security=True";

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
