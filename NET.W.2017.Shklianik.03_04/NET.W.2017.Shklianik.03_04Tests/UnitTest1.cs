using System;
using NUnit.Framework;
using NET.W._2017.Shklianik._03_04;

namespace NET.W._2017.Shklianik._03_04Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void GetNodByEvklid_params6_9_12_Expected_3()
        {
            NOD nodEvklid = new NOD();
            int actual = nodEvklid.GetNodByEvklid(6,9,12);
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetNodByStein_params6_9_12_Expected_3()
        {
            NOD nodEvklid = new NOD();
            int actual = nodEvklid.GetNodByStein(6, 9, 12);
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        //[TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        //[TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        //[TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        //[TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        //[TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        //[TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]

        public string Converter_double_expected(double number)
        {
 
            return Converter.NumConverter(number);
        }
    }
}
