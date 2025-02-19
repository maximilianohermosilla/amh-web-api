using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class JuegoPlataformaHasDataIdUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Usuario_UsuarioId",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_UsuarioId",
                table: "JuegoPlataforma");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "JuegoPlataforma");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_IdUsuario",
                table: "JuegoPlataforma",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Usuario",
                table: "JuegoPlataforma",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Usuario",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_IdUsuario",
                table: "JuegoPlataforma");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "JuegoPlataforma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_UsuarioId",
                table: "JuegoPlataforma",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Usuario_UsuarioId",
                table: "JuegoPlataforma",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
