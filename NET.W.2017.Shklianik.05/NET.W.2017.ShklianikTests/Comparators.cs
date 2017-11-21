using System;
using System.Collections.Generic;
using System.Linq;
using NET.W._2017.Shklianik._05;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.ShklianikTests
{
    class Comparators
    {
        #region public classes

        /// <summary>
        /// The ComparerSumByInc class : IComparer.
        /// </summary>
        public class ComparerSumByInc : IComparer<int[]>
        {

            /// <summary>
            /// The Compare method which return diff betwen sum of lements.
            /// </summary>
            /// <param name="lhs">first array</param>
            /// <param name="rhs">second array</param>
            /// <returns>different betwen sum of lements</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Sum() - rhs.Sum();
            }
        }

        /// <summary>
        /// The ComparerSumByDec class : IComparer.
        /// </summary>
        public class ComparerSumByDec : IComparer<int[]>
        {
            /// <summary>
            /// The Compare method which return diff betwen sum of lements.
            /// </summary>
            /// <param name="lhs">first array</param>
            /// <param name="rhs">second array</param>
            /// <returns>different betwen sum of lements</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1;
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Sum() - lhs.Sum();
            }
        }

        public class ComparerMaxByInc : IComparer<int[]>
        {
            /// <summary>
            /// The Compare method which return diff betwen max of lements.
            /// </summary>
            /// <param name="lhs">first array</param>
            /// <param name="rhs">second array</param>
            /// <returns>different betwen max of lements</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Max() - rhs.Max();
            }
        }
        public class ComparerMaxByDec : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1;
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Max() - lhs.Max();
            }
        }

        public class ComparerMinByInc : IComparer<int[]>
        {
            /// <summary>
            /// The Compare method which return diff betwen min of lements.
            /// </summary>
            /// <param name="lhs">first array</param>
            /// <param name="rhs">second array</param>
            /// <returns>different betwen min of lements</returns>
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Min() - rhs.Min();
            }
        }
        public class ComparerMinByDec : IComparer<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1;
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Min() - lhs.Min();
            }
        }

    }
}
#endregion