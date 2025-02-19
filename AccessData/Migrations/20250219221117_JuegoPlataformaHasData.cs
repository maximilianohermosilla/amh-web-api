using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccessData.Migrations
{
    /// <inheritdoc />
    public partial class JuegoPlataformaHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Juego_JuegoId",
                table: "JuegoPlataforma");

            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Plataforma_PlataformaId",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_JuegoId",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_PlataformaId",
                table: "JuegoPlataforma");

            migrationBuilder.DropColumn(
                name: "JuegoId",
                table: "JuegoPlataforma");

            migrationBuilder.DropColumn(
                name: "PlataformaId",
                table: "JuegoPlataforma");

            migrationBuilder.InsertData(
                table: "Plataforma",
                columns: new[] { "Id", "Descripcion", "Imagen", "Nombre", "Url" },
                values: new object[,]
                {
                    { 1, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002075/mayigamescollection/uqaf9wo4vmj4rt5rerdu.png", "Steam", "" },
                    { 2, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002075/mayigamescollection/cmmuk1h9joqlqxv7acbz.png", "Epic Games", "" },
                    { 3, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002075/mayigamescollection/gex8ydp24waqkyragrbn.png", "Prime Gaming", "" },
                    { 4, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002075/mayigamescollection/dkoobr00tb3lhkrlao7w.png", "GOG", "" },
                    { 5, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002547/mayigamescollection/tdmnprwnvn5l6dbm3cbr.png", "Ubisoft", "" },
                    { 6, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740002543/mayigamescollection/bj7m3e8q1jffp64vvyaf.png", "EA Play", "" },
                    { 7, "", "https://res.cloudinary.com/dundcrnii/image/upload/v1740003046/mayigamescollection/dmlxexzqfcjkrqj30tid.png", "Rockstar", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_IdJuego",
                table: "JuegoPlataforma",
                column: "IdJuego");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_IdPlataforma",
                table: "JuegoPlataforma",
                column: "IdPlataforma");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Juego",
                table: "JuegoPlataforma",
                column: "IdJuego",
                principalTable: "Juego",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Plataforma",
                table: "JuegoPlataforma",
                column: "IdPlataforma",
                principalTable: "Plataforma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Juego",
                table: "JuegoPlataforma");

            migrationBuilder.DropForeignKey(
                name: "FK_JuegoPlataforma_Plataforma",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_IdJuego",
                table: "JuegoPlataforma");

            migrationBuilder.DropIndex(
                name: "IX_JuegoPlataforma_IdPlataforma",
                table: "JuegoPlataforma");

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Plataforma",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "JuegoId",
                table: "JuegoPlataforma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlataformaId",
                table: "JuegoPlataforma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_JuegoId",
                table: "JuegoPlataforma",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_JuegoPlataforma_PlataformaId",
                table: "JuegoPlataforma",
                column: "PlataformaId");

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Juego_JuegoId",
                table: "JuegoPlataforma",
                column: "JuegoId",
                principalTable: "Juego",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JuegoPlataforma_Plataforma_PlataformaId",
                table: "JuegoPlataforma",
                column: "PlataformaId",
                principalTable: "Plataforma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
