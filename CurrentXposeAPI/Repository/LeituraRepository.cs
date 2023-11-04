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
                                id,
                                data_da_leitura,
                                valor_da_leitura,
                                dbo.Residencia.numero,
                                dbo.Residencia.andar
                            from dbo.Leitura
                            INNER JOIN dbo.Residencia on Leitura.residencia_id = Residencia.Id";

                var result = await conn.QueryAsync<Leitura>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
