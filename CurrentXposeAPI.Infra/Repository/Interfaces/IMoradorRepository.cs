using CurrentXpose.Domain.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface IMoradorRepository : IBaseRepository<Morador>
    {
        Task<IReadOnlyList<Morador>> GetAll();
    }
}
