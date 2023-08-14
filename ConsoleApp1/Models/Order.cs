using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Create an entity model for the "Orders" table with properties like "OrderId," "OrderDate," "CustomerId," "TotalAmount," and "Status."
   // [Index(nameof(Customer), nameof(Status))]
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }//Task 4.....
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public CancelledOrders CancelledOrders { get; set; }
        public ICollection<ProductOrder> productOrders { get; set; }

    }
}
