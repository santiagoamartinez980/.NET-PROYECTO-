namespace BackEndAPI.Models.Componentes
{
    public class Almacenamiento : Componente
    {
        public string Tipo { get; set; }
        public string Interfaz { get; set; } = "SATA";
    }
}