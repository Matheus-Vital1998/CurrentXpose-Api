using CurrentXposeAPI.Entidades;

namespace CurrentXposeAPI.Repository.Interfaces
{
    public interface ILeituraRepository : IBaseRepository<Leitura>
    {
        Task<IReadOnlyList<Leitura>> GetAll();

        Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Morador(string loginMorador, DateTime dataIncial, DateTime dataFinal);

        Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroResidencia, string nomePredio);

        Task<IReadOnlyList<Leitura>> ObterLeiturasPorAndar_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroAndar, string nomePredio);

        Task<IReadOnlyList<Leitura>> ObterLeiturasPorPredio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string nomePredio);

        Task<IReadOnlyList<Leitura>> ObterLeiturasPorCondominio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal);
    }
}
