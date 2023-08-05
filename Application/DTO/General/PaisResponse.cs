namespace Application.DTO.General
{
    public class PaisResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Imagen { get; set; }
        public List<CiudadPaisResponse>? Ciudades { get; set; }
    }
}
