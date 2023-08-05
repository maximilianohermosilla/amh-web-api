namespace Application.DTO.General
{
    public class UsuarioRequest
    {
        public string Nombre { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Correo { get; set; }
        public string? Imagen { get; set; }
        public bool? Habilitado { get; set; }
        public int? IdPerfil { get; set; }
    }
}
