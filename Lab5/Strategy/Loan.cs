using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Strategy
{
    public class Loan
    {
        private readonly IFeeStrategy _feeStrategy;

        public Loan(IFeeStrategy feeStrategy)
        {
            _feeStrategy = feeStrategy;
        }

        public decimal GetFee(int days)
        {
            if (days < 0)
            {
                throw new ArgumentException(
                    "Borrowing days cannot be negative."
                );
            }

            return _feeStrategy.CalculateFee(days);
        }
    }
}
