using hearme_backend.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.repository.Context
{
    public class HearMeContext : DbContext
    {
        public HearMeContext(DbContextOptions<HearMeContext> options) : base(options)
        {
        
        }

        public DbSet<ClientesDomain> Clientes {get; set;}
        public DbSet<GeneroDomain> Generos {get; set;}
        public DbSet<GrauDeficienciaDomain> GrausDeficiencias {get; set;}
        public DbSet<UsuarioDomain> Usuarios {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ClientesDomain>().ToTable("Clientes");
            modelBuilder.Entity<GeneroDomain>().ToTable("Generos");
            modelBuilder.Entity<GrauDeficienciaDomain>().ToTable("GrausDeficiencias");
            modelBuilder.Entity<UsuarioDomain>().ToTable("Usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}