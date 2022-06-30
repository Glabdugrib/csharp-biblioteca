using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Library
    {
        public bool IsLogged { get; set; }
        public User UserLogged { get; set; }

        public List<User> Users { get; set; }

        public List<Book> Books { get; set; }
        public List<Dvd> Dvds { get; set; }

        public Library(List<User> users, List<Book> books, List<Dvd> dvds)
        {
            IsLogged = false;
            Users = users;
            Books = books;
            Dvds = dvds;
        }

        public void UnloggedPage()
        {
            Console.WriteLine($"\n*** ONLINE LIBRARY ***");
            Console.WriteLine($"1. Register");
            Console.WriteLine($"2. Login");
            Console.WriteLine($"3. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch(input) {
                case 1:
                    this.Register();
                    break;
                case 2:
                    this.Login();
                    break;
                case 3:
                    return;
                    break;
            }
        }

        private void Register()
        {
            Console.WriteLine($"\n* REGISTER *\n");
            Console.WriteLine($"Insert your data:");

            Console.Write($"Name: ");
            string name = Console.ReadLine();
            Console.Write($"Surname: ");
            string surname = Console.ReadLine();
            Console.Write($"Email: ");
            string email = Console.ReadLine();
            Console.Write($"Password: ");
            string password = Console.ReadLine();
            Console.Write($"Telephone: ");
            string telephone = Console.ReadLine();

            User user = new User(surname, name, email, password, telephone);
            Users.Add(user);

            this.Login();
        }

        private void Login()
        {
            Console.WriteLine($"\n* LOGIN *\n");
            Console.WriteLine($"Insert your data:");

            Console.Write($"Email: ");
            string email = Console.ReadLine();
            Console.Write($"Password: ");
            string password = Console.ReadLine();

            foreach(User user in Users)
            {
                if(user.Email == email && user.Password == password)
                {
                    IsLogged = true;
                    UserLogged = user;

                    Console.WriteLine($"\nLogged successfully");

                    this.LoggedPage();
                }
            }

            if(!IsLogged)
            {
                Console.WriteLine($"Login failed");
                this.UnloggedPage();
            }
        }

        private void LoggedPage()
        {
            Console.WriteLine($"\n*** ONLINE LIBRARY ***");
            Console.WriteLine($"1. Search book");
            Console.WriteLine($"2. Search DVD");
            Console.WriteLine($"3. View rentals");
            Console.WriteLine($"4. Logout");
            Console.WriteLine($"5. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    this.SearchBook();
                    break;
                case 2:
                    this.SearchDvd();
                    break;
                case 3:
                    this.ViewRentals();
                    break;
                case 4:
                    this.Logout();
                    break;
                case 5:
                    return;
                    break;
            }
        }

        private void Logout()
        {
            IsLogged = false;
            UserLogged = null;

            this.UnloggedPage();
        }

        private void SearchBook()
        {
            Console.WriteLine($"\n* SEARCH BOOK *\n");
            Console.WriteLine($"1. Search by ISBN");
            Console.WriteLine($"2. Search by title");
            Console.WriteLine($"3. Back");
            Console.WriteLine($"4. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    this.SearchBookByIsbn();
                    break;
                case 2:
                    this.SearchBookByTitle();
                    break;
                case 3:
                    this.LoggedPage();
                    break;
                case 4:
                    return;
                    break;
            }
        }

        private void SearchBookByIsbn()
        {
            Console.WriteLine($"\n* SEARCH BOOK *\n");
            Console.Write($"Insert ISBN: ");
            string isbn = Console.ReadLine();

            bool foundBook = false;

            foreach(Book book in Books)
            {
                if(book.Isbn == isbn)
                {
                    foundBook = true;
                    this.BookInfo(book);
                }
            }

            if(!foundBook)
            {
                Console.WriteLine("\nBook not found.");
                this.SearchBook();
            }
        }

        private void SearchBookByTitle()
        {
            Console.WriteLine($"\n* SEARCH BOOK *\n");
            Console.Write($"Insert title: ");
            string title = Console.ReadLine();

            bool foundBook = false;

            foreach (Book book in Books)
            {
                if (book.Title == title)
                {
                    foundBook = true;
                    this.BookInfo(book);
                }
            }

            if (!foundBook)
            {
                Console.WriteLine("\nBook not found.");
                this.SearchBook();
            }
        }

        private void BookInfo(Book book)
        {
            Console.WriteLine($"\n* BOOK MENU *\n");
            Console.WriteLine($"1. View info");
            Console.WriteLine($"2. Borrow book");
            Console.WriteLine($"3. Return book");
            Console.WriteLine($"4. Back");
            Console.WriteLine($"5. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    book.printInfo();
                    Console.WriteLine();
                    this.BookInfo(book);
                    break;
                case 2:
                    this.BorrowBook(book);
                    break;
                case 3:
                    this.ReturnBook(book);
                    break;
                case 4:
                    this.SearchBook();
                    break;
                case 5:
                    return;
                    break;
            }
        }

        private void BorrowBook(Book book)
        {
            if(book.State == "available")
            {
                Console.WriteLine($"\n* BORROW BOOK *\n");

                Console.Write($"Start date: ");
                string startDate = Console.ReadLine();
                Console.Write($"End date: ");
                string endDate = Console.ReadLine();

                // crea prestito
                Rental rental = new Rental(book, UserLogged, startDate, endDate);

                // aggiungi prestito alla lista di prestiti dell'utente
                UserLogged.getRentals().Add(rental);

                book.State = "borrowed";
                Console.WriteLine($"\nYou have successfully borrowed the book!\n");

                this.LoggedPage();
            }
            else
            {
                Console.WriteLine($"\nThe book is not available!\n");
                this.BookInfo(book);
            }
        }

        private void ViewRentals()
        {
            if(UserLogged.getRentals().Count < 1)
            {
                Console.WriteLine("\nNo rentals to show.");
            }
            else
            {
                foreach (Rental rental in UserLogged.getRentals())
                {
                    rental.printInfo();
                }
            }

            this.LoggedPage();
        }

        private void ReturnBook(Book book)
        {
            book.State = "available";

            Rental rentalToDelete = null;

            foreach (Rental rental in UserLogged.getRentals())
            {
                if(rental.Document.Title == book.Title)
                {
                    rentalToDelete = rental;
                }
            }
            UserLogged.getRentals().Remove(rentalToDelete);

            Console.WriteLine($"\nThe book '{book.Title}' has been returned successfully!");
            this.LoggedPage();
        }

        private void ReturnDvd(Dvd dvd)
        {
            dvd.State = "available";

            Rental rentalToDelete = null;

            foreach (Rental rental in UserLogged.getRentals())
            {
                if (rental.Document.Title == dvd.Title)
                {
                    rentalToDelete = rental;
                }
            }
            UserLogged.getRentals().Remove(rentalToDelete);

            Console.WriteLine($"\nThe dvd '{dvd.Title}' has been returned successfully!");
            this.LoggedPage();
        }

        private void SearchDvd()
        {
            Console.WriteLine($"\n* SEARCH DVD *\n");
            Console.WriteLine($"1. Search by serial number");
            Console.WriteLine($"2. Search by title");
            Console.WriteLine($"3. Back");
            Console.WriteLine($"4. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    this.SearchDvdBySerial();
                    break;
                case 2:
                    this.SearchDvdByTitle();
                    break;
                case 3:
                    this.LoggedPage();
                    break;
                case 4:
                    return;
                    break;
            }
        }

        private void SearchDvdBySerial()
        {
            Console.WriteLine($"\n* SEARCH DVD *\n");
            Console.Write($"Insert serial number: ");
            string serial = Console.ReadLine();

            bool foundDvd = false;

            foreach (Dvd dvd in Dvds)
            {
                if (dvd.SerialNumber == serial)
                {
                    foundDvd = true;
                    this.DvdInfo(dvd);
                }
            }

            if (!foundDvd)
            {
                Console.WriteLine("\nDvd not found.");
                this.SearchBook();
            }
        }

        private void SearchDvdByTitle()
        {
            Console.WriteLine($"\n* SEARCH DVD *\n");
            Console.Write($"Insert title: ");
            string title = Console.ReadLine();

            bool foundDvd = false;

            foreach (Dvd dvd in Dvds)
            {
                if (dvd.Title == title)
                {
                    foundDvd = true;
                    this.DvdInfo(dvd);
                }
            }

            if (!foundDvd)
            {
                Console.WriteLine("\nDvd not found.");
                this.SearchBook();
            }
        }

        private void DvdInfo(Dvd dvd)
        {
            Console.WriteLine($"\n* DVD MENU *\n");
            Console.WriteLine($"1. View info");
            Console.WriteLine($"2. Borrow dvd");
            Console.WriteLine($"3. Return dvd");
            Console.WriteLine($"4. Back");
            Console.WriteLine($"5. Exit\n");

            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    dvd.printInfo();
                    Console.WriteLine();
                    this.DvdInfo(dvd);
                    break;
                case 2:
                    this.BorrowDvd(dvd);
                    break;
                case 3:
                    this.ReturnDvd(dvd);
                    break;
                case 4:
                    this.SearchBook();
                    break;
                case 5:
                    return;
                    break;
            }
        }

        private void BorrowDvd(Dvd dvd)
        {
            if (dvd.State == "available")
            {
                Console.WriteLine($"\n* BORROW DVD *\n");

                Console.Write($"Start date: ");
                string startDate = Console.ReadLine();
                Console.Write($"End date: ");
                string endDate = Console.ReadLine();

                // crea prestito
                Rental rental = new Rental(dvd, UserLogged, startDate, endDate);

                // aggiungi prestito alla lista di prestiti dell'utente
                UserLogged.getRentals().Add(rental);

                dvd.State = "borrowed";
                Console.WriteLine($"\nYou have successfully borrowed the dvd!\n");

                this.LoggedPage();
            }
            else
            {
                Console.WriteLine($"\nThe dvd is not available!\n");
                this.DvdInfo(dvd);
            }
        }
    }
}
