namespace BackEndAPI.DTOs.Usuario
{
    public class CrearUsuarioDto
    {
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}
