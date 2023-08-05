namespace Domain.Models.MayiBeerCollection;

public partial class Ciudad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdPais { get; set; }

    public virtual ICollection<Cerveza> Cerveza { get; } = new List<Cerveza>();

    public virtual Pais IdPaisNavigation { get; set; } = null!;
}
