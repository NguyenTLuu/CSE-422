using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Member : IPrintable, IMemberActions
    {
        public string MemberID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
        }

        public void PrintDetails()
        {
            DisplayInfo();
        }

        public virtual void BorrowBook(Book book)
        {
            if (book.CopiesAvailable > 0)
            {
                book.CopiesAvailable--;

                Console.WriteLine($"{Name} borrowed {book.Title}.");
                Console.WriteLine(
                    $"Remaining copies: {book.CopiesAvailable}"
                );
            }
            else
            {
                Console.WriteLine("No copies available.");
            }
        }

        public virtual void ReturnBook(Book book)
        {
            book.CopiesAvailable++;

            Console.WriteLine($"{Name} returned {book.Title}.");
            Console.WriteLine(
                $"Available copies: {book.CopiesAvailable}"
            );
        }
    }
}
