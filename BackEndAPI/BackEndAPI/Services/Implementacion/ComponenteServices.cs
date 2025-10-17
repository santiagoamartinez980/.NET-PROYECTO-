using AutoMapper;
using BackEndAPI.Data;
using BackEndAPI.DTOs.Componentes;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using BackEndAPI.Services.Contrato.Componentes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class ComponenteServices : IComponentesCompleto
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ComponenteServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ComponenteDto>> GetComponentes()
        {
            var lista = await _context.Componentes.ToListAsync();
            return _mapper.Map<List<ComponenteDto>>(lista);
        }

        public async Task<ComponenteDto?> GetComponentePorId(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            return componente == null ? null : _mapper.Map<ComponenteDto>(componente);
        }

        public async Task<ComponenteDto> AddComponente(ComponenteDto dto)
        {
            var entidad = _mapper.Map<Componente>(dto);
            _context.Componentes.Add(entidad);
            await _context.SaveChangesAsync();
            return _mapper.Map<ComponenteDto>(entidad);
        }


        public async Task<ComponenteDto> Update(ComponenteDto dto)
        {
            var entidad = _mapper.Map<Componente>(dto);
            _context.Componentes.Update(entidad);
            await _context.SaveChangesAsync();
            return _mapper.Map<ComponenteDto>(entidad);
        }

        public async Task<bool> Delete(int id)
        {
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null) return false;
            _context.Componentes.Remove(componente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ComponenteDto>> BuscarComponentes(string nombre)
        {
            var lista = await _context.Componentes
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();
            return _mapper.Map<List<ComponenteDto>>(lista);
        }

        public async Task<List<ComponenteDto>> BuscarPorMarca(string marca)
        {
            var lista = await _context.Componentes
                .Where(c => c.Marca.Contains(marca))
                .ToListAsync();
            return _mapper.Map<List<ComponenteDto>>(lista);
        }

        public async Task<List<ComponenteDto>> GetComponentesPorTipo(string tipo)
        {
            var lista = await _context.Componentes
                .Where(c => c.GetType().Name == tipo)
                .ToListAsync();
            return _mapper.Map<List<ComponenteDto>>(lista);
        }

        public async Task<List<ProcesadorDto>> GetProcesadores()
        {
            var lista = await _context.Set<Procesador>().ToListAsync();
            return _mapper.Map<List<ProcesadorDto>>(lista);
        }

        public async Task<List<PlacaBaseDto>> GetPlacasCompatibles(int procesadorId)
        {
            var procesador = await _context.Set<Procesador>().FindAsync(procesadorId);
            if (procesador == null) return new List<PlacaBaseDto>();

            var lista = await _context.Set<PlacaBase>()
                .Where(p => p.Socket == procesador.Socket)
                .ToListAsync();

            return _mapper.Map<List<PlacaBaseDto>>(lista);
        }

        public async Task<List<MemoriaRamDto>> GetMemoriasCompatibles(int placaBaseId)
        {
            var placa = await _context.Set<PlacaBase>().FindAsync(placaBaseId);
            if (placa == null) return new List<MemoriaRamDto>();

            var lista = await _context.Set<MemoriaRAM>()
                .Where(m => m.TipoMemoria == placa.TipoMemoria)
                .ToListAsync();

            return _mapper.Map<List<MemoriaRamDto>>(lista);
        }

        public async Task<List<TarjetaGraficaDto>> GetTarjetasCompatibles(int placaBaseId)
        {
            var lista = await _context.Set<TarjetaGrafica>().ToListAsync();
            return _mapper.Map<List<TarjetaGraficaDto>>(lista);
        }

        public async Task<List<AlmacenamientoDto>> GetAlmacenamientosCompatibles(int placaBaseId)
        {
            var placa = await _context.Set<PlacaBase>().FindAsync(placaBaseId);
            if (placa == null) return new List<AlmacenamientoDto>();

            var lista = await _context.Set<Almacenamiento>()
                .Where(a => a.Interfaz == placa.TipoAlmacenamiento)
                .ToListAsync();

            return _mapper.Map<List<AlmacenamientoDto>>(lista);
        }

        public async Task<List<FuentePoderDto>> GetFuentesCompatibles(int ensamblajeId)
        {
            var ensamblaje = await _context.Ensamblajes
                .Include(e => e.Procesador)
                .Include(e => e.TarjetaGrafica)
                .FirstOrDefaultAsync(e => e.Id == ensamblajeId);

            if (ensamblaje == null) return new List<FuentePoderDto>();

            int consumoTotal = 0;
            if (ensamblaje.Procesador != null)
                consumoTotal += ensamblaje.Procesador.ConsumoWatts;
            if (ensamblaje.TarjetaGrafica != null)
                consumoTotal += ensamblaje.TarjetaGrafica.ConsumoWatts;

            consumoTotal = (int)(consumoTotal * 1.2);

            var lista = await _context.Set<FuentePoder>()
                .Where(f => f.PotenciaWatts >= consumoTotal)
                .OrderBy(f => f.PotenciaWatts)
                .ToListAsync();

            return _mapper.Map<List<FuentePoderDto>>(lista);
        }
    }
}