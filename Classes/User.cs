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

        public User(string surname, string name, string email, string password, string telephone)
        {
            Surname = surname;
            Name = name;
            Email = email;
            Password = password;
            Telephone = telephone;
        }

        public void Borrow(Document document)
        {
            if(document.State == "available")
            {
                document.State = "borrowed";
                Console.WriteLine("\nDocument successfully borrowed!");
            }
            else
            {
                Console.WriteLine("\nThe document is not available.");
            }
        }

        public void ReturnDocument(Document document)
        {
            document.State = "available";
        }
    }
}
