using System;
using NUnit.Framework;
using NET.W._2017.Shklianik._05;

namespace NET.W._2017.ShklianikTests
{
    [TestFixture]
    class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3 }, ExpectedResult = "1,2,3")]
        [TestCase(new double[] { 0, 5, 8 }, ExpectedResult = "0,5,8")]
        public string ToStringTest_CorrectValues(double[] coeff1)
        {
            Polynomial pol1 = new Polynomial(coeff1);
            return pol1.ToString();
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 2 }, ExpectedResult = false)]
        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 }, ExpectedResult = false)]
        public bool EqualsTest_CorrectValues(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return p1.Equals(p2);
        }

        [Test]
        public void EqualsTest_NullInputValues()
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 0, 1 });
            Polynomial p2 = null;
            Assert.False(p1.Equals(p2));
        }

        [Test]
        public void EqualsTest_SameInputValues()
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 0, 1 });
            Polynomial p2 = p1;
            Assert.True(p1.Equals(p2));
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 3, 4, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { 1, 4, 1 })]
        public void OpPlus_CorrectValues(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1 + p2).Equals(expected));
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 1, -4, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { -1, -4, 1 })]
        public void OpMinus_CorrectValues(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1 - p2).Equals(expected));
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, new double[] { 2, 8, 1, 4 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 1, 4 }, new double[] { 0, 0, 1, 4 })]
        public void OpMultiply_CorrectValues(double[] array1, double[] array2, double[] result)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial expected = new Polynomial(result);
            Assert.True((p1 * p2).Equals(expected));
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 1 })]
        [TestCase(new double[] { 0, 0, 0 }, new double[] { 0, 0, 0 })]
        public void OpEqual_True(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.True(p1 == p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 2 })]
        public void OpEqual_False(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.False(p1 == p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 2 })]
        [TestCase(new double[] { 1, 0, 0 }, new double[] { 0, 0, 0 })]
        public void OpNotEqual_True(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.True(p1 != p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 2, 0, 1 })]
        [TestCase(new double[] { 0, 0, 1 }, new double[] { 0, 0, 1 })]
        [TestCase(new double[] { 0, 0 }, new double[] { 0, 0 })]
        public void OpNotEqual_False(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Assert.False(p1 != p2);
        }


        
    }
}
