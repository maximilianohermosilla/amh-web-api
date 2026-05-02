namespace Domain.Models.GestorGastos;

public partial class RegistroAhorro
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCuenta { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Valor { get; set; }

    public decimal Diferencia { get; set; }

    public int? IdUsuario { get; set; }

    public string? Observaciones { get; set; }

    public string? Periodo { get; set; }

    public virtual Cuenta? Cuenta { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
