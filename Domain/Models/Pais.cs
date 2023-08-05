using Domain.Models.MayiBeerCollection;

namespace Domain.Models;

public partial class Pais
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<Ciudad> Ciudad { get; } = new List<Ciudad>();
}
