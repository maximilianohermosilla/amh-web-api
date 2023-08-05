namespace Domain.Models.GestorGastos;

public partial class Cuenta
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoCuenta { get; set; }

    public int? IdTarjeta { get; set; }

    public int IdUsuario { get; set; }

    public bool? Habilitado { get; set; }

    public virtual Tarjeta? Tarjeta { get; set; }

    public virtual TipoCuenta TipoCuenta { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();
}
