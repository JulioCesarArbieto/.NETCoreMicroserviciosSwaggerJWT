using System;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Withdrawal.DTO;
using CONTINER.API.MANAGER.Withdrawal.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Withdrawal.Service;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.Withdrawal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceTransaction _services;
        private readonly IEventBus _bus;
        private readonly IServiceAccount _servicesAccount;
        public TransactionController(IServiceTransaction services, IEventBus bus, IServiceAccount servicesAccount)
        {
            _services = services;
            _bus = bus;
            _servicesAccount = servicesAccount;
        }


        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal([FromBody] TransactionRequest request)
        {
            Model.Transaction transaction = new Model.Transaction()
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CreationDate = DateTime.Now.ToShortDateString(),
                Type = "Withdrawal"
            };
            transaction = _services.Withdrawal(transaction);

            var isProccess = _servicesAccount.Execute(transaction);
            if(isProccess)
            {
                _bus.SendCommand(new WithdrawalCreateCommand(
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
