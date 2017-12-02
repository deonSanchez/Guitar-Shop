using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarShop
{
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

