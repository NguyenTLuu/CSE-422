using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4.Strategies
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine(
                $"Processing credit card payment: {amount}"
            );
        }
    }
}
