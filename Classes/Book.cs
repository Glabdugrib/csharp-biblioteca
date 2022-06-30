using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Book : Document
    {
        public string Isbn { get; set; }
        public uint PageNum { get; set; }

        public Book(string isbn, string title, uint year, string sector, string state, string shelf, string author, uint pageNum) : base(title, year, sector, state, shelf, author)
        {
            Isbn = isbn;
            PageNum = pageNum;
        }

        public override void printInfo()
        {
            base.printInfo();
            Console.WriteLine($"Isbn: {Isbn}");
            Console.WriteLine($"Page number: {PageNum}");
        }
    }
}
