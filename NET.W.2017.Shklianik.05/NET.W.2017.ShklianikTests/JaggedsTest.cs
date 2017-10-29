using System;
using NUnit.Framework;
using NET.W._2017.Shklianik._05;
using System.Collections;

namespace NET.W._2017.ShklianikTests
{
    [TestFixture]
    class JaggedsTests
    {
        public bool isEquals(int[][] input, int[][] expcted)
        {
            if (input.Length != expcted.Length) return false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Length != expcted[i].Length) return false;
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] != expcted[i][j]) return false;
                }
            }
            return true;
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByIncSum))]
        public bool ComparerSumByIncTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerSumByInc());
            return isEquals(input, expcted);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByDecSum))]
        public bool ComparerSumByDecTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerSumByDec());
            return isEquals(input, expcted);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByDecMax))]
        public bool ComparerMaxByDecTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerMaxByDec());
            return isEquals(input, expcted);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByIncMax))]
        public bool ComparerMaxByIncTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerMaxByInc());
            return isEquals(input, expcted);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByDecMax))]
        public bool ComparerMinByDecTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerMinByDec());
            return isEquals(input, expcted);
        }

        [Test, TestCaseSource(typeof(TestCasesClass), nameof(TestCasesClass.TestCasesByIncMin))]
        public bool ComparerMinByIncTest(int[][] input, int[][] expcted)
        {
            Jaggeds.ArrayHelper.BubbleSort(input, new Jaggeds.ComparerMinByInc());
            return isEquals(input, expcted);
        }

        public class TestCasesClass
        {
            public static IEnumerable TestCasesByIncSum
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } }).Returns(false);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(true);
                }
            }

            public static IEnumerable TestCasesByDecSum
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } }).Returns(true);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(false);
                }
            }

            public static IEnumerable TestCasesByDecMax
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } }).Returns(true);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(false);
                }
            }

            public static IEnumerable TestCasesByIncMax
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } }).Returns(false);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 1, 2, 3, 4 } },
                        new[] { new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(true);
                }
            }

            public static IEnumerable TestCasesByDecMin
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } }).Returns(true);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } },
                        new[] { new[] { 0, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(false);
                }
            }

            public static IEnumerable TestCasesByIncMin
            {
                get
                {
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } },
                        new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } }).Returns(false);
                    yield return new TestCaseData(new[] { new[] { 4, 3, 2, 1, 5 }, new[] { 0, 2, 3, 4 } },
                        new[] { new[] { 0, 2, 3, 4 }, new[] { 4, 3, 2, 1, 5 } }).Returns(true);
                }
            }
        }
    }
}
