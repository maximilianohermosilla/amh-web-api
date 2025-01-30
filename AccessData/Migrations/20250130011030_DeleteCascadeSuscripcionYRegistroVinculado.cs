using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCascadeSuscripcionYRegistroVinculado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Cuenta",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_RegistroVinculado",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Suscripcion",
                table: "Registro");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Cuenta",
                table: "Registro",
                column: "IdCuenta",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_RegistroVinculado",
                table: "Registro",
                column: "IdRegistroVinculado",
                principalTable: "RegistroVinculado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Suscripcion",
                table: "Registro",
                column: "IdSuscripcion",
                principalTable: "Suscripcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Cuenta",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_RegistroVinculado",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Suscripcion",
                table: "Registro");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Cuenta",
                table: "Registro",
                column: "IdCuenta",
                principalTable: "Cuenta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_RegistroVinculado",
                table: "Registro",
                column: "IdRegistroVinculado",
                principalTable: "RegistroVinculado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Suscripcion",
                table: "Registro",
                column: "IdSuscripcion",
                principalTable: "Suscripcion",
                principalColumn: "Id");
        }
    }
}
