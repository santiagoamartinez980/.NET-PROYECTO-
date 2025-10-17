using BackEndAPI.DTOs.Componentes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IAdminComponetes
    {
        Task<List<ComponenteDto>> GetComponentes();
        Task<ComponenteDto> AddComponente(ComponenteDto modelo);
        Task<ComponenteDto> Update(ComponenteDto modelo);
        Task<bool> Delete(int id);
    }
}
