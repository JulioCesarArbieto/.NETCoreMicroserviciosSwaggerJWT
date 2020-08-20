using MediatR;

namespace CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
