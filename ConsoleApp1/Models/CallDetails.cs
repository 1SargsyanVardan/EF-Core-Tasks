using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CallDetails
    {
        public int Id { get; set; }
        public string CallerNumber { get; set; }
        public string RecieverNumber { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CallDetails() { }
        public CallDetails(string callerNumber, string recieverNumber, DateTime startDate, DateTime endDate)
        {
            CallerNumber = callerNumber;
            RecieverNumber = recieverNumber;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
