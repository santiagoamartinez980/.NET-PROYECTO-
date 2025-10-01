using BackEndAPI.Models;
namespace BackEndAPI.Services.Contrato.EnsamblajeService
{
    public interface IEnsamblaje
    {
        Task<Ensamblaje> CrearEnsamblaje(int usuarioId, List<int> componentesIds);
        Task<Ensamblaje?> ObtenerEnsamblajePorId(int id);
        Task<List<Ensamblaje>> ObtenerEnsamblajesPorUsuario(int usuarioId);
        Task<bool> EliminarEnsamblaje(int id);
        Task<Ensamblaje> ActualizarEnsamblaje(Ensamblaje modelo);
    }
}
