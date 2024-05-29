using Domain.Models.GestorGastos;
using Domain.Models;

namespace Application.DTO.GestorGastos
{
    public class IngresoResponse
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? Periodo { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoriaIngreso { get; set; }
        public string? CategoriaIngresoNombre { get; set; } = null!;
        public CategoriaIngresoResponse? CategoriaIngreso { get; set; }
    }
}
