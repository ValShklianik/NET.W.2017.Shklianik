using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var repository = new SqlRepository();
            var password = "qwerty1234";

            var verifyPassword = new PasswordCheckerService(repository);

            verifyPassword.VerifyPassword(password);

            verifyPassword.AddChecker(pswd => {
                if (pswd == "qwerty1234") return Tuple.Create(false, $"{password} is very easy. For amebs"); ;
                return Tuple.Create(true, "Password is Ok. User was created");
            });

            var result = verifyPassword.VerifyPassword(password);
            System.Console.WriteLine(result);

        }
    }
}
