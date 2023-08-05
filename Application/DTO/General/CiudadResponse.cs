using Domain.Models;
using Domain.Models.MayiBeerCollection;

namespace Application.DTO.General
{
    public class CiudadResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int IdPais { get; set; }
        public PaisResponse IdPaisNavigation { get; set; }
    }
}
