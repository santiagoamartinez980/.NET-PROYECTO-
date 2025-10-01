using BackEndAPI.Models;

namespace BackEndAPI.Services.Contrato.Componentes
{
    public interface IAdminComponetes
    {
        Task<List<Componente>> GetComponentes();
        Task<Componente> AddComponente(Componente modelo);
        Task<Componente> Update(Componente modelo);
        Task<bool> Delete(int id);
    }
}
