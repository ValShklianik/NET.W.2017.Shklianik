using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootNewton
{
    public class Task5
    {

        public double FindNthRoot(double n, double A, double eps)
        {
            if (eps < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            double x0 = A / n;
            double x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Math.Pow(x0, (int)n - 1));
            }

            return x1;
        }
    }
}
