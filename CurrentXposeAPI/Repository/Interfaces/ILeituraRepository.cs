using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ILeituraRepository : IBaseRepository<Leitura>
    {
        Task<IReadOnlyList<Leitura>> GetAll();
    }
}
