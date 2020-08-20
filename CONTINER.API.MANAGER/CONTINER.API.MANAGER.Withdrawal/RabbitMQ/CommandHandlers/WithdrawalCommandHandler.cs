using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Withdrawal.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Withdrawal.RabbitMQ.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Withdrawal.RabbitMQ.CommandHandlers
{
    public class WithdrawalCommandHandler : IRequestHandler<WithdrawalCreateCommand, bool>
    {
        private readonly IEventBus _bus;
        public WithdrawalCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(WithdrawalCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new WithdrawalCreatedEvent(
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
