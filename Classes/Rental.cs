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
        public DateTime StardDate { get; set; }
        public DateTime EndDate { get; set; }

        public Rental(Document document, User user, DateTime startDate, DateTime endDate)
        {   
            Document = document;
            User = user;
            StardDate = startDate;
            EndDate = endDate;
        }
    }
}
