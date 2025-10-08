using BackEndAPI.DTOs.Componentes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IConsultaComponentes
    {
        Task<ComponenteDto?> GetComponentePorId(int id);
        Task<List<ComponenteDto>> BuscarComponentes(string nombre);
        Task<List<ComponenteDto>> BuscarPorMarca(string marca);
        Task<List<ComponenteDto>> GetComponentesPorTipo(string tipo);
    }
}
