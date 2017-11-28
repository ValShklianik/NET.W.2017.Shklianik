using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Solution
{
    public class Stock : IObservable
    {
        private StockInfo stocksInfo;
        public delegate void StockChangeHandler(object observeble);
        public event StockChangeHandler Handlers;

        public Stock()
        {
            stocksInfo = new StockInfo();
        }

        public void Register(IObserver observer) => Handlers += observer.Update;

        public void Unregister(IObserver observer) => Handlers -= observer.Update;

        public void Notify()
        {
            Handlers(stocksInfo);
        }

        public void Market()
        {
            Random rnd = new Random();
            stocksInfo.USD = rnd.Next(20, 40);
            stocksInfo.Euro = rnd.Next(30, 50);
            Notify();
        }
    }
}
