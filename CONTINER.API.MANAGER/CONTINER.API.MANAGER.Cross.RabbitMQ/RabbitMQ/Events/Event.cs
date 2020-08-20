using System;

namespace CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
