using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Document
    {
        public string Title { get; set; }
        public uint Year { get; set; }
        public string Sector { get; set; }
        public string State { get; set; } // borrowed, available
        public string Shelf { get; set; }
        public string Author { get; set; }

        public Document(string title, uint year, string sector, string state, string shelf, string author)
        {
            Title = title;
            Year = year;
            Sector = sector;
            State = state;
            Shelf = shelf;
            Author = author;
        }

        public virtual void printInfo()
        {
            Console.WriteLine($"\nTitle: {Title}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Sector: {Sector}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Shelf: {Shelf}");
            Console.WriteLine($"Author: {Author}");
        }
    }
}
