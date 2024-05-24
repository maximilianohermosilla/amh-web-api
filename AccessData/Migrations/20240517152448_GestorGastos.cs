using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class GestorGastos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_Usuario_UsuarioId",
                table: "Ingreso");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_CategoriaGasto_CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripcion_CategoriaGasto_CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Suscripcion_CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Registro_CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_UsuarioId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropColumn(
                name: "CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ingreso");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ingreso",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ingreso",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripcion_IdCategoriaGasto",
                table: "Suscripcion",
                column: "IdCategoriaGasto");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCategoriaGasto",
                table: "Registro",
                column: "IdCategoriaGasto");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_IdUsuario",
                table: "Ingreso",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_Usuario",
                table: "Ingreso",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_CategoriaGastoId",
                table: "Registro",
                column: "IdCategoriaGasto",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripcion_CategoriaGastoId",
                table: "Suscripcion",
                column: "IdCategoriaGasto",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Tarjeta",
                table: "Ingreso");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_CategoriaGasto",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_CategoriaGasto",
                table: "Suscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Suscripcion_IdCategoriaGasto",
                table: "Suscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Registro_IdCategoriaGasto",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_IdUsuario",
                table: "Ingreso");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaGastoId",
                table: "Suscripcion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaGastoId",
                table: "Registro",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Ingreso",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suscripcion_CategoriaGastoId",
                table: "Suscripcion",
                column: "CategoriaGastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_CategoriaGastoId",
                table: "Registro",
                column: "CategoriaGastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_UsuarioId",
                table: "Ingreso",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_Usuario_UsuarioId",
                table: "Ingreso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_CategoriaGasto_CategoriaGastoId",
                table: "Registro",
                column: "CategoriaGastoId",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripcion_CategoriaGasto_CategoriaGastoId",
                table: "Suscripcion",
                column: "CategoriaGastoId",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");
        }
    }
}
