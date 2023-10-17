using CurrentXpose.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("LoginMorador")]
        public IActionResult Login(string login, string senha)
        {
            if (ViewBag.login != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
