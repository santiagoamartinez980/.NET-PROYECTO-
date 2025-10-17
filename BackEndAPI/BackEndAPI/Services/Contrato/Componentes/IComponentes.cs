using BackEndAPI.DTOs.Componentes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IComponentes
    {
        Task<List<ProcesadorDto>> GetProcesadores();
        Task<List<PlacaBaseDto>> GetPlacasCompatibles(int procesadorId);
        Task<List<MemoriaRamDto>> GetMemoriasCompatibles(int placaBaseId);
        Task<List<TarjetaGraficaDto>> GetTarjetasCompatibles(int placaBaseId);
        Task<List<AlmacenamientoDto>> GetAlmacenamientosCompatibles(int placaBaseId);
        Task<List<FuentePoderDto>> GetFuentesCompatibles(int ensamblajeId);
    }
}
