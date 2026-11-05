using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; } = null!;
        public override void Execute()
        {
            BookReturned.CopiesAvailable++;

            Console.WriteLine("Return successful!");
            Console.WriteLine($"Member: {Member.Name}");
            Console.WriteLine($"Book: {BookReturned.Title}");
            Console.WriteLine(
                $"Available copies: {BookReturned.CopiesAvailable}"
            );
        }
    }
}
