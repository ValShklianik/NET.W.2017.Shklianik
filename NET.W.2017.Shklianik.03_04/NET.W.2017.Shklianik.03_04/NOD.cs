using System;
using System.Diagnostics;

namespace NET.W._2017.Shklianik._03_04
{
    public class NOD
    {
        #region public methods

        public delegate int funcNod(int lhs,int rhs);
        /// <summary>
        /// The GetTime method which call Euclid algorithm .
        /// </summary>
        /// <param name="operationTime">first number</param>
        /// <param name="firstEl">second number</param>
        /// <param name="params">second number</param>
        /// <returns>Greatest common divisor of  numbers</returns>
        public int GetTime(out TimeSpan operationTime, params int[] integers)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int result = GetNodByEvklid(integers);

            watch.Stop();
            operationTime = watch.Elapsed;
            return result;
        }

        public int[] GetNewArray(funcNod alg, int[] integers)
        {
            if(integers.Length == 0)
            {
                throw new ArgumentException("length of array is 0");
            }
            if (integers[0] == 0 || integers[1] == 0)
            {
                throw new ArgumentOutOfRangeException("kkk");
            }
            
            var newIntegers = new int[integers.Length - 1];
            newIntegers[0] = alg(Math.Abs(integers[0]), Math.Abs(integers[1]));
            for(int i=1; i < newIntegers.Length; i++)
            {
                newIntegers[i] = integers[i+1];
            }

            return newIntegers;

        }

        public int GetNodByEvklid(params int[] integers)
        {
            if (integers.Length == 1) return integers[0];
            return GetNodByEvklid(GetNewArray(GetNodPairByEvklid, integers));
        }


        public int GetNodByStein(params int[] integers)
        {
            if (integers.Length == 1) return integers[0];
            return GetNodByStein(GetNewArray(GetNodPairBySteint, integers));
        }
        #endregion



        #region private GetNod
        private int GetNodPairByEvklid(int firstEl, int secondEl)
        {
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
            return firstEl;
        }


        private int GetNodPairBySteint(int firstEl, int secondEl)
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
                    return GetNodPairBySteint(firstEl >> 1, secondEl);
                else
                    return GetNodPairBySteint(firstEl >> 1, secondEl >> 1) << 1;
            }
            if ((~secondEl & 1) != 0)
                return GetNodPairBySteint(firstEl, secondEl >> 1);
            if (firstEl > secondEl)
                return GetNodPairBySteint((firstEl - secondEl) >> 1, secondEl);
            return GetNodPairBySteint((secondEl - firstEl) >> 1, firstEl);

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
