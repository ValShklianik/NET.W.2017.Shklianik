using ClockLogic.Events;

namespace ClockLogic.Clocks
{
    interface IClock
    {
        IEvent CreateEvent(int time, string eventMessage);
    }
}
