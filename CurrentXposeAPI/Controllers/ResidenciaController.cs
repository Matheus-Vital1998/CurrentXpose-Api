using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurrentXposeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResidenciaController : Controller
    {
        private readonly IResidenciaService _residenciaService;

        public ResidenciaController(IResidenciaService residenciaService)
        {
            _residenciaService = residenciaService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterResidencias")]
        public async Task<List<Residencia>> ObterResidencias()
        {
            var residencias = await _residenciaService.ObterResidencias();
            return residencias.ToList();
        }
    }
}
