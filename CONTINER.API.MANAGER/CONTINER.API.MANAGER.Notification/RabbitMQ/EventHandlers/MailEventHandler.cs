using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Notification.RabbitMQ.Events;
using CONTINER.API.MANAGER.Notification.Service;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Notification.RabbitMQ.EventHandlers
{
    public class MailEventHandler : IEventHandler<MailCreatedEvent>
    {

        private readonly IServiceMail _service;
        public MailEventHandler(IServiceMail service)
        {
            _service = service;
        }

        public Task Handle(MailCreatedEvent @event)
        {
            _service.Add(new Model.SendMail()
            {
                SendDate = @event.SendDate,
                AccountId = @event.AccountId
            });

            return Task.CompletedTask;
        }
    }
}
