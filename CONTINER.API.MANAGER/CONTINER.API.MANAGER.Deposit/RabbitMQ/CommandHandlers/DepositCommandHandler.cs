using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Deposit.RabbitMQ.CommandHandlers
{
    public class DepositCommandHandler : IRequestHandler<DepositCreateCommand, bool>
    {
        private readonly IEventBus _bus;
        public DepositCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(DepositCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new DepositCreatedEvent(
                request.IdTransaction,
                request.Amount,
                request.Type,
                request.CreationDate,
                request.AccountId
                ));
            return Task.FromResult(true);
        }
    }
}
