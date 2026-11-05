using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class NotificationService
    {
        // Send a general notification
        public virtual void SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }

        // Send notification to one recipient
        public void SendNotification(string message, string recipient)
        {
            Console.WriteLine($"To {recipient}: {message}");
        }

        // Send notification to multiple recipients
        public void SendNotification(
            string message,
            List<string> recipients)
        {
            foreach (string recipient in recipients)
            {
                Console.WriteLine($"To {recipient}: {message}");
            }
        }

        public void NotifyBorrowed(Book book, Member member)
        {
            string message =
                $"{member.Name} borrowed the book '{book.Title}'.";

            SendNotification(message);
        }
    }
}
