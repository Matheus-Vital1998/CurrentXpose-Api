using CurrentXpose.Domain.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class CondominioRepository : BaseRepository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Condominio>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                id,
                                nome 
                            from dbo.Condominio
                            order by nome";

                var result = await conn.QueryAsync<Condominio>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
