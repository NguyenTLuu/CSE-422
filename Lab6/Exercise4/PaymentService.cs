using Exercise4.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class PaymentService
    {
        private readonly IPaymentStrategy _strategy;

        public PaymentService(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ProcessPayment(double amount)
        {
            _strategy.Pay(amount);
        }
    }
}
