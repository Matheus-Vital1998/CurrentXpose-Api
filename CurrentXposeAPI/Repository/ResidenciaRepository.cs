using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class ResidenciaRepository : BaseRepository<Residencia>, IResidenciaRepository
    {
        public ResidenciaRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Residencia>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                dbo.Residencia.id,
                                dbo.Residencia.numero,
                                dbo.Residencia.andar
                            from dbo.Residencia";

                var result = await conn.QueryAsync<Residencia>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
