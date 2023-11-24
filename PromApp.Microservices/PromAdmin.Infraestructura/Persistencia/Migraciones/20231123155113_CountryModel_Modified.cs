using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class CountryModel_Modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_AspNetUsers_IdUsuario",
                table: "Contacto");

            migrationBuilder.RenameColumn(
                name: "Iso2",
                table: "Departamento",
                newName: "Iso3");

            migrationBuilder.RenameColumn(
                name: "Iso2",
                table: "Ciudad",
                newName: "Abreviatura");

            migrationBuilder.AddColumn<string>(
                name: "CodigoTelefonico",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iso3",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Moneda",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_AspNetUsers_IdUsuario",
                table: "Contacto",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_AspNetUsers_IdUsuario",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "CodigoTelefonico",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "Iso3",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "Pais");

            migrationBuilder.RenameColumn(
                name: "Iso3",
                table: "Departamento",
                newName: "Iso2");

            migrationBuilder.RenameColumn(
                name: "Abreviatura",
                table: "Ciudad",
                newName: "Iso2");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_AspNetUsers_IdUsuario",
                table: "Contacto",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
