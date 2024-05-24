using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class GestorGastos5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "RegistroVinculado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroVinculado_IdUsuario",
                table: "RegistroVinculado",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroVinculado_Usuario",
                table: "RegistroVinculado",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroVinculado_Usuario",
                table: "RegistroVinculado");

            migrationBuilder.DropIndex(
                name: "IX_RegistroVinculado_IdUsuario",
                table: "RegistroVinculado");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "RegistroVinculado");
        }
    }
}
