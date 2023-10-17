using CurrentXpose.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CurrentXposeAPI.Context
{
    public class CurrentXposeAPIContext : DbContext
    {
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<Leitura> Leitura { get; set; }
        public virtual DbSet<Morador> Morador { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Residencia> Residencia { get; set; }
        public virtual DbSet<Sindico> Sindico { get; set; }

        public CurrentXposeAPIContext() { }

        public CurrentXposeAPIContext(DbContextOptions<CurrentXposeAPIContext> options) : base(options) { }
    }
}
