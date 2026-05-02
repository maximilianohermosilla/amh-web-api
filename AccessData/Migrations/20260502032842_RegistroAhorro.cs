using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class RegistroAhorro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroAhorro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IdCuenta = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    Diferencia = table.Column<decimal>(type: "numeric(25,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroAhorro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroAhorro_Cuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroAhorro_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAhorro_IdCuenta",
                table: "RegistroAhorro",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAhorro_IdUsuario",
                table: "RegistroAhorro",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroAhorro");
        }
    }
}
