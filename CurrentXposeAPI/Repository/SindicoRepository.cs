using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class SindicoRepository : BaseRepository<Sindico> , ISindicoRepository
    {
        public SindicoRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Sindico>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                dbo.Sindico.id,
                                dbo.Sindico.nome,
                                dbo.Sindico.login,
                                dbo.Sindico.senha,
                                dbo.Sindico.nivel_relatorio,
                                dbo.Sindico.condominio_id
                            from dbo.Sindico
                            order by nome";

                var result = await conn.QueryAsync<Sindico>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
        public async Task<Sindico> GetByLogin(string login)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                            dbo.Sindico.id,
                            dbo.Sindico.nome,
                            dbo.Sindico.login,
                            dbo.Sindico.senha,
                            dbo.Sindico.nivel_relatorio,
                            dbo.Sindico.condominio_id
                        from dbo.Sindico
                        where dbo.Sindico.login = @Login";
                var result = await conn.QueryFirstOrDefaultAsync<Sindico>(sql, new { Login = login });
                conn.Close();
                return result;
            }
        }
    }
}
