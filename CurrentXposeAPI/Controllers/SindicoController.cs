using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    public class SindicoController : Controller
    {
        private readonly ISindicoService _sindicoService;

        public SindicoController(ISindicoService sindicoService)
        {
            _sindicoService = sindicoService;
        }

        [HttpGet("ObterSindico")]
        public async Task<List<Sindico>> ObterSindico()
        {
            var sindico = await _sindicoService.ObterSindico();
            return sindico.ToList();
        }
    }
}
