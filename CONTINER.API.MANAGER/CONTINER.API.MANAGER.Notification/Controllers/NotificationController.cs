using CONTINER.API.MANAGER.Notification.Service;
using Microsoft.AspNetCore.Mvc;

namespace CONTINER.API.MANAGER.Notification.Controllers
{
    /// <summary>
    /// Controlador designado a Funciones de Notificacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IServiceMail _services;
        public NotificationController(IServiceMail services)
        {
            _services = services;
        }
        /// <summary>
        /// Metodo que lista todo las notificaciones existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }
        /// <summary>
        /// Metodo agrega nueva notificacion
        /// </summary>
        /// <returns></returns>
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
