using Application.DTO.General;

namespace Application.DTO.MayiGamesCollection;

public partial class JuegoPlataformaResponse
{
    public int Id { get; set; }
    public int IdJuego { get; set; }
    public int IdPlataforma { get; set; }
    public int IdUsuario { get; set; }
    public DateTime? Fecha { get; set; }
    public string? Url { get; set; }
    public virtual JuegoResponse Juego { get; set; } = null!;
    public virtual PlataformaResponse Plataforma { get; set; } = null!;
    public virtual UsuarioResponse Usuario { get; set; } = null!;

}
