namespace Domain.Models.GestorGastos;

public partial class Ingreso
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descripcion { get; set; } = null!;
    public DateTime Fecha { get; set; }
    public string? Periodo { get; set; }
    public int IdUsuario { get; set; }
    public int IdCategoriaIngreso { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual CategoriaIngreso CategoriaIngreso { get; set; } = null!;
}
