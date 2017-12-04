using System;

namespace GuitarShop
{
    /// <summary>
    /// Data structure for Orders
    /// </summary>
    class Order
    {
        public int OrderID;
        public int CustomerID = 1;
        public decimal ShipAmount = 0;
        public decimal TaxAmount = 0;
        public int ShippingAddressID;
        public DateTime ShipDate;
    }
}
