using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Book.LogicTest
{
    [TestFixture]
    public class BookTests
    {
        #region ToString tests

        public static IEnumerable<TestCaseData> ToStringTestData
        {
            get
            {
                yield return new TestCaseData(string.Empty).Returns("ISBN 13: 978-0-7356-6745-7 Jeffrey Richter CLR via C# Microsoft Press 2012 826 59,99");
                yield return new TestCaseData("IATPYN").Returns("ISBN 13: 978-0-7356-6745-7 Jeffrey Richter CLR via C# Microsoft Press 2012 826");
                yield return new TestCaseData("ATPY").Returns("Jeffrey Richter CLR via C# Microsoft Press 2012");
                yield return new TestCaseData("ATP").Returns("Jeffrey Richter CLR via C# Microsoft Press");
                yield return new TestCaseData("AT").Returns("Jeffrey Richter CLR via C#");
            }
        }

        [Test, TestCaseSource(nameof(ToStringTestData))]
        public string BookToStringTests(string format)
        {
            var book = new Book.Logic.Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99m);

            return book.ToString(format);
        }

        [TestCase("TE")]
        [TestCase("tttt")]
        [TestCase("TTTT")]
        public void BookToStringFormatExceptionTests(string format)
        {
            var book = new Book.Logic.Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99m);

            Assert.Throws<FormatException>(() => book.ToString(format));
        }

        #endregion
    }
}
