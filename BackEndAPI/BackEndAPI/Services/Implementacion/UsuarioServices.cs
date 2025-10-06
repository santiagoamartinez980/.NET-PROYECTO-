using BackEndAPI.Data;
using BackEndAPI.Models;
using BackEndAPI.Services.Contrato.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementacion
{
    public class UsuarioServices : IUsuario
    {
        private readonly AppDbContext _context;

        public UsuarioServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CrearUsuario(Usuario modelo)
        {
            _context.Usuarios.Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<Usuario> ActualizarUsuario(Usuario modelo)
        {
            var existente = await _context.Usuarios.FindAsync(modelo.Id);
            if (existente == null)
                throw new Exception("Usuario no encontrado");

            existente.Nombres = modelo.Nombres;
            existente.Correo = modelo.Correo;
            existente.Rol = modelo.Rol;

            _context.Usuarios.Update(existente);
            await _context.SaveChangesAsync();

            return existente;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}