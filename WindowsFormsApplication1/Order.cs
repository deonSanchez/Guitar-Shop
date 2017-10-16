using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarShop
{
    class Order
    {
        public int OrderID;
        public int CustomerID = 1;
        public int ShipAmount = 0;
        public int TaxAmount = 0;
        public string CardType = "";
        public string CardNumber = "";  
    }
}
