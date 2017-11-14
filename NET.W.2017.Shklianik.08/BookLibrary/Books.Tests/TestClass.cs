using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class BookTests
    {
        #region book.ToString test

        public static IEnumerable<TestCaseData> ToStringTestData
        {
            get
            {
                yield return new TestCaseData(string.Empty).Returns("ISBN 13: 978-0-7356-6745-7 Jeffrey Richter CLR via C# Microsoft Press 2012 826 60 ₽");
                yield return new TestCaseData("AN").Returns("Jeffrey Richter CLR via C#");
                yield return new TestCaseData("ANh").Returns("Jeffrey Richter CLR via C# Microsoft Press");
                yield return new TestCaseData("IANHYP").Returns("ISBN 13: 978-0-7356-6745-7 Jeffrey Richter CLR via C# Microsoft Press 2012 826");
                yield return new TestCaseData("AnHy").Returns("Jeffrey Richter CLR via C# Microsoft Press 2012");
            }
        }

        [Test, TestCaseSource(nameof(ToStringTestData))]
        public string BookToStringTests(string format)
        {
            var book = new Book.Logic.Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2012", 826, 59.99m);

            return book.ToString();
        }

        [TestCase("ef")]
        [TestCase("AAA")]
        [TestCase("ANN")]
        public void BookToStringFormatExceptionTests(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2012", 826, 59.99m);

            Assert.Throws<FormatException>(() => book.ToString(format));
        }

        #endregion // !book.ToString test.

        #region custom formatter tests

        [TestCase("{0:IAN}", ExpectedResult = "ISBN 13: 978-0-7356-6745-7 Jeffrey Richter CLR via C#")]
        [TestCase("{0:ANHY}", ExpectedResult = "Jeffrey Richter CLR via C# Microsoft Press 2012")]
        public string BookToStringCustomFormatterTests(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2012", 826, 59.99m);

            return string.Format(new CustomBookFormatter(), format, book);
        }

        [TestCase("{0:IfAN}")]
        [TestCase("{0:IfAweN}")]
        public void BookToStringCustomFormatterFormatExceptionTests(string format)
        {
            var book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", "2012", 826, 59.99m);

            Assert.Throws<FormatException>(() => string.Format(new CustomBookFormatter(), format, book));
        }

        #endregion // !custom formatter tests.
    }
}