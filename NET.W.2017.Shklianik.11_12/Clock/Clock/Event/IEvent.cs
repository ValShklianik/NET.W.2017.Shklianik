﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLogic.Events
{
    public interface IEvent
    {
        void AddSubscriber(Handler subscriber);

        void RemoveSubscriber(Handler subscriber);

        void PerformEvent();
    }

}
