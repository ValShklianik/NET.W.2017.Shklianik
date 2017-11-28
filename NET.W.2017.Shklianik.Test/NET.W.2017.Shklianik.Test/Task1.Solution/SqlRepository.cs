using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class SqlRepository : IRepository
    {
        public void Create(string password)
        {
            Console.WriteLine($"Repository added, password : {password}");
        }
    }
}
