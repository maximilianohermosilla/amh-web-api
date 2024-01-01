namespace Domain.Models.GestorGastos;

public partial class Suscripcion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public decimal ValorActual { get; set; }

    public int? IdCategoriaGasto { get; set; }

    public int? IdUsuario { get; set; }

    public virtual CategoriaGasto? CategoriaGasto { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();
}
