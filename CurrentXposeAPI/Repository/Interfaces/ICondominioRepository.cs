using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ICondominioRepository : IBaseRepository<Condominio>
    {
        Task<IReadOnlyList<Condominio>> GetAll();
    }
}
