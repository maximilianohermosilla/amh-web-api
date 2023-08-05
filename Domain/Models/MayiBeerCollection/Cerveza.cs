namespace Domain.Models.MayiBeerCollection;

public partial class Cerveza
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public double? IBU { get; set; }

    public double? Alcohol { get; set; }

    public int IdMarca { get; set; }

    public int? IdEstilo { get; set; }

    public int? IdCiudad { get; set; }

    public string? Observaciones { get; set; }

    public int Contenido { get; set; }

    public string? Imagen { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual Estilo? IdEstiloNavigation { get; set; }

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
