namespace BackEndAPI.DTOs.Ensamblaje
{
    public class CrearEnsamblajeDto
    {
        public int UsuarioId { get; set; }
        public int ProcesadorId { get; set; }
        public int PlacaBaseId { get; set; }
        public int MemoriaRamId { get; set; }
        public int? TarjetaGraficaId { get; set; }
        public int AlmacenamientoId { get; set; }
        public int FuentePoderId { get; set; }
    }

}
