namespace amh_web_api.DTO
{
    public class SistemaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public List<UsuarioDTO>? Usuarios { get; set; }

    }
}
