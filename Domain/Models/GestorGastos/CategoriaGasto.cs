namespace Domain.Models.GestorGastos;

public partial class CategoriaGasto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Color { get; set; } = null!;
    public string? Icono { get; set; } = null!;

    public virtual ICollection<Suscripcion> Suscripciones { get; } = new List<Suscripcion>();
    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();
}
