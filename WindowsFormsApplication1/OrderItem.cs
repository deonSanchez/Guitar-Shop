namespace GuitarShop
{
    /// <summary>
    /// Data structure for OrderItems
    /// </summary>
    public class OrderItem
    {
        public int OrderItemID;
        public int ProductID;
        public int Quantity;
        public decimal ItemPrice;
        public string ProductName;
        public int PromotionCode;

        public OrderItem() { }
        
        public OrderItem(int ProductID, decimal ItemPrice, string ProductName)
        {
            this.ProductID = ProductID;
            this.ItemPrice = ItemPrice;
            this.ProductName = ProductName;
        }
    }
}
