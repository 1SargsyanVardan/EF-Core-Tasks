using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ConsoleApp1
{
    public class NewCustomer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public NewCustomer(string name, string addres, string number, string email, string status)
        {
            Name = name;
            Address = addres;
            ContactNumber = number;
            Email = email;
            Status = status;
        }
        public NewCustomer()
        {

        }

        public ICollection<Order>? orders { get; set; }
    }
}
