using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution.Tests
{
    [TestFixture]
    public class TestPasswordCheckerService
    {
        public static IEnumerable passwordStringChaked
        {
            get
            {
                yield return new TestCaseData("qwert1236").Returns(Tuple.Create(true, "Password is Ok. User was created"));
                yield return new TestCaseData("1").Returns(Tuple.Create(false, $"1 length too short"));
                yield return new TestCaseData("qqqqqqqqqqqqqqqqq111111111111111").Returns(Tuple.Create(false, "qqqqqqqqqqqqqqqqq111111111111111 length too long"));
                yield return new TestCaseData("").Returns(Tuple.Create(false, $"password is empty "));
                yield return new TestCaseData("11111111").Returns(Tuple.Create(false, "11111111 hasn't alphanumerical chars"));
                yield return new TestCaseData("aaaaaaaa").Returns(Tuple.Create(false, "aaaaaaaa hasn't digits"));


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

    }
}
