using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextBiggerNumber;

namespace NextBiggerNumberTests
{
    
    [TestClass]
    public class Task3Tests
    {

        [TestMethod()]
        public void FindNextBiggerNumber_GetTime_EqualExpected()
        {
            Task3 task3 = new Task3();
            long number = 20;
            long expected = -1;
            long actual = task3.FindNextBiggerNumber(number);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(task3.Time, task3.Time2);
        }
    }
}
