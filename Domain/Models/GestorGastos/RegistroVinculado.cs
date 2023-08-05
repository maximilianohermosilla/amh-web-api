namespace Domain.Models.GestorGastos;

public partial class RegistroVinculado
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cuotas { get; set; }

    public decimal ValorFinal { get; set; }

    public virtual ICollection<Registro> Registro { get; } = new List<Registro>();
}
