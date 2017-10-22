using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindNthRootNewton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRootNewton.Tests
{
    [TestClass()]
    public class Task5Tests
    {
        /*[TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        */


        [TestMethod()]
        public void FindNthRootTest_Number1_degree5_precision0001_1Expected()
        {
            Task5 task5 = new Task5();
            double n = 5.0;
            double a = 1.0;
            double precision = 0.0001;
            double expected = 1.0;
            double actual = task5.FindNthRoot(n, a, precision);
            //Assert.AreEqual(Math.Abs(expected,actual);
            Assert.IsTrue(Math.Abs(actual-expected)<=precision);

        }

        [TestMethod()]
        public void FindNthRootTest_Number8_degree3_precision0001_2Expected()
        {
            Task5 task5 = new Task5();
            double n = 3.0;
            double a = 8.0;
            double precision = 0.0001;
            double expected = 2.0;
            double actual = task5.FindNthRoot(n, a, precision);
            //Assert.AreEqual(Math.Abs(expected,actual);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }

        [TestMethod()]
        public void FindNthRootTest_Number001_degree3_precision0001_0dot1Expected()
        {
            Task5 task5 = new Task5();
            double n = 3.0;
            double a = 0.001;
            double precision = 0.0001;
            double expected = 0.1;
            double actual = task5.FindNthRoot(n, a, precision);
            //Assert.AreEqual(Math.Abs(expected,actual);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }


        [TestMethod()]
        public void FindNthRootTest_Number0dot04100625_degree4_precision0001_0dot45Expected()
        {
            Task5 task5 = new Task5();
            double n = 4.0;
            double a = 0.04100625;
            double precision = 0.0001;
            double expected = 0.45;
            double actual = task5.FindNthRoot(n, a, precision);
            //Assert.AreEqual(Math.Abs(expected,actual);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }
        /*
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        */
        [TestMethod()]
        public void FindNthRootTest_Number0dot0279936_degree7_precision0001_0dot6Expected()
        {
            Task5 task5 = new Task5();
            double n = 7.0;
            double a = 0.0279936;
            double precision = 0.0001;
            double expected = 0.6;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }

        [TestMethod()]
        public void FindNthRootTest_Number0dot0081_degree4_precision0dot1_0dot3Expected()
        {
            Task5 task5 = new Task5();
            double n = 4.0;
            double a = 0.0081;
            double precision = 0.1;
            double expected = 0.3;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }


        [TestMethod()]
        public void FindNthRootTest_NumberMinus0dot008_degree3_precision0dot1_Minus0dot2Expected()
        {
            Task5 task5 = new Task5();
            double n = 3.0;
            double a = -0.008;
            double precision = 0.1;
            double expected = -0.2;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }


        [TestMethod()]
        public void FindNthRootTest_Number0do004241979_degree9_precision0dot00000001_0dot545Expected()
        {
            Task5 task5 = new Task5();
            double n = 9.0;
            double a = 0.004241979;
            double precision = 0.00000001;
            double expected = 0.545;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }
        /*-----------------------------
        [TestCase(8, 15, -7, -5)]// <-ArgumentOutOfRangeException
        [TestCase(8, 15, -0.6, -0.1)]// <-ArgumentOutOfRangeException*/


        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRootTest_Number8_degree15_precisionMinus7_ErrorExpected()
        {
            Task5 task5 = new Task5();
            double n = 5.0;
            double a = 8;
            double precision = -7;
            double expected = -5;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRootTest_Number8_degree15_precisionMinus0dot6_ErrorExpected()
        {
            Task5 task5 = new Task5();
            double n = 5.0;
            double a = 8;
            double precision = -0.6;
            double expected = -0.1;
            double actual = task5.FindNthRoot(n, a, precision);
            Assert.IsTrue(Math.Abs(actual - expected) <= precision);

        }


    }
}