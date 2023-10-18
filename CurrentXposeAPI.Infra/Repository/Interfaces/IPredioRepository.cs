using CurrentXpose.Domain.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface IPredioRepository : IBaseRepository<Predio>
    {
        Task<IReadOnlyList<Predio>> GetAll();
    }
}
