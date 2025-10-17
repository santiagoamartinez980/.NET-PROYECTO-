using AutoMapper;
using BackEndAPI.DTOs.Componentes;
using BackEndAPI.Services.Contrato.Componentes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentesController : ControllerBase
    {
        private readonly IComponentesCompleto _service;

        public ComponentesController(IComponentesCompleto service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetComponentes()
        {
            return Ok(await _service.GetComponentes());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComponentePorId(int id)
        {
            var comp = await _service.GetComponentePorId(id);
            if (comp == null) return NotFound();
            return Ok(comp);
        }

        [HttpGet("search")]
        public async Task<IActionResult> BuscarComponentes([FromQuery] string nombre)
        {
            return Ok(await _service.BuscarComponentes(nombre));
        }

        [HttpGet("marca/{marca}")]
        public async Task<IActionResult> BuscarPorMarca(string marca)
        {
            return Ok(await _service.BuscarPorMarca(marca));
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<IActionResult> GetComponentesPorTipo(string tipo)
        {
            return Ok(await _service.GetComponentesPorTipo(tipo));
        }

        [HttpPost("{tipo}")]
        public async Task<IActionResult> AddComponente(string tipo, [FromBody] JsonElement modelo)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            object? dto = tipo.ToLower() switch
            {
                "procesador" => JsonSerializer.Deserialize<ProcesadorDto>(modelo.ToString(), options),
                "placabase" => JsonSerializer.Deserialize<PlacaBaseDto>(modelo.ToString(), options),
                "memoriaram" => JsonSerializer.Deserialize<MemoriaRamDto>(modelo.ToString(), options),
                "tarjetagrafica" => JsonSerializer.Deserialize<TarjetaGraficaDto>(modelo.ToString(), options),
                "almacenamiento" => JsonSerializer.Deserialize<AlmacenamientoDto>(modelo.ToString(), options),
                "fuentepoder" => JsonSerializer.Deserialize<FuentePoderDto>(modelo.ToString(), options),
                _ => null
            };

            if (dto == null) return BadRequest("Tipo de componente no válido.");

            var creado = tipo.ToLower() switch
            {
                "procesador" => await _service.AddComponente((ProcesadorDto)dto),
                "placabase" => await _service.AddComponente((PlacaBaseDto)dto),
                "memoriaram" => await _service.AddComponente((MemoriaRamDto)dto),
                "tarjetagrafica" => await _service.AddComponente((TarjetaGraficaDto)dto),
                "almacenamiento" => await _service.AddComponente((AlmacenamientoDto)dto),
                "fuentepoder" => await _service.AddComponente((FuentePoderDto)dto),
                _ => null
            };

            if (creado == null) return BadRequest("No se pudo crear el componente.");

            return CreatedAtAction(nameof(GetComponentePorId), new { id = creado.Id }, creado);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComponenteDto dto)
        {
            if (dto == null || dto.Id != id) return BadRequest();
            var actualizado = await _service.Update(dto);
            return Ok(actualizado);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComponente(int id)
        {
            var ok = await _service.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpGet("procesadores")]
        public async Task<IActionResult> GetProcesadores()
        {
            return Ok(await _service.GetProcesadores());
        }

        [HttpGet("placas-compatibles/{procesadorId:int}")]
        public async Task<IActionResult> GetPlacasCompatibles(int procesadorId)
        {
            return Ok(await _service.GetPlacasCompatibles(procesadorId));
        }

        [HttpGet("memorias-compatibles/{placaBaseId:int}")]
        public async Task<IActionResult> GetMemoriasCompatibles(int placaBaseId)
        {
            return Ok(await _service.GetMemoriasCompatibles(placaBaseId));
        }

        [HttpGet("tarjetas-compatibles/{placaBaseId:int}")]
        public async Task<IActionResult> GetTarjetasCompatibles(int placaBaseId)
        {
            return Ok(await _service.GetTarjetasCompatibles(placaBaseId));
        }

        [HttpGet("almacenamientos-compatibles/{placaBaseId:int}")]
        public async Task<IActionResult> GetAlmacenamientosCompatibles(int placaBaseId)
        {
            return Ok(await _service.GetAlmacenamientosCompatibles(placaBaseId));
        }

        [HttpGet("fuentes-compatibles/{ensamblajeId:int}")]
        public async Task<IActionResult> GetFuentesCompatibles(int ensamblajeId)
        {
            return Ok(await _service.GetFuentesCompatibles(ensamblajeId));
        }
    }
}
