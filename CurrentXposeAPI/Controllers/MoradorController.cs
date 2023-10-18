using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoradorController : Controller
    {
        private readonly IMoradorService _moradorService;

        public MoradorController(IMoradorService moradorService)
        {
            _moradorService = moradorService;
        }

        [HttpGet("ObterMoradores")]
        public async Task<List<Morador>> ObterMoradores()
        {
            var moradores = await _moradorService.ObterMoradores();
            return moradores.ToList();
        }
    }
}
