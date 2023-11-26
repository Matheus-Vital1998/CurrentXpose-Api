using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface ISindicoService
    {
        Task<IReadOnlyList<Sindico>> ObterSindico();
        Task<Sindico> Authenticate(string username, string password);
    }
}
