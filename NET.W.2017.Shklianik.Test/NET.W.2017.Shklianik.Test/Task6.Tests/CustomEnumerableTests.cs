using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};

            Assert.Inconclusive();
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, -10, 92, -796, 6920, -60136, 522608, -4541680, 39469088 };

            Assert.Inconclusive();
        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 3, 3.5, 4.16666666666667, 4.69047619047619, 5.29238095238095, 5.81880106357264, 6.39184849183592, 6.91728310858544 };

            Assert.Inconclusive();
        }
    }
}
