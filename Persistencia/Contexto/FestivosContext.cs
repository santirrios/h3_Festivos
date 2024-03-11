using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Contexto
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options)
            : base(options)
        { }


        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Festivo>()
                .HasOne(e => e.Tipo)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);

        }
    }
}
