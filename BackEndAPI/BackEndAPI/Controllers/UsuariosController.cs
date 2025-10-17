using AutoMapper;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using BackEndAPI.Services.Contrato.Componentes;
using BackEndAPI.Services.Contrato.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController: ControllerBase
    {
        private readonly IUsuario _service;
        private readonly IMapper _mapper;

        public UsuariosController (IUsuario service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            var lista = await _service.ObtenerUsuarios();
            return lista;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerPorId(int id)
        {
            var usuario = await _service.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario([FromBody] Usuario modelo)
        {
            var usuarioCreado = await _service.CrearUsuario(modelo);
            return Ok(usuarioCreado);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> ActualizarUsuario(int id, [FromBody] Usuario modelo)
        {
            if (id != modelo.Id) return BadRequest("El ID del usuario no coincide");
            var usuarioExistente = await _service.ObtenerPorId(id);
            if (usuarioExistente == null) return NotFound();
            var usuarioActualizado = await _service.ActualizarUsuario(modelo);
            return Ok(usuarioActualizado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuarioExistente = await _service.ObtenerPorId(id);
            if (usuarioExistente == null) return NotFound();
            var resultado = await _service.EliminarUsuario(id);
            if (!resultado) return StatusCode(500, "Ocurrió un error al eliminar el usuario");
            return NoContent();
        }


    }
}
