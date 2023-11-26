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
    public class LeituraController : Controller
    {
        private readonly ILeituraService _leituraService;

        public LeituraController(ILeituraService leituraService)
        {
            _leituraService = leituraService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterDadosDeLeitura")]
        public async Task<List<Leitura>> ObterDadosDeLeitura()
        {
            var leitura = await _leituraService.ObterDadosDeLeitura();
            return leitura.ToList();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterLeiturasPorMorador_Morador")]
        public async Task<List<Leitura>> ObterLeiturasPorMorador_Morador(string loginMorador, DateTime dataIncial, DateTime dataFinal)
        {
            var leitura = await _leituraService.ObterLeiturasPorMorador_Morador(loginMorador, dataIncial, dataFinal);
            return leitura.ToList();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterLeiturasPorMorador_Morador")]
        public async Task<List<Leitura>> ObterLeiturasPorMorador_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroResidencia, string nomePredio)
        {
            var leitura = await _leituraService.ObterLeiturasPorMorador_Sindico(loginSindico, dataIncial, dataFinal, numeroResidencia, nomePredio);
            return leitura.ToList();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterLeiturasPorMorador_Morador")]
        public async Task<List<Leitura>> ObterLeiturasPorAndar_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroAndar, string nomePredio)
        {
            var leitura = await _leituraService.ObterLeiturasPorAndar_Sindico(loginSindico, dataIncial, dataFinal, numeroAndar, nomePredio);
            return leitura.ToList();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterLeiturasPorMorador_Morador")]
        public async Task<List<Leitura>> ObterLeiturasPorPredio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string nomePredio)
        {
            var leitura = await _leituraService.ObterLeiturasPorPredio_Sindico(loginSindico, dataIncial, dataFinal, nomePredio);
            return leitura.ToList();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ObterLeiturasPorMorador_Morador")]
        public async Task<List<Leitura>> ObterLeiturasPorCondominio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal)
        {
            var leitura = await _leituraService.ObterLeiturasPorCondominio_Sindico(loginSindico, dataIncial, dataFinal);
            return leitura.ToList();
        }
    }
}
