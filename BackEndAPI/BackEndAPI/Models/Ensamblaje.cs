using BackEndAPI.Models.Componentes;

namespace BackEndAPI.Models
{
    public class Ensamblaje
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int ProcesadorId { get; set; }
        public Procesador Procesador { get; set; } = null!;

        public int PlacaBaseId { get; set; }
        public PlacaBase PlacaBase { get; set; } = null!;

        public int MemoriaRamId { get; set; }
        public MemoriaRAM MemoriaRAM { get; set; } = null!;

        public int? TarjetaGraficaId { get; set; }  
        public TarjetaGrafica? TarjetaGrafica { get; set; }

        public int AlmacenamientoId { get; set; }
        public Almacenamiento Almacenamiento { get; set; } = null!;

        public int FuentePoderId { get; set; }
        public FuentePoder FuentePoder { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
