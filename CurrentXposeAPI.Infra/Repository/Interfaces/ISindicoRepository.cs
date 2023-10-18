using CurrentXpose.Domain.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ISindicoRepository : IBaseRepository<Sindico>
    {
        Task<IReadOnlyList<Sindico>> GetAll();
    }
}
