namespace BackEndAPI.Models
{
    public abstract class Componente
    {
        public int Id { get; set; }       
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;

        public string UrlImagen { get; set; } = null!;
    }
}
