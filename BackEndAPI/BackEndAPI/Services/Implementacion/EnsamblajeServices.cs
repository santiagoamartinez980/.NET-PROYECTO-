using BackEndAPI.Data;
using BackEndAPI.DTOs.Ensamblaje;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
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

        public async Task<Ensamblaje> CrearEnsamblaje(CrearEnsamblajeDto dto)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(dto.UsuarioId);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            var ensamblaje = new Ensamblaje
            {
                UsuarioId = dto.UsuarioId,
                ProcesadorId = dto.ProcesadorId,
                PlacaBaseId = dto.PlacaBaseId,
                MemoriaRamId = dto.MemoriaRamId,
                TarjetaGraficaId = dto.TarjetaGraficaId,
                AlmacenamientoId = dto.AlmacenamientoId,
                FuentePoderId = dto.FuentePoderId
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

        public Task<Ensamblaje> CrearEnsamblaje(int usuarioId, List<int> componentesIds)
        {
            throw new NotImplementedException();
        }
    }
}
