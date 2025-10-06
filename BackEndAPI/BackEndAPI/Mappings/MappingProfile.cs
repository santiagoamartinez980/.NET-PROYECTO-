using AutoMapper;
using BackEndAPI.DTOs.Componentes.BackEndAPI.DTOs.Componentes;
using BackEndAPI.DTOs.Ensamblaje;
using BackEndAPI.DTOs.Usuario;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;

namespace BackEndAPI.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            #region Usuario
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<CrearUsuarioDto, Usuario>();
            #endregion

            #region Ensamblaje
            CreateMap<Ensamblaje, EnsamblajeDto>();
            CreateMap<CrearEnsamblajeDto, Ensamblaje>();
            #endregion

            #region Componentes
            CreateMap<Procesador, ProcesadorDto>();
            CreateMap<PlacaBase, PlacaBaseDto>();
            CreateMap<MemoriaRAM, MemoriaRamDto>();
            CreateMap<TarjetaGrafica, TarjetaGraficaDto>();
            CreateMap<Almacenamiento, AlmacenamientoDto>();
            CreateMap<FuentePoder, FuentePoderDto>();
            #endregion
        }
    }
}
