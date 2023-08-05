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

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();

    public virtual Banco? IdBancoNavigation { get; set; }

    public virtual TipoTarjeta? IdTipoTarjetaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
