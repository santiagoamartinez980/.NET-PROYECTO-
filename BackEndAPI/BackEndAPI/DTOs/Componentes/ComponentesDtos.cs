namespace BackEndAPI.DTOs.Componentes
{
  
    
        public class ComponenteDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
        }
        // 📌 Procesador
        public class ProcesadorDto: ComponenteDto
        {
            public string Socket { get; set; } = null!;
            public int ConsumoWatts { get; set; }
        }

        // 📌 Placa Base
        public class PlacaBaseDto : ComponenteDto
        {
            public string Socket { get; set; } = null!;
            public string TipoMemoria { get; set; } = null!;
            public string TipoAlmacenamiento { get; set; } = null!;
        }

        // 📌 Memoria RAM
        public class MemoriaRamDto : ComponenteDto
        {
            public string TipoMemoria { get; set; } = null!;
        }

        // 📌 Tarjeta Gráfica
        public class TarjetaGraficaDto : ComponenteDto
        {

            public int ConsumoWatts { get; set; }
        }

        // 📌 Almacenamiento
        public class AlmacenamientoDto : ComponenteDto
        {

            public string Tipo { get; set; } = null!;
            public string Interfaz { get; set; } = "SATA";
        }

        // 📌 Fuente de Poder
        public class FuentePoderDto : ComponenteDto
        {
            public int PotenciaWatts { get; set; }
        }
    

}
