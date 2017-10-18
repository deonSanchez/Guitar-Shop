using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarShop
{
    public class OrderItem
    {
        public int ProductID;
        public int Quantity;
        public float ItemPrice;
        public string ProductName;
        
        public OrderItem(int ProductID, float ItemPrice, string ProductName)
        {
            this.ProductID = ProductID;
            this.ItemPrice = ItemPrice;
            this.ProductName = ProductName;
        }
    }
}
