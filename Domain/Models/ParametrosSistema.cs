namespace Domain.Models;

public partial class ParametrosSistema
{
    public int Id { get; set; }    
    public int IdSistema { get; set; }
    public string? Host { get; set; }
    public string? Service { get; set; }
    public int? Port { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }
    public string? Template { get; set; }
    public virtual Sistema Sistema { get; set; } = null!;
}
