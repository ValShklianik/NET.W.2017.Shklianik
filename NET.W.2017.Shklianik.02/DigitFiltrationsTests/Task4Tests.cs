using Microsoft.VisualStudio.TestTools.UnitTesting;
using DigitFiltrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFiltrations.Tests
{
    [TestClass()]
    public class Task4Tests
    {
        [TestMethod()]
        public void FilterDigitTest_InputListOfNumber1_3_7_55_4_15_56_253_33_Expected55_15_56_253()
        {
            Task4 task4 = new Task4();
            List<int> list = new List<int> { 1, 3, 7, 55, 4, 15, 56, 253, 33 };
            int digit = 5;
            List<int> expected = new List<int> { 55,  15, 56, 253 };
            List<int> actual = task4.FilterDigit(list, digit);
            // Assert.AreEqual(actual.Count,expected.Count);
            Assert.IsTrue(actual.SequenceEqual(expected));
        }
    }
}