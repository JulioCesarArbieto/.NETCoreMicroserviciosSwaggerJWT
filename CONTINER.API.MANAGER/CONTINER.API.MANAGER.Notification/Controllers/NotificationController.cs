using CONTINER.API.MANAGER.Notification.Service;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceMail _services;
        public NotificationController(IServiceMail services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }

        [HttpPost]
        public IActionResult Post()
        {
            _services.Add(new Model.SendMail()
            {
                AccountId = 100,
                SendDate = "02/02/2020"
            });
            return Ok();
        }
    }
}
