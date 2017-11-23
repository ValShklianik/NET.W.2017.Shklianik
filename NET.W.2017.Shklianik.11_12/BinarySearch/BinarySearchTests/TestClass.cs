using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using BinarySearchLogic;

namespace BinarySearchTests
{
    [TestFixture]
    public class BinarySearcherTests
    {
        #region test cases
        public static IEnumerable IntComparisonTestCases
        {
            get
            {
                var array = new int[] { 9, 8, 7, 6, 4, 3, 2 };
                Comparison<int> comparison = (int l, int r) => r.CompareTo(l);
                yield return new TestCaseData(array, 0, comparison).Returns(-1);
                yield return new TestCaseData(array, 5, comparison).Returns(-1);
                yield return new TestCaseData(array, 9, comparison).Returns(0);
                yield return new TestCaseData(array, 3, comparison).Returns(5);
                yield return new TestCaseData(array, 10, comparison).Returns(-1);
            }
        }

        public static IEnumerable IntComparerTestCases
        {
            get
            {
                var array = new int[] { 9, 8, 7, 6, 4, 3, 2 };
                var comparer = new IntComparer();
                yield return new TestCaseData(array, 0, comparer).Returns(-1);
                yield return new TestCaseData(array, 5, comparer).Returns(-1);
                yield return new TestCaseData(array, 9, comparer).Returns(0);
                yield return new TestCaseData(array, 3, comparer).Returns(5);
                yield return new TestCaseData(array, 10, comparer).Returns(-1);
            }
        }

        public static IEnumerable StringComparisonTestCases
        {
            get
            {
                var array2 = new string[] { "Z", "x", "M", "f", "A" };
                Comparison<string> comparison = (string l, string r) => r.CompareTo(l);
                yield return new TestCaseData(array2, "z", comparison).Returns(-1);
                yield return new TestCaseData(array2, "F", comparison).Returns(-1);
                yield return new TestCaseData(array2, "Z", comparison).Returns(0);
                yield return new TestCaseData(array2, "x", comparison).Returns(1);
                yield return new TestCaseData(array2, "A", comparison).Returns(4);
            }
        }

        public static IEnumerable StringComparerTestCases
        {
            get
            {
                var array = new string[] { "Z", "x", "M", "f", "A" };
                var comparer = new StringComparer();
                yield return new TestCaseData(array, "z", comparer).Returns(-1);
                yield return new TestCaseData(array, "F", comparer).Returns(-1);
                yield return new TestCaseData(array, "Z", comparer).Returns(0);
                yield return new TestCaseData(array, "x", comparer).Returns(1);
                yield return new TestCaseData(array, "A", comparer).Returns(4);
            }
        }

        public static IEnumerable ExceptionTestCases
        {
            get
            {
                var array = new object[5];
                yield return new TestCaseData(array, array[2]);
            }
        }
        #endregion

        #region tests
        [Test, TestCaseSource("IntComparisonTestCases")]
        public int BinarySearchIntComparisonTest(int[] array, int elem, Comparison<int> comparison)
        {
            return BinarySearch.Find(array, elem, comparison);
        }

        

        [Test, TestCaseSource("StringComparisonTestCases")]
        public int BinarySearchStringComparisonTest(string[] array, string elem, Comparison<string> comparison)
        {
            return BinarySearch.Find(array, elem, comparison);
        }

        
        [Test, TestCaseSource("ExceptionTestCases")]
        public void BinarySearchExceptionTest(object[] array, object elem)
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Find(array, elem, null));
        }
        #endregion

        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        private class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return y.CompareTo(x);
            }
        }
    }
}
