using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4.Strategies
{
    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine(
                $"Processing cryptocurrency payment: {amount}"
            );
        }
    }
}
