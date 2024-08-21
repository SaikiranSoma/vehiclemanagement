using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IJwtTokenManager _jwtTokenManager;

        public AuthController(IJwtTokenManager jwtTokenManager)
        {
            _jwtTokenManager = jwtTokenManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
         public IActionResult Login([FromBody] UserCrediantials userCrediantials)
        {
           
            if (userCrediantials.username=="admin"&& userCrediantials.password=="password")
            {
                var token = _jwtTokenManager.Authenticate(userCrediantials.username, userCrediantials.password);
                return Ok(token);
            }
           
            return Unauthorized();
        }
       
        
    }
}
