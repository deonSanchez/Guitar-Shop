using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarShop
{
    class Payment
    {
        public int PaymentID;
        public int OrderID;
        public string Timestamp;
        public string Status;
        public string CardType;
        public string CardNumber;
        public string CardExpires;
        public int BillingAddressID;
    }
}
