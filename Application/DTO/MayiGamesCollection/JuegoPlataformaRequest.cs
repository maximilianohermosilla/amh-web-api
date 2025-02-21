namespace Application.DTO.MayiGamesCollection;

public partial class JuegoPlataformaRequest
{
    public int Id { get; set; }
    public int IdJuego { get; set; }
    public int IdPlataforma { get; set; }
    public int IdUsuario { get; set; }
    public DateTime? Fecha { get; set; } = DateTime.UtcNow;
    public string? Url { get; set; }
}
