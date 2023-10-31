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
                                dbo.Condominio.nome,
                                nivel_relatorio
                            from dbo.Sindico
                            INNER JOIN dbo.Condominio on dbo.Sindico.condominio = dbo.Condominio.id
                            order by nome";

                var result = await conn.QueryAsync<Sindico>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
