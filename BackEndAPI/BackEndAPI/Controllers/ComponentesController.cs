using AutoMapper;
using BackEndAPI.Models;
using BackEndAPI.Models.Componentes;
using BackEndAPI.Services.Contrato.Componentes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentesController : ControllerBase
    {
        private readonly IComponentesCompleto _service;
        private readonly IMapper _mapper;
        
        public ComponentesController(IComponentesCompleto service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Componente>>> GetComponentes()
        {
            var lista = await _service.GetComponentes();
            return Ok(lista);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Componente>> GetComponentePorId(int id)
        {
            var comp = await _service.GetComponentePorId(id);
            if (comp == null) return NotFound();
            return Ok(comp);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Componente>>> BuscarComponentes([FromQuery] string nombre)
        {
            var lista = await _service.BuscarComponentes(nombre);
            return Ok(lista);
        }

        [HttpGet("marca/{marca}")]
        public async Task<ActionResult<List<Componente>>> BuscarPorMarca(string marca)
        {
            var lista = await _service.BuscarPorMarca(marca);
            return Ok(lista);
        }

        [HttpGet("tipo/{tipo}")]
        public async Task<ActionResult<List<Componente>>> GetComponentesPorTipo(string tipo)
        {
            var lista = await _service.GetComponentesPorTipo(tipo);
            return Ok(lista);
        }

        #region ADMIN CRUD
        //[Authorize(Roles = "Admin")]
        [HttpPost("{tipo}")]
        public async Task<ActionResult<Componente>> AddComponente(string tipo, [FromBody] JsonElement modelo)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Componente componente;

            switch (tipo.ToLower())
            {
                case "procesador":
                    componente = JsonSerializer.Deserialize<Procesador>(modelo.ToString(), options)!;
                    break;
                case "placabase":
                    componente = JsonSerializer.Deserialize<PlacaBase>(modelo.ToString(), options)!;
                    break;
                case "memoriaram":
                    componente = JsonSerializer.Deserialize<MemoriaRAM>(modelo.ToString(), options)!;
                    break;
                case "tarjetagrafica":
                    componente = JsonSerializer.Deserialize<TarjetaGrafica>(modelo.ToString(), options)!;
                    break;
                case "almacenamiento":
                    componente = JsonSerializer.Deserialize<Almacenamiento>(modelo.ToString(), options)!;
                    break;
                case "fuentepoder":
                    componente = JsonSerializer.Deserialize<FuentePoder>(modelo.ToString(), options)!;
                    break;
                default:
                    return BadRequest("Tipo de componente no válido.");
            }

            var creado = await _service.AddComponente(componente);
            return CreatedAtAction(nameof(GetComponentePorId), new { id = creado.Id }, creado);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Componente>> UpdateComponente(int id, [FromBody] Componente modelo)
        {
            if (modelo == null || modelo.Id != id) return BadRequest();
            var actualizado = await _service.Update(modelo);
            return Ok(actualizado);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteComponente(int id)
        {
            var ok = await _service.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }
        #endregion

        [HttpGet("procesadores")]
        public async Task<ActionResult<List<Procesador>>> GetProcesadores()
        {
            var lista = await _service.GetProcesadores();
            return Ok(lista);
        }

        [HttpGet("placas-compatibles/{procesadorId:int}")]
        public async Task<ActionResult<List<PlacaBase>>> GetPlacasCompatibles(int procesadorId)
        {
            var lista = await _service.GetPlacasCompatibles(procesadorId);
            return Ok(lista);
        }

        [HttpGet("memorias-compatibles/{placaBaseId:int}")]
        public async Task<ActionResult<List<MemoriaRAM>>> GetMemoriasCompatibles(int placaBaseId)
        {
            var lista = await _service.GetMemoriasCompatibles(placaBaseId);
            return Ok(lista);
        }

        [HttpGet("tarjetas-compatibles/{placaBaseId:int}")]
        public async Task<ActionResult<List<TarjetaGrafica>>> GetTarjetasCompatibles(int placaBaseId)
        {
            var lista = await _service.GetTarjetasCompatibles(placaBaseId);
            return Ok(lista);
        }

        [HttpGet("almacenamientos-compatibles/{placaBaseId:int}")]
        public async Task<ActionResult<List<Almacenamiento>>> GetAlmacenamientosCompatibles(int placaBaseId)
        {
            var lista = await _service.GetAlmacenamientosCompatibles(placaBaseId);
            return Ok(lista);
        }

        [HttpGet("fuentes-compatibles/{ensamblajeId:int}")]
        public async Task<ActionResult<List<FuentePoder>>> GetFuentesCompatibles(int ensamblajeId)
        {
            var lista = await _service.GetFuentesCompatibles(ensamblajeId);
            return Ok(lista);
        }
    }
}