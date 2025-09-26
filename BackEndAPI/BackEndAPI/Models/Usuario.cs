using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; } 

        [Required, MaxLength(50)]
        public string Nombres { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Apellidos { get; set; } = null!;

        [Required, EmailAddress]
        public string Correo { get; set; } = null!;

        [Required]
        public string Documento { get; set; } = null!;
        [Required]
        [Phone]
        public string Telefono { get; set; } = null!;

        public string HashContraseña { get; set; } = string.Empty;

        public ICollection<Ensamblaje> Ensamblajes { get; set; } = new List<Ensamblaje>();
    }
}
