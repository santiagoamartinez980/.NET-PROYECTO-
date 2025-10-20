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
            bool esLista = modelo.ValueKind == JsonValueKind.Array;

            object? dto = tipo.ToLower() switch
            {
                "procesador" => esLista
                    ? JsonSerializer.Deserialize<List<ProcesadorDto>>(modelo.ToString(), options)
                    : new List<ProcesadorDto> { JsonSerializer.Deserialize<ProcesadorDto>(modelo.ToString(), options)! },

                "placabase" => esLista
                    ? JsonSerializer.Deserialize<List<PlacaBaseDto>>(modelo.ToString(), options)
                    : new List<PlacaBaseDto> { JsonSerializer.Deserialize<PlacaBaseDto>(modelo.ToString(), options)! },

                "memoriaram" => esLista
                    ? JsonSerializer.Deserialize<List<MemoriaRamDto>>(modelo.ToString(), options)
                    : new List<MemoriaRamDto> { JsonSerializer.Deserialize<MemoriaRamDto>(modelo.ToString(), options)! },

                "tarjetagrafica" => esLista
                    ? JsonSerializer.Deserialize<List<TarjetaGraficaDto>>(modelo.ToString(), options)
                    : new List<TarjetaGraficaDto> { JsonSerializer.Deserialize<TarjetaGraficaDto>(modelo.ToString(), options)! },

                "almacenamiento" => esLista
                    ? JsonSerializer.Deserialize<List<AlmacenamientoDto>>(modelo.ToString(), options)
                    : new List<AlmacenamientoDto> { JsonSerializer.Deserialize<AlmacenamientoDto>(modelo.ToString(), options)! },

                "fuentepoder" => esLista
                    ? JsonSerializer.Deserialize<List<FuentePoderDto>>(modelo.ToString(), options)
                    : new List<FuentePoderDto> { JsonSerializer.Deserialize<FuentePoderDto>(modelo.ToString(), options)! },

                _ => null
            };

            if (dto == null) return BadRequest("Tipo de componente no válido.");

            var creados = new List<ComponenteDto>();

            switch (tipo.ToLower())
            {
                case "procesador":
                    foreach (var d in (List<ProcesadorDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                case "placabase":
                    foreach (var d in (List<PlacaBaseDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                case "memoriaram":
                    foreach (var d in (List<MemoriaRamDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                case "tarjetagrafica":
                    foreach (var d in (List<TarjetaGraficaDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                case "almacenamiento":
                    foreach (var d in (List<AlmacenamientoDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                case "fuentepoder":
                    foreach (var d in (List<FuentePoderDto>)dto)
                        creados.Add(await _service.AddComponente(d));
                    break;
                default:
                    return BadRequest("Tipo no soportado");
            }

            return Ok(creados);
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
