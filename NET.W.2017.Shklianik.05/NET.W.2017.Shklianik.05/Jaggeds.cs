using System;
using System.Linq;

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

        /// <inheritdoc />
        /// <summary>
        /// The class that adapts the delegate COmparision to the interface ICOmparer.
        /// </summary>
        public class AdapterComparision : IComparer
        {
            private Comparison<int[]> comparision;
            /// <summary>
            /// Initializes an adapter instance.
            /// </summary>
            /// <param name="comparision">the delegate for the conversion to the interface ICOmparer</param>
            /// <exception cref="ArgumentNullException">Thrown when <paramref name="comparision"/> is null.</exception>
            public AdapterComparision(Comparison<int[]> comparision)
            {
                if (ReferenceEquals(comparision, null))
                {
                    throw new ArgumentNullException(nameof(comparision));
                }
                this.comparision = comparision;
            }

            /// <inheritdoc />
            public int Compare(int[] lhs, int[] rhs)
            {
                return comparision(lhs, rhs);
            }
        }

        public static class ArrayHelper
        {

            public static void Sort(int[][] jaggedArray, Comparison<int[]> comparision) => BubbleSort(jaggedArray, new AdapterComparision(comparision));

            public static void Sort(int[][] jaggedArray, IComparer comparer) => BubbleSort(jaggedArray, comparer);

            /// <summary>
            /// The BubbleSort method which sorts of elements.
            /// </summary>
            /// <param name="jaggedArray"> array</param>
            /// <param name="comarer">comparer</param>
            /// <returns>sortind array</returns>
            private static void BubbleSort(int[][] jaggedArray, IComparer comparer)
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

        public static class ArrayHelper2
        {
            public static void Sort(int[][] jaggedArray, IComparer comparer) => BubbleSort(jaggedArray, comparer.Compare);
            public static void Sort(int[][] jaggedArray, Comparison<int[]> comparison) => BubbleSort(jaggedArray, comparison);

            /// <summary>
            /// The BubbleSort method which sorts of elements.
            /// </summary>
            /// <param name="jaggedArray"> array</param>
            /// <param name="comarer">comparer</param>
            /// <returns>sortind array</returns>
            private static void BubbleSort(int[][] jaggedArray, Comparison<int[]> comparer)
            {
                if (jaggedArray == null)
                {
                    throw new ArgumentNullException(nameof(jaggedArray));
                }
                for (int i = 1; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray.Length - 1; j++)
                    {
                        if (comparer(jaggedArray[j], jaggedArray[j + 1]) > 0)
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
