using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class SindicoService : ISindicoService
    {
        private readonly ISindicoRepository _sindicoRepository;
        public SindicoService(ISindicoRepository sindicoRepository)
        {
            _sindicoRepository = sindicoRepository;
        }
        public Task<IReadOnlyList<Sindico>> ObterSindico()
        {
            return _sindicoRepository.GetAll();
        }

        public async Task<Sindico> Authenticate(string username, string password)
        {

            Sindico sindico = await _sindicoRepository.GetByLogin(username);

            if (sindico != null && sindico.senha == password)
            {
                return sindico;
            }
            return null;
        }
    }
}
