using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    // Create an entity model for the "Customers" table with properties such as "CustomerId," "Name," "Address," "ContactNumber," and "Email."
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public Customer(string name,string addres,string number,string email,string status)
        {
            Name = name;
            Address = addres;
            ContactNumber = number;
            Email = email;
            Status = status;
        }
        public Customer()
        {

        }
        [Timestamp]
        public byte[]? Timestamp { get; set; }  
        public ICollection<Order>? orders { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? dateOfBirth { get; set; }
        public double? averageDuration { get; set; }
        public List<CallDetails> callDetails { get; set; } = new();
    }
}
