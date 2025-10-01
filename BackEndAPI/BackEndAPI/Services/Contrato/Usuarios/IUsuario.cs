using BackEndAPI.Models;

namespace BackEndAPI.Services.Contrato.Usuarios
{
    public interface IUsuario
    {
        Task<Usuario> RegistrarUsuario(Usuario modelo, string contraseña);
        Task<Usuario?> Login(string correo, string contraseña);
        Task<Usuario?> ObtenerPorId(int id);
        Task<List<Usuario>> ObtenerUsuarios();
        Task<Usuario> ActualizarUsuario(Usuario modelo);
        Task<bool> EliminarUsuario(int id);
    }
}
