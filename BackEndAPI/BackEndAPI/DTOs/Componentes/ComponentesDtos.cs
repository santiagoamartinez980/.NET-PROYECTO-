namespace BackEndAPI.DTOs.Componentes
{
    namespace BackEndAPI.DTOs.Componentes
    {
        // 📌 Procesador
        public class ProcesadorDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public string Socket { get; set; } = null!;
            public int ConsumoWatts { get; set; }
        }

        // 📌 Placa Base
        public class PlacaBaseDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public string Socket { get; set; } = null!;
            public string TipoMemoria { get; set; } = null!;
            public string TipoAlmacenamiento { get; set; } = null!;
        }

        // 📌 Memoria RAM
        public class MemoriaRamDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public string TipoMemoria { get; set; } = null!;
        }

        // 📌 Tarjeta Gráfica
        public class TarjetaGraficaDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public int ConsumoWatts { get; set; }
        }

        // 📌 Almacenamiento
        public class AlmacenamientoDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public string Tipo { get; set; } = null!;
            public string Interfaz { get; set; } = "SATA";
        }

        // 📌 Fuente de Poder
        public class FuentePoderDto
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = null!;
            public string Marca { get; set; } = null!;
            public string UrlImagen { get; set; } = null!;
            public int PotenciaWatts { get; set; }
        }
    }

}
