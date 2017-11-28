using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            
            var sequenceGenerator = new SequenceGenerator<int>(1, 1, SequenceGenerator<int>.FirstFormula);
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            CollectionAssert.AreEqual(expected, sequenceGenerator.GetSequence(10));
        }


        [Test]
        public void Generator_ForSequence2()
        {
            var sequenceGenerator = new SequenceGenerator<int>(1, 2, SequenceGenerator<int>.SecondFormula);
            int[] expected = { 1, 2, -10, 92, -796, 6920, -60136, 522608, -4541680, 39469088 };

            CollectionAssert.AreEqual(expected, sequenceGenerator.GetSequence(10));
        }

        [Test]
        public void Generator_ForSequence3()
        {
            var comparer = Comparer<double>.Create((a, b) => (int)(a-b));
            var sequenceGenerator = new SequenceGenerator<double>(1, 2, SequenceGenerator<double>.ThirdFormula);
            double[] expected = { 1, 2, 3, 3.5, 4.166666666666667d, 4.69047619047619, 5.29238095238095, 5.81880106357264, 6.39184849183592, 6.91728310858544 };

            CollectionAssert.AreEqual(expected, sequenceGenerator.GetSequence(10), comparer);
        }
    }
}
