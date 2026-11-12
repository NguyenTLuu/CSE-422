using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Strategy
{
    public class BookFeeStrategy : IFeeStrategy
    {
        public decimal CalculateFee(int days)
        {
            return days * 2000m;
        }
    }
}
