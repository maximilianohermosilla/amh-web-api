using Domain.Models.GestorGastos;

namespace Domain.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Imagen { get; set; }

    public bool? Habilitado { get; set; }

    public int? IdPerfil { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; } = new List<Cuenta>();

    public virtual Perfil? IdPerfilNavigation { get; set; }

    public virtual ICollection<Registro> Registro { get; } = new List<Registro>();

    public virtual ICollection<Suscripcion> Suscripcion { get; } = new List<Suscripcion>();

    public virtual ICollection<Tarjeta> Tarjeta { get; } = new List<Tarjeta>();

    public virtual ICollection<UsuarioSistema> UsuarioSistema { get; } = new List<UsuarioSistema>();
}
