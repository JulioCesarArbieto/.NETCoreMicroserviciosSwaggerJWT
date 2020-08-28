using CONTINER.API.MANAGER.Cross.Jwt;
using CONTINER.API.MANAGER.Cross.Jwt.Jwt;
using CONTINER.API.MANAGER.Security.DTO;
using CONTINER.API.MANAGER.Security.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CONTINER.API.MANAGER.Security.Controllers
{
    /// <summary>
    /// Controlador de Autentificacion y creacion de JWT
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAccess _services;
        private readonly JwtOptions _jwtOption;

        public AuthController(IServiceAccess services, IOptionsSnapshot<JwtOptions> jwtOption)
        {
            _services = services;
            _jwtOption = jwtOption.Value;
        }

        /// <summary>
        /// metodo que lista todo los usuarios que tienen acceso a la aplicacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }

        /// <summary>
        /// Metodo encargado de crear un JWT para poder realizar las pruebas
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///     {
        ///         "Username": julioarbieto,
        ///         "Password": julioCode@
        ///     }
        ///     
        /// Sample response :
        /// 
        ///     IActionResult
        /// 
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {

            if(!_services.Validate(request.Username, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));

            return Ok();
        }
    }
}
