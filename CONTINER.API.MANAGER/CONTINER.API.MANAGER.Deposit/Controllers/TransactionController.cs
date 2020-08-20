using System;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Deposit.DTO;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Deposit.Service;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.Deposit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceTransaction _services;
        private readonly IServiceAccount _servicesAccount;
        private readonly IEventBus _bus;
        public TransactionController(IServiceTransaction services, IEventBus bus, IServiceAccount servicesAccount)
        {
            _services = services;
            _bus = bus;
            _servicesAccount = servicesAccount;
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Deposit"
            };
            transaction = _services.Deposit(transaction);
            bool isProccess = _servicesAccount.Execute(transaction);
            if(isProccess)
            {
                _bus.SendCommand(new DepositCreateCommand(
                        idTransaction: transaction.Id,
                        amount: transaction.Amount,
                        type: transaction.Type,
                        creationDate: transaction.CreationDate,
                        accountId: transaction.AccountId
                ));

                _bus.SendCommand(new MailCreateCommand(
                            sendDate: transaction.CreationDate,
                            accountId: transaction.AccountId
                    ));
            }

            return Ok();
        }
    }
}
