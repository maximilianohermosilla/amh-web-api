namespace Domain.Models.GestorGastos;

public partial class Tarjeta
{
    public int Id { get; set; }

    public string? Numero { get; set; }

    public string? Vencimiento { get; set; }

    public int? IdBanco { get; set; }

    public int? IdTipoTarjeta { get; set; }

    public int? IdUsuario { get; set; }

    public bool? Habilitado { get; set; }

    public virtual ICollection<Cuenta> Cuentas { get; } = new List<Cuenta>();

    public virtual Banco? Banco { get; set; }

    public virtual TipoTarjeta? TipoTarjeta { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
