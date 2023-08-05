namespace amh_web_api.DTO
{
    #nullable disable
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; }
        public int? IdArchivo { get; set; }
        public byte[]? ImageFile { get; set; }
        public List<CervezaDTO> Cervezas { get; set; }
    }
}
