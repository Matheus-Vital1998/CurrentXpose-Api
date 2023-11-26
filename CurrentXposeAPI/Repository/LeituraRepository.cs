using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class LeituraRepository : BaseRepository<Leitura>, ILeituraRepository
    {
        public LeituraRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Leitura>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                dbo.Leitura.id,
                                dbo.Leitura.data_da_leitura,
                                dbo.Leitura.valor_da_leitura,
                                dbo.Leitura.residencia_id
                            from dbo.Leitura";

                var result = await conn.QueryAsync<Leitura>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Morador(string loginMorador, DateTime dataIncial, DateTime dataFinal)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"SELECT Valor, Data
                            FROM ObterLeiturasPorMorador_Morador(
                            @LoginMorador, @DataInicio, @DataFim
                            );";

                var result = await conn.QueryAsync<Leitura>(sql, new { LoginMorador = loginMorador, DataInicio = dataIncial, DataFim = dataFinal });
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<IReadOnlyList<Leitura>> ObterLeiturasPorMorador_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroResidencia, string nomePredio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"SELECT Valor, Data
                            FROM ObterLeiturasPorMorador_Sindico(
                            @LoginSindico, @DataInicio, @DataFim, @NumeroResidencia, @NomePredio
                            );";

                var result = await conn.QueryAsync<Leitura>(sql, new { LoginSindico = loginSindico, DataInicio = dataIncial, DataFim = dataFinal, NumeroResidencia  = numeroResidencia, NomePredio = nomePredio });
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<IReadOnlyList<Leitura>> ObterLeiturasPorAndar_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string numeroAndar, string nomePredio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"SELECT Valor, Data
                            FROM ObterLeiturasPorAndar_Sindico(
                            @LoginSindico, @DataInicio, @DataFim, @NumeroAndar, @NomePredio
                            );";

                var result = await conn.QueryAsync<Leitura>(sql, new { LoginSindico = loginSindico, DataInicio = dataIncial, DataFim = dataFinal, NumeroAndar = numeroAndar, NomePredio = nomePredio });
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<IReadOnlyList<Leitura>> ObterLeiturasPorPredio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal, string nomePredio)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"SELECT Valor, Data
                            FROM ObterLeiturasPorPredio_Sindico(
                            @LoginSindico, @DataInicio, @DataFim, @NomePredio
                            );";

                var result = await conn.QueryAsync<Leitura>(sql, new { LoginSindico = loginSindico, DataInicio = dataIncial, DataFim = dataFinal, NomePredio = nomePredio });
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<IReadOnlyList<Leitura>> ObterLeiturasPorCondominio_Sindico(string loginSindico, DateTime dataIncial, DateTime dataFinal)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"SELECT Valor, Data
                            FROM ObterLeiturasPorCondominio_Sindico(
                            @LoginSindico, @DataInicio, @DataFim
                            );";

                var result = await conn.QueryAsync<Leitura>(sql, new { LoginSindico = loginSindico, DataInicio = dataIncial, DataFim = dataFinal});
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

    }
}
