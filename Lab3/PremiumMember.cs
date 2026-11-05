using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class PremiumMember : Member
    {
        public DateTime MembershipExpiry { get; set; }
        public int MaxBooksAllowed { get; set; }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Membership Expiry: {MembershipExpiry.ToShortDateString()}");
            Console.WriteLine($"Max Books Allowed: {MaxBooksAllowed}");
        }

        public override void BorrowBook(Book book)
        {
            if (MembershipExpiry.Date < DateTime.Today)
            {
                Console.WriteLine("Premium membership has expired.");
                return;
            }

            Console.WriteLine("Premium member borrowing:");

            base.BorrowBook(book);
        }

        public override void ReturnBook(Book book)
        {
            Console.WriteLine("Premium member returning:");

            base.ReturnBook(book);
        }
    }
}
