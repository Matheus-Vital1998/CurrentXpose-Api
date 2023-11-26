using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class MoradorService : IMoradorService
    {
        private readonly IMoradorRepository _moradorRepository;
        public MoradorService(IMoradorRepository moradorRepository)
        {
            _moradorRepository = moradorRepository;
        }
        public Task<IReadOnlyList<Morador>> ObterMoradores()
        {
            return _moradorRepository.GetAll();
        }

        public async Task<Morador> Authenticate(string username, string password)
        {

            Morador morador = await _moradorRepository.GetByLogin(username);

            if (morador != null && morador.senha == password)
            {
                return morador;
            }
            return null;
        }
    }
}
