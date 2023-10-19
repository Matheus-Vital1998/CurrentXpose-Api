using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    public class LeituraController : Controller
    {
        private readonly ILeituraService _leituraService;

        public LeituraController(ILeituraService leituraService)
        {
            _leituraService = leituraService;
        }

        [HttpGet("ObterDadosDeLeitura")]
        public async Task<List<Leitura>> ObterDadosDeLeitura()
        {
            var leitura = await _leituraService.ObterDadosDeLeitura();
            return leitura.ToList();
        }
    }
}
