namespace GuitarShop
{
    /// <summary>
    /// Data structure for Payment
    /// </summary>
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
