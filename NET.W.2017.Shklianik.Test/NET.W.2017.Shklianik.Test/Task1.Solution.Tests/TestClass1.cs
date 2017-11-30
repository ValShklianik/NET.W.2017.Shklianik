using NUnit.Framework;
using System;
using System.Collections;
using Moq;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class TestPasswordCheckerService
    {
        public static IEnumerable passwordStringChaked
        {
            get
            {
                yield return new TestCaseData("qWerT1236").Returns(Tuple.Create(true, "Password is Ok. User was created"));
                yield return new TestCaseData("...111...ww").Returns(Tuple.Create(true, "Password is Ok. User was created"));
                yield return new TestCaseData("C#_ASP.NET4").Returns(Tuple.Create(true, "Password is Ok. User was created"));
                yield return new TestCaseData("1").Returns(Tuple.Create(false, $"1 length too short"));
                yield return new TestCaseData("qqqqqqqqqqqqqqqqq111111111111111").Returns(Tuple.Create(false, "qqqqqqqqqqqqqqqqq111111111111111 length too long"));
                yield return new TestCaseData("").Returns(Tuple.Create(false, $"password is empty "));
                yield return new TestCaseData("111123401").Returns(Tuple.Create(false, "111123401 hasn't alphanumerical chars"));
                yield return new TestCaseData("QQQqqqqq").Returns(Tuple.Create(false, "QQQqqqqq hasn't digits"));
            }
        }

        public static IEnumerable passwordStringCustomChaked
        {
            get
            {
                yield return new TestCaseData("qwerty1234").Returns(Tuple.Create(false, "qwerty1234 is very easy. For amebs"));
                yield return new TestCaseData("qwerty1235").Returns(Tuple.Create(true, "Password is Ok. User was created"));
            }
        }

        public static IEnumerable SevingSuccessPasswordsInRepoMoq
        {
            get
            {
                yield return new TestCaseData("qWerT1236");
                yield return new TestCaseData("TRRRRRRRRUUu12");
                yield return new TestCaseData("1a1a2a2s2");
                yield return new TestCaseData("...111...ww");
                yield return new TestCaseData("dsgdg45454");
                yield return new TestCaseData("C#_ASP.NET4");              
            }
        }

        public static IEnumerable SevingUnsuccessPasswordsInRepoMoq
        {
            get
            {
                yield return new TestCaseData("1");
                yield return new TestCaseData("qqqqqqqqqqqqqqqqq111111111111111");
                yield return new TestCaseData("");
                yield return new TestCaseData(".");
                yield return new TestCaseData("11111111");
                yield return new TestCaseData("aAAAaaaa");
            }
        }

        [Test, TestCaseSource("passwordStringChaked")]
        public Tuple<bool, string> VerifyPasswordTest(string password)
        {
            var repository = new SqlRepository();
            var verifyPassword = new PasswordCheckerService(repository);

            return verifyPassword.VerifyPassword(password);
        }

        [Test, TestCaseSource("passwordStringCustomChaked")]
        public Tuple<bool, string> VerifyPasswordCustomTest(string password)
        {
            var repository = new SqlRepository();
            var verifyPassword = new PasswordCheckerService(repository);
            verifyPassword.AddChecker(pswd => {
                if (pswd == "qwerty1234") return Tuple.Create(false, $"{password} is very easy. For amebs"); ;
                return Tuple.Create(true, "Password is Ok. User was created");
            });
            return verifyPassword.VerifyPassword(password);
        }


        [Test, TestCaseSource("SevingSuccessPasswordsInRepoMoq")]
        public void SevingSuccessPasswordsInRepoMoqTest(string password)
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(mr => mr.Create(It.IsAny<string>())).Callback(() => { Assert.Pass(); });
            var verifyPassword = new PasswordCheckerService(mockRepo.Object);
            verifyPassword.VerifyPassword(password);
            Assert.Fail();
        }

        [Test, TestCaseSource("SevingUnsuccessPasswordsInRepoMoq")]
        public void SevingUnsuccessPasswordsInRepoMoqTest(string password)
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(mr => mr.Create(It.IsAny<string>())).Callback(() => { Assert.Fail(); });
            var verifyPassword = new PasswordCheckerService(mockRepo.Object);
            verifyPassword.VerifyPassword(password);
            Assert.Pass();
        }
    }
}
