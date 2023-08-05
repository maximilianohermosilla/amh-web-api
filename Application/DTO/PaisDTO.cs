namespace amh_web_api.DTO
{
    #nullable disable
    public class PaisDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; }
        public List<CiudadDTO>? ciudades { get; set; }
    }
}
