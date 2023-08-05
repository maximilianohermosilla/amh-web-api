namespace Domain.Models.GestorGastos;

public partial class Suscripcion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaDesde { get; set; }

    public DateTime? FechaHasta { get; set; }

    public decimal ValorActual { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Registro> Registro { get; } = new List<Registro>();
}
