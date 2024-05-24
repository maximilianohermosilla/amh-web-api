namespace Domain.Models.GestorGastos;

public partial class RegistroVinculado
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cuotas { get; set; }

    public decimal ValorFinal { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();
}
