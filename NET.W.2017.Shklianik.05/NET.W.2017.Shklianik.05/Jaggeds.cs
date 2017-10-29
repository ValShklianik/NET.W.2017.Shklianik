using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._05
{
    public class Jaggeds
    {
#region interface
        public interface IComparer
        {
            int Compare(int[] lhs, int[] rhs);
        }
        #endregion
        #region public classes

        /// <summary>
        /// The ComparerSumByInc class : IComparer.
        /// </summary>
        public class ComparerSumByInc : IComparer
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
        public class ComparerSumByDec : IComparer
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

        public class ComparerMaxByInc : IComparer
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
        public class ComparerMaxByDec : IComparer
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

        public class ComparerMinByInc : IComparer
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
        public class ComparerMinByDec : IComparer
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

        public static class ArrayHelper
        {
            /// <summary>
            /// The BubbleSort method which sorts of elements.
            /// </summary>
            /// <param name="jaggedArray"> array</param>
            /// <param name="comarer">comparer</param>
            /// <returns>sortind array</returns>
            public static void BubbleSort(int[][] jaggedArray, IComparer comparer)
            {
                if (jaggedArray == null)
                {
                    throw new ArgumentNullException(nameof(jaggedArray));
                }
                for (int i = 1; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray.Length - 1; j++)
                    {
                        if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                        {
                            Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                        }
                    }
                }
            }
        }

       
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public static int SumOfRowElemets(int[] array) => array.Sum();
        #endregion
    }

}
