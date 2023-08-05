using Domain.Models.MayiBeerCollection;

namespace Application.DTO.General
{
    public class CiudadResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdPais { get; set; }
        public int PaisNombre { get; set; }
        public List<Cerveza>? Cervezas { get; set; }
    }
}
