namespace GuitarShop
{
    /// <summary>
    /// Utility combobox helper to store ID and display value.
    /// </summary>
    class ComboBoxItem
    {
        string displayValue;
        private int identifyingValue;

        public ComboBoxItem(string d, int i)
        {
            displayValue = d;
            identifyingValue = i;
        }

        public int IdentifyingValue
        {
            get
            {
                return identifyingValue;
            }
        }

        public override string ToString()
        {
            return displayValue;
        }
    }
}

