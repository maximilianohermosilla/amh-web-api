namespace Domain.Models.MayiGamesCollection;

public partial class JuegoPlataforma
{
    public int Id { get; set; }
    public int IdJuego { get; set; }
    public int IdPlataforma { get; set; }
    public int IdUsuario { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Url { get; set; }
    public virtual Juego Juego { get; set; } = null!;
    public virtual Plataforma Plataforma { get; set; } = null!;
    public virtual Usuario Usuario { get; set; } = null!;

}
