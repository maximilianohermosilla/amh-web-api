namespace Domain.Models.GestorGastos;

public partial class CategoriaIngreso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();
}
