using AutoMapper;
using BackEndAPI.DTOs.Ensamblaje;
using BackEndAPI.Models;
using BackEndAPI.Services.Contrato.EnsamblajeService;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnsamblajeController : ControllerBase
    {
        private readonly IEnsamblaje _service;
        private readonly IMapper _mapper;

        public EnsamblajeController(IEnsamblaje service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<EnsamblajeDto>>> ObtenerEnsamblajesPorUsuario(int usuarioId)
        {
            var lista = await _service.ObtenerEnsamblajesPorUsuario(usuarioId);
            var dto = _mapper.Map<IEnumerable<EnsamblajeDto>>(lista);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnsamblajeDto>> ObtenerEnsamblajePorId(int id)
        {
            var ensamblaje = await _service.ObtenerEnsamblajePorId(id);
            if (ensamblaje == null) return NotFound();

            var dto = _mapper.Map<EnsamblajeDto>(ensamblaje);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<EnsamblajeDto>> CrearEnsamblaje([FromBody] CrearEnsamblajeDto dto)
        {
            var ensamblaje = await _service.CrearEnsamblaje(dto);
            var ensamblajeDto = _mapper.Map<EnsamblajeDto>(ensamblaje);
            return CreatedAtAction(nameof(ObtenerEnsamblajePorId), new { id = ensamblajeDto.Id }, ensamblajeDto);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<EnsamblajeDto>> ActualizarEnsamblaje(int id, [FromBody] EnsamblajeDto dto)
        {
            if (id != dto.Id) return BadRequest("El ID no coincide.");

            var existente = await _service.ObtenerEnsamblajePorId(id);
            if (existente == null) return NotFound();

            var modelo = _mapper.Map<Ensamblaje>(dto);
            var actualizado = await _service.ActualizarEnsamblaje(modelo);

            return Ok(_mapper.Map<EnsamblajeDto>(actualizado));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEnsamblaje(int id)
        {
            var existente = await _service.ObtenerEnsamblajePorId(id);
            if (existente == null) return NotFound();

            var eliminado = await _service.EliminarEnsamblaje(id);
            if (!eliminado) return StatusCode(500, "Error al eliminar el ensamblaje.");

            return NoContent();
        }
    }
}