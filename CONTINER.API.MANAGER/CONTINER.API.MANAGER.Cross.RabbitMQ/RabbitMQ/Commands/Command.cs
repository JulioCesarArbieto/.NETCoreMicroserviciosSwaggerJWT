using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events;
using System;

namespace CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
