using BackEndAPI.DTOs.Usuario;
using BackEndAPI.Models;
using BackEndAPI.Services.Contrato.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
        {
            var usuario = await _authService.LoginAsync(dto.Correo, dto.Contraseña);
            if (usuario == null)
                return Unauthorized("Correo o contraseña incorrectos");

            var token = _authService.GenerarToken(usuario);
            return Ok(new { token, usuario.Id, usuario.Correo, usuario.Rol });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CrearUsuarioDto dto)
        {
            var nuevoUsuario = new Usuario
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Correo = dto.Correo,
                Documento = dto.Documento,
                Telefono = dto.Telefono,
                Rol = "Usuario"
            };

            var usuario = await _authService.RegisterAsync(nuevoUsuario, dto.Contraseña);
            return Ok(usuario);
        }

    }
}