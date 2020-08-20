using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Events;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
