using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Carreras_relaciones_pool4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Actitud_ActitudId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_IdCarrera",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_IdCarrera",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Habilidad_HabilidadId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Carrera_IdCarrera",
                table: "InteresesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Interes_InteresId",
                table: "InteresesXCarrera");

            migrationBuilder.RenameColumn(
                name: "InteresId",
                table: "InteresesXCarrera",
                newName: "CarreraId");

            migrationBuilder.RenameIndex(
                name: "IX_InteresesXCarrera_InteresId",
                table: "InteresesXCarrera",
                newName: "IX_InteresesXCarrera_CarreraId");

            migrationBuilder.RenameColumn(
                name: "HabilidadId",
                table: "HabilidadesXCarrera",
                newName: "CarreraId");

            migrationBuilder.RenameIndex(
                name: "IX_HabilidadesXCarrera_HabilidadId",
                table: "HabilidadesXCarrera",
                newName: "IX_HabilidadesXCarrera_CarreraId");

            migrationBuilder.RenameColumn(
                name: "ActitudId",
                table: "ActitudesXCarrera",
                newName: "CarreraId");

            migrationBuilder.RenameIndex(
                name: "IX_ActitudesXCarrera_ActitudId",
                table: "ActitudesXCarrera",
                newName: "IX_ActitudesXCarrera_CarreraId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_IdCarrera",
                table: "ActitudesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_CarreraId",
                table: "HabilidadesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_IdCarrera",
                table: "HabilidadesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Carrera_CarreraId",
                table: "InteresesXCarrera",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Carrera_IdCarrera",
                table: "InteresesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_IdCarrera",
                table: "ActitudesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_CarreraId",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_IdCarrera",
                table: "HabilidadesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Carrera_CarreraId",
                table: "InteresesXCarrera");

            migrationBuilder.DropForeignKey(
                name: "FK_InteresesXCarrera_Carrera_IdCarrera",
                table: "InteresesXCarrera");

            migrationBuilder.RenameColumn(
                name: "CarreraId",
                table: "InteresesXCarrera",
                newName: "InteresId");

            migrationBuilder.RenameIndex(
                name: "IX_InteresesXCarrera_CarreraId",
                table: "InteresesXCarrera",
                newName: "IX_InteresesXCarrera_InteresId");

            migrationBuilder.RenameColumn(
                name: "CarreraId",
                table: "HabilidadesXCarrera",
                newName: "HabilidadId");

            migrationBuilder.RenameIndex(
                name: "IX_HabilidadesXCarrera_CarreraId",
                table: "HabilidadesXCarrera",
                newName: "IX_HabilidadesXCarrera_HabilidadId");

            migrationBuilder.RenameColumn(
                name: "CarreraId",
                table: "ActitudesXCarrera",
                newName: "ActitudId");

            migrationBuilder.RenameIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera",
                newName: "IX_ActitudesXCarrera_ActitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Actitud_ActitudId",
                table: "ActitudesXCarrera",
                column: "ActitudId",
                principalTable: "Actitud",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActitudesXCarrera_Carrera_IdCarrera",
                table: "ActitudesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Carrera_IdCarrera",
                table: "HabilidadesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabilidadesXCarrera_Habilidad_HabilidadId",
                table: "HabilidadesXCarrera",
                column: "HabilidadId",
                principalTable: "Habilidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Carrera_IdCarrera",
                table: "InteresesXCarrera",
                column: "IdCarrera",
                principalTable: "Carrera",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteresesXCarrera_Interes_InteresId",
                table: "InteresesXCarrera",
                column: "InteresId",
                principalTable: "Interes",
                principalColumn: "Id");
        }
    }
}
