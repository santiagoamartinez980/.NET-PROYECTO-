using BackEndAPI.Models;
namespace BackEndAPI.Services.Registro.ComponenteService
{
    public interface IComponentes
    {
        Task<List<Componente>> GetComponentes();
        Task<Componente> GetComponentePorId(int id);
        Task<Componente> AddComponente(Componente modelo);
        Task<Componente> Update(Componente modelo);
        Task<bool> Delete(int id);
    }
}
