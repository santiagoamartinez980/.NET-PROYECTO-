using AutoMapper;
using BackEndAPI.DTOs.Componentes;
using BackEndAPI.DTOs.Ensamblaje;
using BackEndAPI.DTOs.Usuario;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;

namespace BackEndAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Usuario
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<CrearUsuarioDto, Usuario>().ReverseMap();
            #endregion

            #region Ensamblaje
            CreateMap<Ensamblaje, EnsamblajeDto>().ReverseMap();
            CreateMap<CrearEnsamblajeDto, Ensamblaje>().ReverseMap();
            #endregion

            #region Componentes
            CreateMap<Componente, ComponenteDto>().ReverseMap();
            CreateMap<Procesador, ProcesadorDto>().ReverseMap();
            CreateMap<PlacaBase, PlacaBaseDto>().ReverseMap();
            CreateMap<MemoriaRAM, MemoriaRamDto>().ReverseMap();
            CreateMap<TarjetaGrafica, TarjetaGraficaDto>().ReverseMap();
            CreateMap<Almacenamiento, AlmacenamientoDto>().ReverseMap();
            CreateMap<FuentePoder, FuentePoderDto>().ReverseMap();
            #endregion
        }
    }
}
