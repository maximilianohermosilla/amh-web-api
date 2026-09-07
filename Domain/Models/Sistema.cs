namespace Domain.Models;

public partial class Sistema
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<UsuarioSistema> UsuariosSistema { get; } = new List<UsuarioSistema>();

    public virtual ParametrosSistema? ParametrosSistema { get; set; }

    public virtual ICollection<ParametroConfiguracion> ParametrosConfiguracion { get; } = new List<ParametroConfiguracion>();
}
