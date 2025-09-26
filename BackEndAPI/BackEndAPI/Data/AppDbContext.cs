using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BackEndAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<Ensamblaje> Ensamblajes { get; set; }

        //aqui el model para la personalizacion de las migraciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar herencia TPH
            modelBuilder.Entity<Componente>()
            .HasDiscriminator<string>("Discriminator");

            // Evitar múltiples cascadas en Ensamblajes
            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.Procesador)
                .WithMany()
                .HasForeignKey(e => e.ProcesadorId)
                .OnDelete(DeleteBehavior.Restrict); // 👈 Importante

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.PlacaBase)
                .WithMany()
                .HasForeignKey(e => e.PlacaBaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.MemoriaRAM)
                .WithMany()
                .HasForeignKey(e => e.MemoriaRamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.TarjetaGrafica)
                .WithMany()
                .HasForeignKey(e => e.TarjetaGraficaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.Almacenamiento)
                .WithMany()
                .HasForeignKey(e => e.AlmacenamientoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.FuentePoder)
                .WithMany()
                .HasForeignKey(e => e.FuentePoderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Ensamblajes)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
