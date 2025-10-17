using BackEndAPI.Models;

namespace BackEndAPI.Services.Contrato.Authentication
{
    public interface IAuthService
    {
        Task<Usuario?> LoginAsync(string correo, string contraseña);
        Task<Usuario> RegisterAsync(Usuario usuario, string contraseña);
        string GenerarToken(Usuario usuario);
    }
}
