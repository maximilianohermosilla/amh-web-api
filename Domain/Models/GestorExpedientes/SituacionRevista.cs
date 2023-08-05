namespace Domain.Models.GestorExpedientes;

public partial class SituacionRevista
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Expediente> Expedientes { get; } = new List<Expediente>();
}
