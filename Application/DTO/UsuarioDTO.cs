namespace amh_web_api.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Correo { get; set; }

        public string? Imagen { get; set; }

        public bool? Habilitado { get; set; }

        public int? IdPerfil { get; set; }

        public string? Perfil { get; set; }

        public List<SistemaDTO>? Sistemas { get; set; }

    }
}
