using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Segurança.Service;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IMoradorService _moradorService;
        private readonly ISindicoService _sindicoService;
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService, IMoradorService moradorService, ISindicoService sindicoService)
        {
            _tokenService = tokenService;
            _moradorService = moradorService;
            _sindicoService = sindicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string username, string password)
        {
            Morador morador = await _moradorService.Authenticate(username, password);
            if (morador != null)
            {
                var token = _tokenService.GenerateToken(morador);
                return Ok(token);
            }

            Sindico sindico = await _sindicoService.Authenticate(username, password);
            if (sindico != null)
            {
                var token = _tokenService.GenerateToken(sindico);
                return Ok(token);
            }

            return BadRequest();
        }
    }
}