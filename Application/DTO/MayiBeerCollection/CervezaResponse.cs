using Application.DTO.General;

namespace Application.DTO.MayiBeerCollection
{
    public class CervezaResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double? IBU { get; set; }
        public double? Alcohol { get; set; }
        public int IdMarca { get; set; }
        public MarcaResponse Marca { get; set; }
        public int? IdEstilo { get; set; }
        public EstiloResponse Estilo { get; set; }
        public int? IdCiudad { get; set; }
        public CiudadResponse Ciudad { get; set; }
        public int? IdPais { get; set; }        
        public string? Observaciones { get; set; }
        public int Contenido { get; set; }
        public string? Imagen { get; set; }
    }
}
