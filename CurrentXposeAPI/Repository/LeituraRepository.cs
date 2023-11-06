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
                                dbo.Leitura.valor_da_leitura
                            from dbo.Leitura";

                var result = await conn.QueryAsync<Leitura>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
