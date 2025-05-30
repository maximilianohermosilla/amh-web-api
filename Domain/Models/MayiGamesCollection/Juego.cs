﻿namespace Domain.Models.MayiGamesCollection;

public partial class Juego
{
    public int Id { get; set; }    
    public string? AppId { get; set; }
    public string Nombre{ get; set; }
    public string? Descripcion { get; set; }
    public string? Imagen { get; set; }
    public virtual ICollection<JuegoPlataforma> JuegoPlataformas { get; } = new List<JuegoPlataforma>();
}
