﻿namespace Domain.Models.MayiBeerCollection;

public partial class Estilo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<Cerveza> Cervezas { get; } = new List<Cerveza>();
}
