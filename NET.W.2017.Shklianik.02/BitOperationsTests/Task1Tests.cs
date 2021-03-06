﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitOperations;

namespace BitOperations.Tests
{
    [TestClass]
    public class Task1Tests
    {
        [TestMethod]
        public void InsertNumber_InsertFrom15To8FromBit3ToBit8_120Expected()
        {
            int numberSource = 8;
            int numberIn = 15;
            byte j = 8;
            byte i = 3;
            int expected = 120;

            int actual = Task1.InsertNumber(numberSource, numberIn, j, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_InsertFrom15To8FromBit0ToBit0_9Expected()
        {
            int numberSource = 8;
            int numberIn = 15;
            byte j = 0;
            byte i = 0;
            int expected = 9;

            int actual = Task1.InsertNumber(numberSource, numberIn, j, i);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_InsertFrom15To15FromBit0ToBit0_15Expected()
        {
            int numberSource = 15;
            int numberIn = 15;
            byte j = 0;
            byte i = 0;
            int expected = 15;

            int actual = Task1.InsertNumber(numberSource, numberIn, j, i);
            Assert.AreEqual(expected, actual);
        }
    }
}