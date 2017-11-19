using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockLogic.Clocks;
using ClockLogic.Events;

namespace ClockLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            IClock clock = new Clock();
            IEvent event1 = clock.CreateEvent(3000, "event1 for happy");
            IEvent event2 = clock.CreateEvent(1500, "event2 for fanny");

            Kek kek = new Kek();
            Kek kek2 = new Kek();
            event1.AddSubscriber(kek.KekMethodForSubscription);
            event2.AddSubscriber(kek2.KekMethodForSubscription);
            event2.AddSubscriber(kek.KekMethodForSubscription);

            Console.Read();

        }
    }

    public class Kek
    {
        public void KekMethodForSubscription(int time, string evtMessage)
        {
            Console.WriteLine(evtMessage);
        }
    }
}
