namespace ClockLogic.Events
{
    public delegate void Handler(int time, string eventMessage);

    public class Event : IEvent
    {
        private int time;
        private string eventMessage;

        public Event(int time, string eventMessage)
        {
            this.time = time;
            this.eventMessage = eventMessage;
        }

        private event Handler Happen;

        public void AddSubscriber(Handler subscriber)
        {
            Happen += subscriber;
        }

        public void RemoveSubscriber(Handler subscriber)
        {
            Happen -= subscriber;
        }

        public void PerformEvent()
        {
            Happen(time, eventMessage);
        }

    }
}
