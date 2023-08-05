namespace amh_web_api.DTO
{
    public class CervezaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double? Ibu { get; set; }
        public double? Alcohol { get; set; }
        public int IdMarca { get; set; }
        public string? NombreMarca { get; set; }
        public int? IdEstilo { get; set; }
        public string? NombreEstilo { get; set; }
        public int? IdCiudad { get; set; }
        public string? NombreCiudad { get; set; }
        public int? IdPais { get; set; }
        public string? NombrePais { get; set; }
        public string? Observaciones { get; set; }
        public int Contenido { get; set; }
        public string? Imagen { get; set; }
        public int? IdArchivo { get; set; }
        public byte[]? ImageFile { get; set; }
    }
}
