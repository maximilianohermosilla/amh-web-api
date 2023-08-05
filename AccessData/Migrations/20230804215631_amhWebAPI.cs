using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class amhWebAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caratula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caratula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estilo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroVinculado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "numeric(25,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVinculado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacionRevista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacionRevista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTarjeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Pais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Correo = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true),
                    IdPerfil = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Expediente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Documento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdCaratula = table.Column<int>(type: "int", nullable: true),
                    IdActo = table.Column<int>(type: "int", nullable: true),
                    IdSituacionRevista = table.Column<int>(type: "int", nullable: true),
                    FechaExpediente = table.Column<DateTime>(type: "date", nullable: true),
                    FirmadoSumario = table.Column<bool>(type: "bit", nullable: true),
                    FirmadoLaborales = table.Column<bool>(type: "bit", nullable: true),
                    EnviadoLaborales = table.Column<bool>(type: "bit", nullable: true),
                    Avisado = table.Column<bool>(type: "bit", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expediente_Acto",
                        column: x => x.IdActo,
                        principalTable: "Acto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expediente_Caratula",
                        column: x => x.IdCaratula,
                        principalTable: "Caratula",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Expediente_SituacionRevista",
                        column: x => x.IdSituacionRevista,
                        principalTable: "SituacionRevista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cerveza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IBU = table.Column<double>(type: "float", nullable: true),
                    Alcohol = table.Column<double>(type: "float", nullable: true),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdEstilo = table.Column<int>(type: "int", nullable: true),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Contenido = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cerveza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cerveza_Ciudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cerveza_Estilo",
                        column: x => x.IdEstilo,
                        principalTable: "Estilo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cerveza_Marca",
                        column: x => x.IdMarca,
                        principalTable: "Marca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suscripcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "date", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "date", nullable: true),
                    ValorActual = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suscripcion_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Vencimiento = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    IdBanco = table.Column<int>(type: "int", nullable: true),
                    IdTipoTarjeta = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Banco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarjeta_TipoTarjeta",
                        column: x => x.IdTipoTarjeta,
                        principalTable: "TipoTarjeta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tarjeta_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSistema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdSistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSistema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSistema_Sistema",
                        column: x => x.IdSistema,
                        principalTable: "Sistema",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioSistema_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdTipoCuenta = table.Column<int>(type: "int", nullable: false),
                    IdTarjeta = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Tarjeta",
                        column: x => x.IdTarjeta,
                        principalTable: "Tarjeta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuenta_TipoCuenta",
                        column: x => x.IdTipoCuenta,
                        principalTable: "TipoCuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cuenta_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdSuscripcion = table.Column<int>(type: "int", nullable: true),
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdRegistroVinculado = table.Column<int>(type: "int", nullable: true),
                    NumeroCuota = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Pagado = table.Column<bool>(type: "bit", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registro_Cuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_Empresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_RegistroVinculado",
                        column: x => x.IdRegistroVinculado,
                        principalTable: "RegistroVinculado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_Suscripcion",
                        column: x => x.IdSuscripcion,
                        principalTable: "Suscripcion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Registro_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cerveza_IdCiudad",
                table: "Cerveza",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Cerveza_IdEstilo",
                table: "Cerveza",
                column: "IdEstilo");

            migrationBuilder.CreateIndex(
                name: "IX_Cerveza_IdMarca",
                table: "Cerveza",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdPais",
                table: "Ciudad",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdTarjeta",
                table: "Cuenta",
                column: "IdTarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdTipoCuenta",
                table: "Cuenta",
                column: "IdTipoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_IdUsuario",
                table: "Cuenta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_IdActo",
                table: "Expediente",
                column: "IdActo");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_IdCaratula",
                table: "Expediente",
                column: "IdCaratula");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_IdSituacionRevista",
                table: "Expediente",
                column: "IdSituacionRevista");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCuenta",
                table: "Registro",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdEmpresa",
                table: "Registro",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdRegistroVinculado",
                table: "Registro",
                column: "IdRegistroVinculado");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdSuscripcion",
                table: "Registro",
                column: "IdSuscripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdUsuario",
                table: "Registro",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripcion_IdUsuario",
                table: "Suscripcion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_IdBanco",
                table: "Tarjeta",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_IdTipoTarjeta",
                table: "Tarjeta",
                column: "IdTipoTarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_IdUsuario",
                table: "Tarjeta",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSistema_IdSistema",
                table: "UsuarioSistema",
                column: "IdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSistema_IdUsuario",
                table: "UsuarioSistema",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cerveza");

            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "UsuarioSistema");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Estilo");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Acto");

            migrationBuilder.DropTable(
                name: "Caratula");

            migrationBuilder.DropTable(
                name: "SituacionRevista");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "RegistroVinculado");

            migrationBuilder.DropTable(
                name: "Suscripcion");

            migrationBuilder.DropTable(
                name: "Sistema");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "TipoCuenta");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "TipoTarjeta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
