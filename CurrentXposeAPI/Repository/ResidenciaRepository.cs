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
                                dbo.Residencia.andar,
                                dbo.Predio.id,
                                dbo.Predio.nome,
                                dbo.Predio.total_de_andares,
                                dbo.Condominio.nome
                            from dbo.Residencia
                            INNER JOIN dbo.Predio on dbo.Residencia.predio_id = dbo.Predio.id,
                            INNER JOIN dbo.Condominio on dbo.Predio.condominio_id = dbo.Condominio.id
                            order by nome";

                var result = await conn.QueryAsync<Residencia>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
