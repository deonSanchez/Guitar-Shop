using System;

namespace GuitarShop
{
    /// <summary>
    /// Data structure for Addresses
    /// </summary>
    class Promotion
    {
        public int PromotionCode;
        public int ProductID;
        public decimal DiscountAmount;
        public string Description;
        public DateTime StartDate;
        public DateTime EndDate;
    }
}
