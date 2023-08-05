using Domain.Models.MayiBeerCollection;

namespace Domain.Models;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual ICollection<Cerveza> Cervezas { get; } = new List<Cerveza>();

    public virtual Pais Pais { get; set; } = null!;
}
