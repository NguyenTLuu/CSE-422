using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class LibraryCard
    {
        public string CardNumber { get; }
        public Member Owner { get; set; }
        public DateTime IssueDate { get; private set; }

        public LibraryCard(string cardNumber, Member owner)
        {
            CardNumber = cardNumber;
            Owner = owner;
            IssueDate = DateTime.Now;
        }

        public void RenewCard()
        {
            IssueDate = DateTime.Now;

            Console.WriteLine("Library card renewed successfully!");
        }

        public void DisplayCardInfo()
        {
            Console.WriteLine($"Card Number: {CardNumber}");
            Console.WriteLine($"Owner: {Owner.Name}");
            Console.WriteLine($"Issue Date: {IssueDate:dd/MM/yyyy HH:mm:ss}");
        }
    }
}
