namespace csharp_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Users creation
            Classes.User user1 = new Classes.User("Sada", "Simone", "sada@gmail.com", "1234", "334 906669");
            Classes.User user2 = new Classes.User("Gianni", "Rossi", "gianni@gmail.com", "abcd", "333 3333333");
            Classes.User user3 = new Classes.User("Anna", "Verdi", "anna@gmail.com", "password", "333 2222222");

            // Users list
            List<Classes.User> users = new List<Classes.User>() { user1, user2, user3 };

            // Books creation
            Classes.Book tlotr = new Classes.Book("abc1", "The lord of the ring", 1900, "Fantasy", "available", "C1", "JRR Tolkien", 1000);
            Classes.Book hp = new Classes.Book("abc2", "Harry Potter", 2000, "Fantasy", "available", "C2", "JK Rowling", 300);
            // DVD creation
            Classes.Dvd matrix = new Classes.Dvd("001", "Matrix", 2000, "Sci-fi", "available", "B7", "author", 130);
            Classes.Dvd jp = new Classes.Dvd("002", "Jurassic Park", 2001, "Sci-fi", "available", "B9", "author", 120);

            // Documents list
            List<Classes.Book> books = new List<Classes.Book>() { tlotr, hp};
            List<Classes.Dvd> dvds = new List<Classes.Dvd>() { matrix, jp };

            //user1.Borrow(tlotr);

            Classes.Library library = new Classes.Library(users, books, dvds);

            library.UnloggedPage();


        }

  
    }
}