using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
         where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
