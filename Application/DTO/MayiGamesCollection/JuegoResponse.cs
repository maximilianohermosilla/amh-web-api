namespace Application.DTO.MayiGamesCollection;

public partial class JuegoResponse
{
    public int Id { get; set; }    
    public string? AppId { get; set; }
    public string Nombre{ get; set; }
    public string? Descripcion { get; set; }
    public string? Imagen { get; set; }
    public virtual ICollection<JuegoPlataformaRequest> JuegoPlataformas { get; set; }
}
