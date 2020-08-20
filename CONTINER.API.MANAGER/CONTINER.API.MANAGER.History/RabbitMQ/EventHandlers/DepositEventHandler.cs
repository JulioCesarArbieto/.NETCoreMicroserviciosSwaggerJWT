using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.History.RabbitMQ.Events;
using CONTINER.API.MANAGER.History.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.History.RabbitMQ.EventHandlers
{
    public class DepositEventHandler : IEventHandler<DepositCreatedEvent>
    {

        private readonly IServiceHistory _service;
        public DepositEventHandler(IServiceHistory service)
        {
            _service = service;
        }

        public Task Handle(DepositCreatedEvent @event)
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
