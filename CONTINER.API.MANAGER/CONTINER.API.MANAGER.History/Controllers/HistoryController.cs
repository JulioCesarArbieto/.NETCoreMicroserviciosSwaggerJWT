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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _services.GetAll());
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] HistoryTransaction request)
        {
            await _services.Add(request);
            return Ok();
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> Get(int accountId)
        {
            var result = await _services.GetAll();
            return Ok(result.Where(x => x.AccountId == accountId).ToList());
        }
    }
}
