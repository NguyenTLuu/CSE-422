using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; } = null!;
        public override void Execute()
        {
            if (BookBorrowed.CopiesAvailable > 0)
            {
                BookBorrowed.CopiesAvailable--;
                Console.WriteLine("Borrow successful!");
                Console.WriteLine($"Member: {Member.Name}");
                Console.WriteLine($"Book: {BookBorrowed.Title}");
                Console.WriteLine(
                    $"Remaining copies: {BookBorrowed.CopiesAvailable}"
                );
            }
            else
            {
                Console.WriteLine("Borrow failed!");
                Console.WriteLine("No copies available.");
            }
        }
    }
}
