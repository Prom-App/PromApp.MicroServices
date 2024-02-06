using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Carrera_Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "InteresesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "HabilidadesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "ActitudesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InteresesXCarrera_CarreraId",
                table: "InteresesXCarrera",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadesXCarrera_CarreraId",
                table: "HabilidadesXCarrera",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_CarreraId",
                table: "HabilidadesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Carrera_CarreraId",
                table: "InteresesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_CarreraId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Carrera_CarreraId",
                table: "InteresesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_InteresesXCarrera_CarreraId",
                table: "InteresesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_HabilidadesXCarrera_CarreraId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "InteresesXCarrera");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "ActitudesXCarrera");
        }
    }
}
