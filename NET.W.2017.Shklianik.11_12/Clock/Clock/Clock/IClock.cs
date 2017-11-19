using Clock.Events;

namespace Clock.Clock
{
    interface IClock
    {
        IEvent CreateEvent(int time, string eventMessage);
    }
}
