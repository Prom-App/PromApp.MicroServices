using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Add_Template : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colegio_Pais_PaisId",
                table: "Colegio");

            migrationBuilder.DropIndex(
                name: "IX_Colegio_PaisId",
                table: "Colegio");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Colegio");

            migrationBuilder.AddColumn<string>(
                name: "Ayuda",
                table: "Pregunta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AyudaGrafica",
                table: "Pregunta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colegio_IdPais",
                table: "Colegio",
                column: "IdPais");

            migrationBuilder.AddForeignKey(
                name: "FK_Colegio_Pais_IdPais",
                table: "Colegio",
                column: "IdPais",
                principalTable: "Pais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colegio_Pais_IdPais",
                table: "Colegio");

            migrationBuilder.DropIndex(
                name: "IX_Colegio_IdPais",
                table: "Colegio");

            migrationBuilder.DropColumn(
                name: "Ayuda",
                table: "Pregunta");

            migrationBuilder.DropColumn(
                name: "AyudaGrafica",
                table: "Pregunta");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Colegio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colegio_PaisId",
                table: "Colegio",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colegio_Pais_PaisId",
                table: "Colegio",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }
    }
}
