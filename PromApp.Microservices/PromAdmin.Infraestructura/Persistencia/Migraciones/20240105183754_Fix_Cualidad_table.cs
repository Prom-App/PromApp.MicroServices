using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_Cualidad_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CualidadXPersonalidad_Personalidad_PersonalidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.RenameColumn(
                name: "PersonalidadId",
                table: "CualidadXPersonalidad",
                newName: "CualidadId");

            migrationBuilder.RenameIndex(
                name: "IX_CualidadXPersonalidad_PersonalidadId",
                table: "CualidadXPersonalidad",
                newName: "IX_CualidadXPersonalidad_CualidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                table: "CualidadXPersonalidad",
                column: "CualidadId",
                principalTable: "Cualidad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.RenameColumn(
                name: "CualidadId",
                table: "CualidadXPersonalidad",
                newName: "PersonalidadId");

            migrationBuilder.RenameIndex(
                name: "IX_CualidadXPersonalidad_CualidadId",
                table: "CualidadXPersonalidad",
                newName: "IX_CualidadXPersonalidad_PersonalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CualidadXPersonalidad_Personalidad_PersonalidadId",
                table: "CualidadXPersonalidad",
                column: "PersonalidadId",
                principalTable: "Personalidad",
                principalColumn: "Id");
        }
    }
}
