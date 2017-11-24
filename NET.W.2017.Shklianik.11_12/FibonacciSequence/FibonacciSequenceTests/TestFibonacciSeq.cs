using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using FibonacciSequenceLogic;
using System.Linq;

namespace FibonacciSequenceTests
{
    [TestFixture]
    public class TestFibonacciSeq
    {
        public static IEnumerable intGenerateFibonacciSequence
        {
            get
            {
                yield return new TestCaseData(4).Returns(new int[4] { 0, 1, 1, 2 });
                yield return new TestCaseData(6).Returns(new int[6] { 0, 1, 1, 2, 3, 5 });
                yield return new TestCaseData(8).Returns(new int[8] { 0, 1, 1, 2, 3, 5, 8, 13 });

            }

        }

        public static IEnumerable ExceptionTestCases
        {
            get
            {
                yield return new TestCaseData(-1);
                yield return new TestCaseData(0);

            }

        }

        [Test, TestCaseSource("ExceptionTestCases")]
        public void ExceptionFibonacciSequenceTest(int length)
        {
            Assert.Throws<ArgumentException>(() => FibonacciSequence.GetFibSecuence(length).First());
        }

        [Test, TestCaseSource("intGenerateFibonacciSequence")]
        public IEnumerable FibonacciSequenceTest(int length) => FibonacciSequence.GetFibSecuence(length);

        
    }
}
