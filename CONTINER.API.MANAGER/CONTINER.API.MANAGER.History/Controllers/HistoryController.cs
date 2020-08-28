using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CONTINER.API.MANAGER.History.Model;
using CONTINER.API.MANAGER.History.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.History.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IServiceHistory _services;
        public HistoryController(IServiceHistory services)
        {
            _services = services;
        }
        /// <summary>
        /// This method - get all history transactions 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _services.GetAll());
        }

        /// <summary>
        /// This method insert history transactions 
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     {
        ///         "Id": 1,
        ///         "IdTransaction": 1,
        ///         "Amount": 200.10,
        ///         "Type": "Deposit or withdrawal",
        ///         "CreationDate": "dd/mm/yyyy hh:mm:ss",
        ///         "AccountId": 1
        ///     }
        ///     
        /// Sample response :
        /// 
        ///     Task IActionResult
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] HistoryTransaction request)
        {
            await _services.Add(request);
            return Ok();
        }
        /// <summary>
        /// This method call serveice - get acount for Id Account
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///    GET api/History/{accountId}
        ///     
        /// Sample response :
        /// 
        ///     Task IActionResult
        /// 
        /// </remarks>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            var result = await _services.GetAll();
            return Ok(result.Where(x => x.AccountId == accountId).ToList());
        }
    }
}
