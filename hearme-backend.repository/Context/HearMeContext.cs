using System;
using hearme_backend.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.repository
{
    public class HearMeContext : DbContext
    {
        public HearMeContext(DbContextOptions<HearMeContext> options) : base(options)
        {
        
        }

        public DbSet<ClientesDomain> Clientes {get; set;}
        public DbSet<UsuarioDomain> Usuarios {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ClientesDomain>().ToTable("Clientes");
            modelBuilder.Entity<UsuarioDomain>().ToTable("Usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}