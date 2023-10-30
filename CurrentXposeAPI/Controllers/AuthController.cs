using CurrentXposeAPI.Segurança.Service;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "matheus" && password == "12345")
            {
                var token = _tokenService.GenerateToken(new Entidades.Morador());
                return Ok(token);
            }

            return BadRequest();
        }
    }
}
