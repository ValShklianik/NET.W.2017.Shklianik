using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootNewton
{
    public static class Task5
    {

        #region FindNthRootMethods
        public static double FindNthRoot(double a, int n, double prec)
        {
            if ((prec < 0) || (n < 0))
            {
                throw new ArgumentOutOfRangeException("Incorrect prec.");
            }
            double supposition = Math.Round((a / n), 6);
            double result = supposition;
            result = ((n - 1) * result + (a / Math.Pow(result, n - 1))) / n;
            while (Math.Abs(result - supposition) > prec)
            {
                supposition = result;
                result = ((n - 1) * result + (a / Math.Pow(result, n - 1))) / n;
            }

            int accuracy = 1;
            double tempprec = prec;
            while (tempprec < 1)
            {
                accuracy *= 10;
                tempprec *= 10;
            }

            return Math.Floor((result * accuracy + 0.1)) / accuracy;
        }
        #endregion
    }
}
