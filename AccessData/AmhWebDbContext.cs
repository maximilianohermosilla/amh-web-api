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
    public virtual DbSet<Empresa> Empresa { get; set; }
    public virtual DbSet<Registro> Registro { get; set; }
    public virtual DbSet<RegistroVinculado> RegistroVinculado { get; set; }
    public virtual DbSet<Tarjeta> Tarjeta { get; set; }
    public virtual DbSet<TipoTarjeta> TipoTarjeta { get; set; }
    public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
    public virtual DbSet<Suscripcion> Suscripcion { get; set; }

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
    public virtual DbSet<Usuario> Usuario { get; set; }
    public virtual DbSet<UsuarioSistema> UsuarioSistema { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost; Database=AmhWebAPI; Trusted_Connection=True; TrustServerCertificate=True");
    }

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

        modelBuilder.Entity<Caratula>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cerveza>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones).IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Cerveza)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_Cerveza_Ciudad");

            entity.HasOne(d => d.IdEstiloNavigation).WithMany(p => p.Cerveza)
                .HasForeignKey(d => d.IdEstilo)
                .HasConstraintName("FK_Cerveza_Estilo");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Cerveza)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cerveza_Marca");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Ciudad)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Pais");
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTarjeta)
                .HasConstraintName("FK_Cuenta_Tarjeta");

            entity.HasOne(d => d.IdTipoCuentaNavigation).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.IdTipoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cuenta_TipoCuenta");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cuenta)
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

            entity.HasOne(d => d.IdActoNavigation).WithMany(p => p.Expediente)
                .HasForeignKey(d => d.IdActo)
                .HasConstraintName("FK_Expediente_Acto");

            entity.HasOne(d => d.IdCaratulaNavigation).WithMany(p => p.Expediente)
                .HasForeignKey(d => d.IdCaratula)
                .HasConstraintName("FK_Expediente_Caratula");

            entity.HasOne(d => d.IdSituacionRevistaNavigation).WithMany(p => p.Expediente)
                .HasForeignKey(d => d.IdSituacionRevista)
                .HasConstraintName("FK_Expediente_SituacionRevista");
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

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Registro)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registro_Cuenta");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Registro)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Registro_Empresa");

            entity.HasOne(d => d.IdRegistroVinculadoNavigation).WithMany(p => p.Registro)
                .HasForeignKey(d => d.IdRegistroVinculado)
                .HasConstraintName("FK_Registro_RegistroVinculado");

            entity.HasOne(d => d.IdSuscripcionNavigation).WithMany(p => p.Registro)
                .HasForeignKey(d => d.IdSuscripcion)
                .HasConstraintName("FK_Registro_Suscripcion");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Registro)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Registro_Usuario");
        });

        modelBuilder.Entity<RegistroVinculado>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValorFinal).HasColumnType("numeric(25, 2)");
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

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Suscripcion)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Suscripcion_Usuario");
        });

        modelBuilder.Entity<Tarjeta>(entity =>
        {
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Vencimiento)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdBanco)
                .HasConstraintName("FK_Tarjeta_Banco");

            entity.HasOne(d => d.IdTipoTarjetaNavigation).WithMany(p => p.Tarjeta)
                .HasForeignKey(d => d.IdTipoTarjeta)
                .HasConstraintName("FK_Tarjeta_TipoTarjeta");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tarjeta)
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

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK_Usuario_Perfil");
        });

        modelBuilder.Entity<UsuarioSistema>(entity =>
        {
            entity.HasOne(d => d.IdSistemaNavigation).WithMany(p => p.UsuarioSistema)
                .HasForeignKey(d => d.IdSistema)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSistema_Sistema");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioSistema)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSistema_Usuario");
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
