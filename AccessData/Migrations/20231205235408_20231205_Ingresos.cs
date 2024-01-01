using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class _20231205_Ingresos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaGastoId",
                table: "Suscripcion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaGasto",
                table: "Suscripcion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaGastoId",
                table: "Registro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaGasto",
                table: "Registro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Registro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaGasto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaGasto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suscripcion_CategoriaGastoId",
                table: "Suscripcion",
                column: "CategoriaGastoId");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_CategoriaGastoId",
                table: "Registro",
                column: "CategoriaGastoId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_CategoriaGasto_CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripcion_CategoriaGasto_CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropTable(
                name: "CategoriaGasto");

            migrationBuilder.DropIndex(
                name: "IX_Suscripcion_CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropIndex(
                name: "IX_Registro_CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "CategoriaGastoId",
                table: "Suscripcion");

            migrationBuilder.DropColumn(
                name: "IdCategoriaGasto",
                table: "Suscripcion");

            migrationBuilder.DropColumn(
                name: "CategoriaGastoId",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "IdCategoriaGasto",
                table: "Registro");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Registro");
        }
    }
}
