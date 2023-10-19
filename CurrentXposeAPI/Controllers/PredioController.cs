using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    public class PredioController : Controller
    {
        private readonly IPredioService _predioService;

        public PredioController(IPredioService predioService)
        {
            _predioService = predioService;
        }

        [HttpGet("ObterPredios")]
        public async Task<List<Predio>> ObterPredios()
        {
            var predios = await _predioService.ObterPredios();
            return predios.ToList();
        }
    }
}
