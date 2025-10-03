using BackEndAPI.Data;
using BackEndAPI.Models;
using BackEndAPI.Services.Contrato.EnsamblajeService;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class EnsamblajeServices : IEnsamblaje
    {
        private readonly AppDbContext _dbContext;

        public EnsamblajeServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ensamblaje> CrearEnsamblaje(int usuarioId, List<int> componentesIds)
        {
            // Buscar usuario
            var usuario = await _dbContext.Usuarios.FindAsync(usuarioId);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            // Buscar componentes
            var componentes = await _dbContext.Componentes
                                              .Where(c => componentesIds.Contains(c.Id))
                                              .ToListAsync();

            if (componentes == null || componentes.Count == 0)
                throw new Exception("No se encontraron componentes válidos");

            // Crear ensamblaje
            var ensamblaje = new Ensamblaje
            {
                UsuarioId = usuarioId,
                Usuario = usuario,
                Componentes = componentes
            };

            _dbContext.Ensamblajes.Add(ensamblaje);
            await _dbContext.SaveChangesAsync();

            return ensamblaje;
        }

        public async Task<Ensamblaje?> ObtenerEnsamblajePorId(int id)
        {
            return await _dbContext.Ensamblajes
                .Include(e => e.Usuario)
                .Include(e => e.Procesador)
                .Include(e => e.PlacaBase)
                .Include(e => e.MemoriaRAM)
                .Include(e => e.TarjetaGrafica)
                .Include(e => e.Almacenamiento)
                .Include(e => e.FuentePoder)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Ensamblaje>> ObtenerEnsamblajesPorUsuario(int usuarioId)
        {
            return await _dbContext.Ensamblajes
                .Include(e => e.Procesador)
                .Include(e => e.PlacaBase)
                .Include(e => e.MemoriaRAM)
                .Include(e => e.TarjetaGrafica)
                .Include(e => e.Almacenamiento)
                .Include(e => e.FuentePoder)
                .Where(e => e.UsuarioId == usuarioId)
                .ToListAsync();
        }



        public async Task<bool> EliminarEnsamblaje(int id)
        {
            var ensamblaje = await _dbContext.Ensamblajes.FindAsync(id);
            if (ensamblaje == null)
                return false;

            _dbContext.Ensamblajes.Remove(ensamblaje);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Ensamblaje> ActualizarEnsamblaje(Ensamblaje modelo)
        {
            _dbContext.Ensamblajes.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
