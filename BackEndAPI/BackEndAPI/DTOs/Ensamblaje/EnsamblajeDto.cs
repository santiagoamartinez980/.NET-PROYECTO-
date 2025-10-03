namespace BackEndAPI.DTOs.Ensamblaje
{
    public class EnsamblajeDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Procesador { get; set; } = null!;
        public string PlacaBase { get; set; } = null!;
        public string MemoriaRam { get; set; } = null!;
        public string? TarjetaGrafica { get; set; }
        public string Almacenamiento { get; set; } = null!;
        public string FuentePoder { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
