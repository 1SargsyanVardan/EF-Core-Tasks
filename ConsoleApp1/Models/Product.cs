using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Create an entity model for the "Products" table with properties like "ProductId," "ProductName," "Price," and "StockQuantity."
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public ProductDetails? Details { get; set; }//Task 5....
        public string Category { get; set; }
        public ICollection<ProductOrder> productOrders { get; set; }
    }
}
