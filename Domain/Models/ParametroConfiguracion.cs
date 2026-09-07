namespace Domain.Models;

public partial class ParametroConfiguracion
{
    public int Id { get; set; }
    public int IdSistema { get; set; }
    public string Nombre { get; set; } = null!;
    public string Valor { get; set; } = null!;

    public virtual Sistema Sistema { get; set; } = null!;
}
