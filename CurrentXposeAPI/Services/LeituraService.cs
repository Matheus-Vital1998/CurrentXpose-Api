using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Repository.Interfaces;
using CurrentXposeAPI.Services.Interfaces;

namespace CurrentXposeAPI.Services
{
    public class LeituraService : ILeituraService
    {
        private readonly ILeituraRepository _leituraRepository;

        public LeituraService(ILeituraRepository leituraRepository)
        {
            _leituraRepository = leituraRepository;
        }

        public Task<IReadOnlyList<Leitura>> ObterDadosDeLeitura()
        {
            return _leituraRepository.GetAll();
        }

        public Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Morador(string loginMorador, DateTime dataIncial, DateTime dataFinal)
        {
            return _leituraRepository.ObterLeiturasPorMorador_Morador(loginMorador, dataIncial, dataFinal);
        }

        public Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroResidencia, string nomePredio)
        {
            return _leituraRepository.ObterLeiturasPorMorador_Sindico(loginSindico, dataIncial, dataFinal, numeroResidencia, nomePredio);
        }

        public Task<IReadOnlyList<Leitura>> ObterLeiturasPorAndar_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroAndar, string nomePredio)
        {
            return _leituraRepository.ObterLeiturasPorAndar_Sindico(loginSindico, dataIncial, dataFinal, numeroAndar, nomePredio);
        }

        public Task<IReadOnlyList<Leitura>> ObterLeiturasPorPredio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string nomePredio)
        {
            return _leituraRepository.ObterLeiturasPorPredio_Sindico(loginSindico, dataIncial, dataFinal, nomePredio);
        }

        public Task<IReadOnlyList<Leitura>> ObterLeiturasPorCondominio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal)
        {
            return _leituraRepository.ObterLeiturasPorCondominio_Sindico(loginSindico, dataIncial, dataFinal);
        }
    }
}
