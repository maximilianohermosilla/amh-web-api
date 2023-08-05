namespace Domain.Models.GestorGastos;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Registro> Registro { get; } = new List<Registro>();
}
