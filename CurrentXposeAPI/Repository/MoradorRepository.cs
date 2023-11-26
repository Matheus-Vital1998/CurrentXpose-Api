using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class MoradorRepository : BaseRepository<Morador>, IMoradorRepository
    {
        public MoradorRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Morador>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                dbo.Morador.id,
                                dbo.Morador.nome,
                                dbo.Morador.login,
                                dbo.Morador.senha,
                                dbo.Morador.residencia_id,
                                dbo.Morador.pergunta,
                                dbo.Morador.resposta
                            from dbo.Morador
                            order by nome";
                var result = await conn.QueryAsync<Morador>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }

        public async Task<Morador> GetByLogin(string login)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                            dbo.Morador.id,
                            dbo.Morador.nome,
                            dbo.Morador.login,
                            dbo.Morador.senha,
                            dbo.Morador.residencia_id,
                            dbo.Morador.pergunta,
                            dbo.Morador.resposta
                        from dbo.Morador
                        where dbo.Morador.login = @Login";
                var result = await conn.QueryFirstOrDefaultAsync<Morador>(sql, new { Login = login });
                conn.Close();
                return result;
            }
        }
    }
}
