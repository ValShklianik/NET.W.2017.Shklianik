using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections;
using static FindNthRootNewton.Task5;

namespace FindNthRootNewton.Tests
{
    [TestClass()]
    public class Task5Tests
    {
        #region FindNthRootTests
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]

        public double FindNthRoot_Number_Degree_Precision(double number, int degree, double precision)
        {
            return Math.Round(FindNthRoot(number, degree, precision), 3);

        }


        [TestCase(8, 15, -7, -5)]// <-ArgumentOutOfRangeException
        [TestCase(8, 15, -0.6, -0.1)]// <-ArgumentOutOfRangeException	
        public void FindNthRoot_Number_Degree_Precision_ArgumentOutOfRangeException(double number, int degree,
            double precision, double expected)
        {
            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRoot(number, degree, precision));
        }
        #endregion


    }
}