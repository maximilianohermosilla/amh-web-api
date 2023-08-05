namespace Application.DTO.General
{
    public class SistemaResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }        
        public List<UsuarioResponse>? Usuarios { get; set; }
    }
}
