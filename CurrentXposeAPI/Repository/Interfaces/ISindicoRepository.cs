using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
        Task<Sindico> GetByLogin(string login);
    }
}
