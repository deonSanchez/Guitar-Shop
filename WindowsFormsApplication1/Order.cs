using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarShop
{
    /// <summary>
    /// This might not be necesary - evaluate.
    /// </summary>
    class Order
    {
        public int OrderID;
        public int CustomerID = 1;
        public decimal ShipAmount = 0;
        public decimal TaxAmount = 0;
        public string CardType = "";
        public string CardNumber = "";  
    }
}
