using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using Microsoft.EntityFrameworkCore;

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

            //todos los componentes en una tabla
            modelBuilder.Entity<Componente>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Procesador>("Procesador")
                .HasValue<PlacaBase>("PlacaBase")
                .HasValue<MemoriaRAM>("MemoriaRAM")
                .HasValue<TarjetaGrafica>("TarjetaGrafica")
                .HasValue<Almacenamiento>("Almacenamiento")
                .HasValue<FuentePoder>("FuentePoder");

            //Usuario único por correo y documento
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Documento)
                .IsUnique();

            //Relación Usuario -> Ensamblajes
            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Ensamblajes)
                .HasForeignKey(e => e.UsuarioId);

            //Relación Ensamblaje -> Procesador
            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.Procesador)
                .WithMany()
                .HasForeignKey(e => e.ProcesadorId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relación Ensamblaje -> PlacaBase
            modelBuilder.Entity<Ensamblaje>()
                .HasOne(e => e.PlacaBase)
                .WithMany()
                .HasForeignKey(e => e.PlacaBaseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
