using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.CommandHandlers
{
    public class MailCommandHandler : IRequestHandler<MailCreateCommand, bool>
    {
        private readonly IEventBus _bus;
        public MailCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }
        public Task<bool> Handle(MailCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new MailCreatedEvent(
                request.SendDate,
                request.AccountId
                ));
            return Task.FromResult(true);
        }
    }
}
