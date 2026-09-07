using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class AddParametroConfiguracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametroConfiguracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSistema = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Valor = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroConfiguracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroConfiguracion_Sistema",
                        column: x => x.IdSistema,
                        principalTable: "Sistema",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParametroConfiguracion_IdSistema",
                table: "ParametroConfiguracion",
                column: "IdSistema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametroConfiguracion");
        }
    }
}
