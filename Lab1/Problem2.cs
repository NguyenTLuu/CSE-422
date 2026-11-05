
namespace Lab1
{
    public class DivideTwoIntegers
    {
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            long a = Math.Abs((long)dividend);
            long b = Math.Abs((long)divisor);

            int count = 0;

            while (a >= b)
            {
                a -= b;
                count++;
            }

            if ((dividend < 0) != (divisor < 0))
            {
                return -count;
            }

            return count;
        }
    }
}
