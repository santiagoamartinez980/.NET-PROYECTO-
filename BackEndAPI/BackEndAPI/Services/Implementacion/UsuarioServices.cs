using BackEndAPI.Data;
using BackEndAPI.Models;
using BackEndAPI.Services.Contrato.Usuarios; 
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class UsuarioService : IUsuario
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> RegistrarUsuario(Usuario modelo, string contraseña)
        {
            // hashear la contraseña
            modelo.HashContraseña = BCrypt.Net.BCrypt.HashPassword(contraseña);

            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<Usuario> ActualizarUsuario(Usuario modelo)
        {
            _context.Usuarios.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> Login(string correo, string contraseña)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
            if (usuario == null) return null;

            bool valido = BCrypt.Net.BCrypt.Verify(contraseña, usuario.HashContraseña);
            return valido ? usuario : null;
        }
    }
}
