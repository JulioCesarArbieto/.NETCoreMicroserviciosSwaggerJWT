using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.History.RabbitMQ.Events;
using CONTINER.API.MANAGER.History.Service;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.History.RabbitMQ.EventHandlers
{
    public class WithdrawalEventHandler : IEventHandler<WithdrawalCreatedEvent>
    {
        private readonly IServiceHistory _service;
        public WithdrawalEventHandler(IServiceHistory service)
        {
            _service = service;
        }

        public Task Handle(WithdrawalCreatedEvent @event)
        {
            _service.Add(new Model.HistoryTransaction()
            {
                IdTransaction = @event.IdTransaction,
                Amount = @event.Amount,
                Type = @event.Type,
                CreationDate = @event.CreationDate,
                AccountId = @event.AccountId
            });

            return Task.CompletedTask;
        }
    }
}
