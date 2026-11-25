using Exercise4.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public static class PaymentFactory
    {
        public static IPaymentStrategy Create(string method)
        {
            return method.ToLowerInvariant() switch
            {
                "creditcard" => new CreditCardPayment(),
                "paypal" => new PayPalPayment(),
                "crypto" => new CryptoPayment(),

                _ => throw new ArgumentException(
                    "Invalid payment method"
                )
            };
        }
    }
}
