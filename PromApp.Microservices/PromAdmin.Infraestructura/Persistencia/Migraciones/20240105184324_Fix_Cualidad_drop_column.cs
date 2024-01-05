using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_Cualidad_drop_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.DropIndex(
                name: "IX_CualidadXPersonalidad_CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.DropColumn(
                name: "CualidadId",
                table: "CualidadXPersonalidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CualidadId",
                table: "CualidadXPersonalidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CualidadXPersonalidad_CualidadId",
                table: "CualidadXPersonalidad",
                column: "CualidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                table: "CualidadXPersonalidad",
                column: "CualidadId",
                principalTable: "Cualidad",
                principalColumn: "Id");
        }
    }
}
