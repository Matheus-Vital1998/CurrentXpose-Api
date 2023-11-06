﻿using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Context;
using CurrentXposeAPI.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Repository
{
    public class PredioRepository : BaseRepository<Predio> , IPredioRepository
    {
        public PredioRepository(CurrentXposeAPIContext context) : base(context) { }

        public async Task<IReadOnlyList<Predio>> GetAll()
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();
                var sql = $@"select
                                dbo.Predio.id,
                                dbo.Predio.nome,
                                dbo.Predio.total_de_andares
                            from dbo.Predio
                            order by nome";

                var result = await conn.QueryAsync<Predio>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
