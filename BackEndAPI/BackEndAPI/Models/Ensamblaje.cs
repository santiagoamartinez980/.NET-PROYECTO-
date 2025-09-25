using BackEndAPI.Models.Componentes;

namespace BackEndAPI.Models
{
    public class Ensamblaje
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int ProcesadorId { get; set; }
        public Procesador Procesador { get; set; }

        public int PlacaBaseId { get; set; }
        public PlacaBase PlacaBase { get; set; }

        public int MemoriaRamId { get; set; }
        public MemoriaRam MemoriaRam { get; set; }

        public int? TarjetaGraficaId { get; set; }  
        public TarjetaGrafica? TarjetaGrafica { get; set; }

        public int AlmacenamientoId { get; set; }
        public Almacenamiento Almacenamiento { get; set; }

        public int FuentePoderId { get; set; }
        public FuentePoder FuentePoder { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
