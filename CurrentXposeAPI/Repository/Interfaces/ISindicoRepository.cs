using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
    }
}
