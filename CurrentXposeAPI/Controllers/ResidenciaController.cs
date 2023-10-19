using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    public class ResidenciaController : Controller
    {
        private readonly IResidenciaService _residenciaService;

        public ResidenciaController(IResidenciaService residenciaService)
        {
            _residenciaService = residenciaService;
        }

        [HttpGet("ObterResidencias")]
        public async Task<List<Residencia>> ObterResidencias()
        {
            var residencias = await _residenciaService.ObterResidencias();
            return residencias.ToList();
        }
    }
}
