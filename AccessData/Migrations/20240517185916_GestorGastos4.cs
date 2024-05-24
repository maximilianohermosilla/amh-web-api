using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class GestorGastos4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Registro_CategoriaGasto",
            //    table: "Registro");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoriaIngreso",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaGasto",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CategoriaIngreso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaIngreso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_IdCategoriaIngreso",
                table: "Ingreso",
                column: "IdCategoriaIngreso");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingreso_CategoriaIngreso",
                table: "Ingreso",
                column: "IdCategoriaIngreso",
                principalTable: "CategoriaIngreso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suscripcion_CategoriaGasto",
                table: "Suscripcion",
                column: "IdCategoriaGasto",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingreso_CategoriaIngreso",
                table: "Ingreso");

            migrationBuilder.DropForeignKey(
                name: "FK_Suscripcion_CategoriaGasto",
                table: "Suscripcion");

            migrationBuilder.DropTable(
                name: "CategoriaIngreso");

            migrationBuilder.DropIndex(
                name: "IX_Ingreso_IdCategoriaIngreso",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "IdCategoriaIngreso",
                table: "Ingreso");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "CategoriaGasto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_CategoriaGasto",
                table: "Registro",
                column: "IdCategoriaGasto",
                principalTable: "CategoriaGasto",
                principalColumn: "Id");
        }
    }
}
