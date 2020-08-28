using System;
using CONTINER.API.MANAGER.Cross.RabbitMQ.RabbitMQ.Bus;
using CONTINER.API.MANAGER.Deposit.DTO;
using CONTINER.API.MANAGER.Deposit.RabbitMQ.Commands;
using CONTINER.API.MANAGER.Deposit.Service;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.Deposit.Controllers
{
    /// <summary>
    /// Controller TransactionController define all accion in Transaction
    /// </summary>
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

        /// <summary>
        /// This method generate Transaction in diferent accounts
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     {
        ///       "IdAccount" : 1,
        ///       "Amount"    : 200.00
        ///     }
        ///     
        /// Sample response :
        /// 
        ///     Interface IActionResult
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
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
