using System;

namespace GuitarShop
{
    /// <summary>
    /// Data structure for Products
    /// </summary>
    class Product
    {
        public int ProductID;
        public int CategoryID;
        public int SupplierID;
        public string ProductName;
        public string ProductType;
        public string Description;
        public int AmountInStock;
        public decimal Price;
        public DateTime DateAdded;
    }
}
