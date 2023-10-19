using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CondominioController : Controller
    {
        private readonly ICondominioService _condominioService;

        public CondominioController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        [HttpGet("ObterCondominios")]
        public async Task<List<Condominio>> ObterCondominios()
        {
            var condominios = await _condominioService.ObterCondominios();
            return condominios.ToList();
        }
    }
}
