using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class GestorGastos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cuenta_Tarjeta",
            //    table: "Ingreso");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Ingreso_Usuario",
            //    table: "Ingreso",
            //    column: "IdUsuario",
            //    principalTable: "Usuario",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_Usuario",
                table: "Ingreso");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Tarjeta",
                table: "Ingreso",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
