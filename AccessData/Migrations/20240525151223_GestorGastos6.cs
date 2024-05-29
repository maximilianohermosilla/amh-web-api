using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class GestorGastos6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CategoriaIngreso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "CategoriaIngreso",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CategoriaGasto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icono",
                table: "CategoriaGasto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CategoriaIngreso");

            migrationBuilder.DropColumn(
                name: "Icono",
                table: "CategoriaIngreso");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "CategoriaGasto");

            migrationBuilder.DropColumn(
                name: "Icono",
                table: "CategoriaGasto");
        }
    }
}
