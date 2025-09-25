using System.ComponentModel.DataAnnotations;

namespace BackEndAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; } 

        [Required, MaxLength(50)]
        public string Nombres { get; set; }

        [Required, MaxLength(50)]
        public string Apellidos { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Documento { get; set; } 

        [Phone]
        public string Telefono { get; set; } 
    }
}
