using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Rental
    {
        public Document Document { get; set; }
        public User User { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }

        public Rental(Document document, User user, String startDate, String endDate)
        {   
            Document = document;
            User = user;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void printInfo()
        {
            Console.WriteLine($"\nThe document '{Document.Title}' is borrowed from {StartDate} to {EndDate}");
        }
    }
}
