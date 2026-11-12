using Lab5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Newspaper : IDocument
    {
        public string Title { get; private set; }

        public Newspaper(string title)
        {
            Title = title;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Newspaper: {Title}");
        }
    }
}
