using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }

        private List<Rental> rentals = new List<Rental>();

        public List<Rental> getRentals()
        {
            return this.rentals;
        }

        public User(string surname, string name, string email, string password, string telephone)
        {
            Surname = surname;
            Name = name;
            Email = email;
            Password = password;
            Telephone = telephone;
        }
    }
}
