namespace Application.DTO.MayiBeerCollection
{
    public class CervezaRequest
    {
        public string Nombre { get; set; }
        public double? IBU { get; set; }
        public double? Alcohol { get; set; }
        public int IdMarca { get; set; }
        public int? IdEstilo { get; set; }
        public int? IdCiudad { get; set; }
        public string? Observaciones { get; set; }
        public int Contenido { get; set; }
        public string? imagen { get; set; }
        public int? IdArchivo { get; set; }
    }
}
