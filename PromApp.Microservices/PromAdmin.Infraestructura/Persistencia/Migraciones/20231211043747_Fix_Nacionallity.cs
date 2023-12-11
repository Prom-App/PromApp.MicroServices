using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_Nacionallity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_NacionalidadId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Nacionalidad_Pais_PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_Nacionalidad_PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NacionalidadId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidad_IdPais",
                table: "Nacionalidad",
                column: "IdPais",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nacionalidad_Pais_IdPais",
                table: "Nacionalidad",
                column: "IdPais",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nacionalidad_Pais_IdPais",
                table: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_Nacionalidad_IdPais",
                table: "Nacionalidad");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Nacionalidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidad_PaisId",
                table: "Nacionalidad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NacionalidadId",
                table: "AspNetUsers",
                column: "NacionalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_NacionalidadId",
                table: "AspNetUsers",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nacionalidad_Pais_PaisId",
                table: "Nacionalidad",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }
    }
}
