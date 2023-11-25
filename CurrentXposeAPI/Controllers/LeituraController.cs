using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Services;
using CurrentXposeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    }
}
