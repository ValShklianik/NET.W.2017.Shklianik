using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IObservable stock = new Stock();
            IObserver bank = new Bank("Bank 1", stock);
            IObserver broker = new Broker("Brokr 1", stock);
            ((Stock)stock).Market();
        }
    }
}
