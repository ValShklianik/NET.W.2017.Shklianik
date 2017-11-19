using System;
using System.Threading;
using Clock.Events;

namespace Clock.Clock 
{
    class Clock : IClock
    {
        delegate void PerformEvent(int time, IEvent evt);

        public IEvent CreateEvent(int time, string eventMessage)
        {
            IEvent newEvent = new Event(time, eventMessage);
            PerformEvent evt = DelegateThread;

            IAsyncResult ar = evt.BeginInvoke(time, newEvent, null, null);
            //evt.EndInvoke(ar);

            return newEvent;
        }

        private void DelegateThread(int time, IEvent evt)
        {
            Thread.Sleep(time);
            evt.PerformEvent();
            
        }
    }
}
    