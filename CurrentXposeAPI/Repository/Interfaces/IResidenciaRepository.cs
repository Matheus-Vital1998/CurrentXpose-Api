using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface IResidenciaRepository : IBaseRepository<Residencia>
    {
        Task<IReadOnlyList<Residencia>> GetAll();
    }
}
