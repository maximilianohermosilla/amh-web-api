namespace Domain.Models.MayiBeerCollection;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<Cerveza> Cerveza { get; } = new List<Cerveza>();
}
