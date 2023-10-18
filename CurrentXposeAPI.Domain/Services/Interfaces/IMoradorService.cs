using CurrentXpose.Domain.Entidades;

namespace CurrentXposeAPI.Services.Interfaces
{
    public interface IMoradorService
    {
        Task<IReadOnlyList<Morador>> ObterMoradores();
    }
}
