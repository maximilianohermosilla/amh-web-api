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

    public virtual ICollection<Cuenta> Cuentas { get; } = new List<Cuenta>();

    public virtual Perfil? Perfil { get; set; }

    public virtual ICollection<Registro> Registros { get; } = new List<Registro>();

    public virtual ICollection<RegistroVinculado> RegistrosVinculados { get; } = new List<RegistroVinculado>();

    public virtual ICollection<Suscripcion> Suscripciones { get; } = new List<Suscripcion>();

    public virtual ICollection<Tarjeta> Tarjetas { get; } = new List<Tarjeta>();

    public virtual ICollection<UsuarioSistema> UsuariosSistema { get; } = new List<UsuarioSistema>();

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();
}
