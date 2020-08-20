using CONTINER.API.MANAGER.Cross.Jwt;
using CONTINER.API.MANAGER.Cross.Jwt.Jwt;
using CONTINER.API.MANAGER.Security.DTO;
using CONTINER.API.MANAGER.Security.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CONTINER.API.MANAGER.Security.Controllers
{
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAll());
        }

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
