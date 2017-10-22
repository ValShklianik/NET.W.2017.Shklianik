using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace NextBiggerNumber
{
    public class Task2
    {

        public long FindNextBiggerNumber(long number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            if (IsNumberDecrease(number))
            {
                return -1;
            }
            string sNumber = ToSortedString(number);
            long nextNumber = ++number;
            string sNext = ToSortedString(nextNumber);
            while (sNumber != sNext)
            {
                sNext = ToSortedString(++nextNumber);
            }
            return nextNumber;

        }
        private static bool IsNumberDecrease(long number)
        {
            int prevDigit = (int)number % 10;
            int nextDigit = 0;
            number = number / 10;

            while (number != 0)
            {
                nextDigit = (int)number % 10;
                if (prevDigit > nextDigit)
                {
                    return false;
                }
                number = number / 10;
                prevDigit = nextDigit;

            }
            return true;
        }
        private static string ToSortedString(long number)
        {
            char[] array = number.ToString().ToCharArray();
            Array.Sort(array);
            return new String(array);


        }
    }

    
}
