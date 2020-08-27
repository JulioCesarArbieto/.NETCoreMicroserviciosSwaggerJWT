using CONTINER.API.MANAGER.Account.DTO;
using CONTINER.API.MANAGER.Account.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CONTINER.API.MANAGER.Account.Controllers
{
    /// <summary>
    /// Controlador de Cuentas denominado AccountController
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceAccount _services;
        public AccountController(IServiceAccount services)
        {
            _services = services;
        }

        /// <summary>
        /// This method get all Acounts registre
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }

        /// <summary>
        /// This method generate a Deposit in diferent account
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
        /// <returns>IActionResult</returns>
        [Authorize]
        [HttpPost("Deposit")]
        public IActionResult Deposit([FromBody] AccountRequest request)
        {
            var result = _services.GetAll().FirstOrDefault(x => x.IdAccount == request.IdAccount);
            //.FirstOrDefault();
            Model.Account account = new Model.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount + request.Amount,
                Customer = result.Customer
            };
            _services.Deposit(account);
            return Ok();
        }
        /// <summary>
        /// This method generate a Withdrawal in diferent Account
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
        /// Sample response:
        /// 
        ///     Interface IActionResult
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>IActionResult</returns>
        [Authorize]
        [HttpPost("Withdrawal/")]
        public IActionResult Withdrawal([FromBody] AccountRequest request)
        {
            var result = _services.GetAll().Where(x => x.IdAccount == request.IdAccount)
                .FirstOrDefault();
            Model.Account account = new Model.Account()
            {
                IdAccount = request.IdAccount,
                IdCustomer = result.IdCustomer,
                TotalAmount = result.TotalAmount - request.Amount,
                Customer = result.Customer
            };
            _services.Withdrawal(account);
            return Ok();
        }

    }
}
