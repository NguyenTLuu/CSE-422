using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Book : IPrintable
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        private int _year;

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Year cannot be negative.");
                }
                _year = value;
            }
        }

        private int _copiesAvailable;
        public int CopiesAvailable
        {
            get
            {
                return _copiesAvailable;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Copies available cannot be negative.");
                }
                _copiesAvailable = value;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Copies Available: {CopiesAvailable}");
        }

        public void PrintDetails()
        {
            DisplayInfo();
        }
    }
}
