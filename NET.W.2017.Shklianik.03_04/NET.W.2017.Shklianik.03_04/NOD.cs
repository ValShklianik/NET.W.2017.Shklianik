using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._03_04
{
    public class NOD
    {
        #region public methods

        /// <summary>
        /// The GetTime method which call Euclid algorithm .
        /// </summary>
        /// <param name="operationTime">first number</param>
        /// <param name="firstEl">second number</param>
        /// <param name="params">second number</param>
        /// <returns>Greatest common divisor of  numbers</returns>

        public int GetTime(out TimeSpan operationTime, int firsEl, params int[] integers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int result = GetNodByEvklid(firsEl,integers);

            watch.Stop();
            operationTime = watch.Elapsed;
            return result;
        }
        public int GetNodByEvklid(int firstEl, params int[] integers)
        {
            firstEl = Math.Abs(firstEl);
            if (integers.Length == 0)
            {
                return firstEl;
            }

            int secondEl = Math.Abs(integers[0]);

            if (firstEl ==0 || secondEl == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            while (firstEl != secondEl)
            {
                if (firstEl > secondEl)
                {
                    firstEl = firstEl - secondEl;
                }
                else
                {
                    secondEl = secondEl - firstEl;
                }
            }

            var others = new int[integers.Length - 1];

            for(int i = 0; i < others.Length; i++)
            {
                others[i] = integers[i + 1];
            }

            return GetNodByEvklid(firstEl, others);
        }


        public int GetNodByStein(int firstEl, params int[] integers)
        {
            firstEl = Math.Abs(firstEl);

            if (integers.Length == 0)
            {
                return firstEl;
            }
            int secondEl = Math.Abs(integers[0]);

            var others = new int[integers.Length - 1];
      
            for (int i = 0; i < others.Length; i++)
            {
                others[i] = integers[i + 1];
            }

            return GetNodByStein(GetNod(firstEl, secondEl), others);
        }
#endregion 



        #region private GetNod
        private int GetNod(int firstEl, int secondEl)
        {
            if (firstEl == secondEl)
                return firstEl;
            if (firstEl == 0)
                return secondEl;
            if (secondEl == 0)
                return firstEl;
            if ((~firstEl & 1) != 0)
            {
                if ((secondEl & 1) != 0)
                    return GetNod(firstEl >> 1, secondEl);
                else
                    return GetNod(firstEl >> 1, secondEl >> 1) << 1;
            }
            if ((~secondEl & 1) != 0)
                return GetNod(firstEl, secondEl >> 1);
            if (firstEl > secondEl)
                return GetNod((firstEl - secondEl) >> 1, secondEl);
            return GetNod((secondEl - firstEl) >> 1, firstEl);

        }
#endregion 
    }

    public static class Converter
    {
        /// <summary>
        /// The NumConverter method which  call GetBin method.
        /// </summary>
        /// <param name="doubNumber">first number</param>
        /// <returns>converted number to binary String</returns>
        public static string NumConverter(double doubNumber)
        {
            string sign = "";
            if (doubNumber < 0)
            {
                sign = "1";
            }
            else
            {
                sign = "0";
            }
            
            long wholePart = (long)Math.Abs(doubNumber);
            double fractPart = Math.Abs(doubNumber) - wholePart;
            string binWholePart =  GetBin(wholePart);
            string binFractPart = "";
            int mantisLength = 52;
            int exp = binWholePart.Length - 1;

            while( (mantisLength- binFractPart.Length-exp) > 0)
            {
               
                fractPart *= 2;
                if (fractPart >= 1)
                {
                    binFractPart += "1";
                    fractPart -= 1;
                }
                else binFractPart += "0";
            }

            if(binWholePart.Length != 0)
            {
                binWholePart = binWholePart.Remove(0, 1);
            }
            string mantis = binWholePart+binFractPart;
            string binExp = GetBin(exp + 1023);
            string binNumber = sign + binExp + mantis;

            return binNumber;
        }

#region private GetBin
        private static string GetBin(long num)
        {
            string bin = "";
            while (num != 0)
            {
                if (num % 2 == 1)
                {
                    bin = "1" + bin;
                }
                else bin = "0" + bin;
                num /= 2;
            }
            while (bin.StartsWith("0"))
            {
                bin = bin.Remove(0, 1);
            }

            return bin;
        }
#endregion

    }
}
