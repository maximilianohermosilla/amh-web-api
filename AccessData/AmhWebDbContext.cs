using Domain.Models;
using Domain.Models.GestorExpedientes;
using Domain.Models.GestorGastos;
using Domain.Models.MayiBeerCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData;

public partial class AmhWebDbContext : DbContext
{
    public AmhWebDbContext(DbContextOptions<AmhWebDbContext> options)
        : base(options)
    {
    }

    //GESTOR EXPEDIENTES
    public virtual DbSet<Acto> Acto { get; set; }
    public virtual DbSet<Caratula> Caratula { get; set; }
    public virtual DbSet<Expediente> Expediente { get; set; }
    public virtual DbSet<SituacionRevista> SituacionRevista { get; set; }

    //GESTOR GASTOS
    public virtual DbSet<Banco> Banco { get; set; }
    public virtual DbSet<Cuenta> Cuenta { get; set; }
    public virtual DbSet<CategoriaGasto> CategoriaGasto { get; set; }
    public virtual DbSet<CategoriaIngreso> CategoriaIngreso { get; set; }
    public virtual DbSet<Empresa> Empresa { get; set; }
    public virtual DbSet<Registro> Registro { get; set; }
    public virtual DbSet<RegistroVinculado> RegistroVinculado { get; set; }
    public virtual DbSet<Tarjeta> Tarjeta { get; set; }
    public virtual DbSet<TipoTarjeta> TipoTarjeta { get; set; }
    public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
    public virtual DbSet<Suscripcion> Suscripcion { get; set; }
    public virtual DbSet<Ingreso> Ingreso { get; set; }

    //MAYIBEERCOLLECTION
    public virtual DbSet<Cerveza> Cerveza { get; set; }
    public virtual DbSet<Ciudad> Ciudad { get; set; }
    public virtual DbSet<Estilo> Estilo { get; set; }
    public virtual DbSet<Marca> Marca { get; set; }

    //GENERAL
    public virtual DbSet<Log> Log { get; set; }
    public virtual DbSet<Pais> Pais { get; set; }
    public virtual DbSet<Perfil> Perfil { get; set; }
    public virtual DbSet<Sistema> Sistema { get; set; }
    public virtual DbSet<ParametrosSistema> ParametrosSistema { get; set; }
    public virtual DbSet<Usuario> Usuario { get; set; }
    public virtual DbSet<UsuarioSistema> UsuarioSistema { get; set; }
    public virtual DbSet<Cancion> Cancion { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acto>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cancion>(entity =>
        {
            entity.Property(e => e.NombreSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Caratula>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoriaGasto>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)                
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoriaIngreso>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cerveza>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Cervezas)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_Cerveza_Ciudad");

            entity.HasOne(d => d.Estilo).WithMany(p => p.Cervezas)
                .HasForeignKey(d => d.IdEstilo)
                .HasConstraintName("FK_Cerveza_Estilo");

            entity.HasOne(d => d.Marca).WithMany(p => p.Cervezas)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cerveza_Marca");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Pais");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK_Cuenta_Tarjeta");

            entity.HasOne(d => d.TipoCuenta).WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_TipoCuenta");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_Usuario");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estilo>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Imagen)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.Property(e => e.Documento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Expediente1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Expediente");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaExpediente).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.Acto).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdActo)
                .HasConstraintName("FK_Expediente_Acto");

            entity.HasOne(d => d.Caratula).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdCaratula)
                .HasConstraintName("FK_Expediente_Caratula");

            entity.HasOne(d => d.SituacionRevista).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdSituacionRevista)
                .HasConstraintName("FK_Expediente_SituacionRevista");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.Property(e => e.Valor).HasColumnType("numeric(25, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Ingreso_Usuario");

            entity.HasOne(d => d.CategoriaIngreso).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdCategoriaIngreso)
                .HasConstraintName("FK_Ingreso_CategoriaIngreso");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Imagen)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Imagen)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.FechaPago).HasColumnType("date");
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("numeric(25, 2)");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registro_Cuenta");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Registro_Empresa");

            entity.HasOne(d => d.RegistroVinculado).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdRegistroVinculado)
                .HasConstraintName("FK_Registro_RegistroVinculado");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Registro_Usuario");

            entity.HasOne(d => d.CategoriaGasto).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdCategoriaGasto)
                .HasConstraintName("FK_Registro_CategoriaGasto");

            entity.HasOne(d => d.Suscripcion).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdSuscripcion)
                .HasConstraintName("FK_Registro_Suscripcion");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Registro_Usuario");
        });

        modelBuilder.Entity<RegistroVinculado>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValorFinal).HasColumnType("numeric(25, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.RegistrosVinculados)
               .HasForeignKey(d => d.IdUsuario)
               .HasConstraintName("FK_RegistroVinculado_Usuario");
        });

        modelBuilder.Entity<Sistema>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SituacionRevista>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Suscripcion>(entity =>
        {
            entity.Property(e => e.FechaDesde).HasColumnType("date");
            entity.Property(e => e.FechaHasta).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValorActual).HasColumnType("numeric(25, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Suscripcion_Usuario");

            entity.HasOne(d => d.CategoriaGasto).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.IdCategoriaGasto)
                .HasConstraintName("FK_Suscripcion_CategoriaGasto");

        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Vencimiento)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Banco).WithMany(p => p.Tarjetas)
                .HasForeignKey(d => d.IdBanco)
                .HasConstraintName("FK_Tarjeta_Banco");

            entity.HasOne(d => d.TipoTarjeta).WithMany(p => p.Tarjetas)
                .HasForeignKey(d => d.IdTipoTarjeta)
                .HasConstraintName("FK_Tarjeta_TipoTarjeta");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Tarjetas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Tarjeta_Usuario");
        });

        modelBuilder.Entity<TipoCuenta>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoTarjeta>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Login)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .IsUnicode(false);

            entity.HasOne(d => d.Perfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK_Usuario_Perfil");
        });

        modelBuilder.Entity<UsuarioSistema>(entity =>
        {
            entity.HasOne(d => d.Sistema).WithMany(p => p.UsuariosSistema)
                .HasForeignKey(d => d.IdSistema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSistema_Sistema");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosSistema)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSistema_Usuario");
        });

        modelBuilder.Entity<ParametrosSistema>(entity =>
        {
            entity.HasOne(d => d.Sistema).WithOne(p => p.ParametrosSistema)
                .HasForeignKey<ParametrosSistema>(d => d.IdSistema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ParametrosSistema_Sistema");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
