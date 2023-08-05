namespace Domain.Models.GestorGastos;

public partial class Banco
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tarjeta> Tarjetas { get; } = new List<Tarjeta>();
}
