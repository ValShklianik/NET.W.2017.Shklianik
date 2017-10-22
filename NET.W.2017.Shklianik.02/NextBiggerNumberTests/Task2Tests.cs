using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextBiggerNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber.Tests
{
    [TestClass()]
    public class Task2Tests
    {
        /*[TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]*/

        [TestMethod()]
        public void FindNextBiggerNumberTest_12_21Expected()
        {
            Task2 task2 = new Task2();
            long number = 12;
            long expected = 21;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_513_531Expected()
        {
            Task2 task2 = new Task2();
            long number = 513;
            long expected = 531;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_2017_2071Expected()
        {
            Task2 task2 = new Task2();
            long number = 2017;
            long expected = 2071;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_414_441Expected()
        {
            Task2 task2 = new Task2();
            long number = 414;
            long expected = 441;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_144_414Expected()
        {
            Task2 task2 = new Task2();
            long number = 144;
            long expected = 414;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_1234321_1241233Expected()
        {
            Task2 task2 = new Task2();
            long number = 1234321;
            long expected = 1241233;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_1234126_1234162Expected()
        {
            Task2 task2 = new Task2();
            long number = 1234126;
            long expected = 1234162;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_3456432_3462345Expected()
        {
            Task2 task2 = new Task2();
            long number = 3456432;
            long expected = 3462345;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_10_minus1Expected()
        {
            Task2 task2 = new Task2();
            long number = 10;
            long expected = -1;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void FindNextBiggerNumberTest_20_minus1Expected()
        {
            Task2 task2 = new Task2();
            long number = 20;
            long expected = -1;
            long actual = task2.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
        }


    }



}