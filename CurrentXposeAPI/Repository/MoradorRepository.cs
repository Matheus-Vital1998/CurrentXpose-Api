﻿using CurrentXposeAPI.Entidades;
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
                                dbo.Residencia.numero,
                                dbo.Residencia.andar
                            from dbo.Morador
                            INNER JOIN dbo.Residencia on Morador.residencia = Residencia.Id
                            order by nome";
                var result = await conn.QueryAsync<Morador>(sql);
                conn.Close();
                return result.ToList().AsReadOnly();
            }
        }
    }
}
