using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Dvd : Document
    {
        public string SerialNumber { get; set; }
        public uint Duration { get; set; } // minutes
        public Dvd(string serialNumber, string title, uint year, string sector, string state, string shelf, string author, uint duration) : base(title, year, sector, state, shelf, author)
        {
            SerialNumber = serialNumber;
            Duration = duration;
        }

        public override void printInfo()
        {
            base.printInfo();
            Console.WriteLine($"Serial number: {SerialNumber}");
            Console.WriteLine($"Duration: {Duration}");
        }
    }
}
