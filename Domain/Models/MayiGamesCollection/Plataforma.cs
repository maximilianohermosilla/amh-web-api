namespace Domain.Models.MayiGamesCollection;

public partial class Plataforma
{
    public int Id { get; set; }    
    public string Nombre { get; set; }
    public string? Imagen{ get; set; }
    public string? Descripcion { get; set; }
    public string? Url { get; set; }
    public virtual ICollection<JuegoPlataforma> JuegoPlataformas { get; } = new List<JuegoPlataforma>();
}
