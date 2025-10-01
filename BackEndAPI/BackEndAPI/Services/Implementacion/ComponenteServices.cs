using BackEndAPI.Data;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using BackEndAPI.Services.Contrato.Componentes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Services.Implementacion
{
    public class ComponenteServices : IComponentesCompleto
    {
        private readonly AppDbContext _context;

        public ComponenteServices(AppDbContext context)
        {
            _context = context;
        }
        //Aqui van la logica del ensabalaje
        public async Task<List<Procesador>> GetProcesadores()
        {
            return await _context.Set<Procesador>().ToListAsync();
        }

        public async Task<List<PlacaBase>> GetPlacasCompatibles(int procesadorId)
        {
            var procesador = await _context.Set<Procesador>().FindAsync(procesadorId);
            if (procesador == null) return new List<PlacaBase>();
            return await _context.Set<PlacaBase>()
                .Where(p => p.Socket == procesador.Socket)
                .ToListAsync();
        }

        public async Task<List<MemoriaRAM>> GetMemoriasCompatibles(int placaBaseId)
        {
            var placaBase = await _context.Set<PlacaBase>().FindAsync(placaBaseId);
            if (placaBase == null) return new List<MemoriaRAM>();
            return await _context.Set<MemoriaRAM>()
                .Where(m => m.TipoMemoria == placaBase.TipoMemoria)
                .ToListAsync();
        }

        public async Task<List<TarjetaGrafica>> GetTarjetasCompatibles(int placaBaseId)
        {
            return await _context.Set<TarjetaGrafica>().ToListAsync();
        }

        public async Task<List<Almacenamiento>> GetAlmacenamientosCompatibles(int placaBaseId)
        {
            var placaBase = await _context.Set<PlacaBase>().FindAsync(placaBaseId);
            if (placaBase == null) return new List<Almacenamiento>();
            return await _context.Set<Almacenamiento>()
                .Where(a => a.Interfaz == placaBase.TipoAlmacenamiento)
                .ToListAsync();
        }

        public async Task<List<FuentePoder>> GetFuentesCompatibles(int ensamblajeId)
        {
            var ensamblaje = await _context.Ensamblajes
                .Include(e => e.Procesador)
                .Include(e => e.TarjetaGrafica)
                .FirstOrDefaultAsync(e => e.Id == ensamblajeId);
            if (ensamblaje == null) return new List<FuentePoder>();
            int consumoTotal = 0;
            if (ensamblaje.Procesador != null)
                consumoTotal += ensamblaje.Procesador.ConsumoWatts;
            if (ensamblaje.TarjetaGrafica != null)
                consumoTotal += ensamblaje.TarjetaGrafica.ConsumoWatts;
            consumoTotal = (int)(consumoTotal * 1.2); // 20% mas por si acaso
            return await _context.Set<FuentePoder>()
                .Where(f => f.PotenciaWatts >= consumoTotal)
                .OrderBy(f => f.PotenciaWatts)
                .ToListAsync();
        }
        //ADMIN metodos
        public async Task<List<Componente>> GetComponentes()
        {
            return await _context.Componentes.ToListAsync();
        }

        public async Task<Componente> AddComponente(Componente modelo)
        {
            _context.Componentes.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<Componente> Update(Componente modelo)
        {
            _context.Componentes.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Delete(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return false;
            _context.Componentes.Remove(componente);
            await _context.SaveChangesAsync();
            return true;
        }
        //aqui lo de busqueda y navegacion
        public async Task<Componente?> GetComponentePorId(int id)
        {
            return await _context.Componentes.FindAsync(id);
        }

        public async Task<List<Componente>> BuscarComponentes(string nombre)
        {
            return await _context.Componentes
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<Componente>> GetComponentesPorTipo(string tipo)
        {
            return await _context.Componentes
                .Where(c => c.GetType().Name == tipo)
                .ToListAsync();
        }

        public async Task<List<Componente>> BuscarPorMarca(string marca)
        {
            return await _context.Componentes
                .Where(c => c.Marca.Contains(marca))
                .ToListAsync();
        }
    }
}
