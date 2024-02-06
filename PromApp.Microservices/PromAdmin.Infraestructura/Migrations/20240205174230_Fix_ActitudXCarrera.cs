using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Fix_ActitudXCarrera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Habilidad_HabilidadId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Interes_InteresId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_ActitudesXCarrera_HabilidadId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_ActitudesXCarrera_InteresId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropColumn(
                name: "CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropColumn(
                name: "HabilidadId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropColumn(
                name: "InteresId",
                table: "ActitudesXCarrera");

            migrationBuilder.AddColumn<int>(
                name: "InteresId",
                table: "InteresesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabilidadId",
                table: "HabilidadesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InteresesXCarrera_InteresId",
                table: "InteresesXCarrera",
                column: "InteresId");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadesXCarrera_HabilidadId",
                table: "HabilidadesXCarrera",
                column: "HabilidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Habilidad_HabilidadId",
                table: "HabilidadesXCarrera",
                column: "HabilidadId",
                principalTable: "Habilidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Interes_InteresId",
                table: "InteresesXCarrera",
                column: "InteresId",
                principalTable: "Interes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Habilidad_HabilidadId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Interes_InteresId",
                table: "InteresesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_InteresesXCarrera_InteresId",
                table: "InteresesXCarrera");

            migrationBuilder.DropIndex(
                name: "IX_HabilidadesXCarrera_HabilidadId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropColumn(
                name: "InteresId",
                table: "InteresesXCarrera");

            migrationBuilder.DropColumn(
                name: "HabilidadId",
                table: "HabilidadesXCarrera");

            migrationBuilder.AddColumn<int>(
                name: "CarreraId",
                table: "ActitudesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabilidadId",
                table: "ActitudesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InteresId",
                table: "ActitudesXCarrera",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_HabilidadId",
                table: "ActitudesXCarrera",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_InteresId",
                table: "ActitudesXCarrera",
                column: "InteresId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Habilidad_HabilidadId",
                table: "ActitudesXCarrera",
                column: "HabilidadId",
                principalTable: "Habilidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Interes_InteresId",
                table: "ActitudesXCarrera",
                column: "InteresId",
                principalTable: "Interes",
                principalColumn: "Id");
        }
    }
}
