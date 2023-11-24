using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_Foreign_Ciudad_Demografia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Demografia_IdDepartamento",
                table: "Ciudad");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDemografia",
                table: "Ciudad",
                column: "IdDemografia");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Demografia_IdDemografia",
                table: "Ciudad",
                column: "IdDemografia",
                principalTable: "Demografia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Demografia_IdDemografia",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_IdDemografia",
                table: "Ciudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Demografia_IdDepartamento",
                table: "Ciudad",
                column: "IdDepartamento",
                principalTable: "Demografia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
