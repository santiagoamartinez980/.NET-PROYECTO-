using BackEndAPI.Models;

namespace BackEndAPI.Services.Contrato.Usuarios
{
    public interface IUsuario
    {
        Task<List<Usuario>> ObtenerUsuarios();
        Task<Usuario?> ObtenerPorId(int id);
        Task<Usuario> CrearUsuario(Usuario modelo);
        Task<Usuario> ActualizarUsuario(Usuario modelo);
        Task<bool> EliminarUsuario(int id);
    }
}
