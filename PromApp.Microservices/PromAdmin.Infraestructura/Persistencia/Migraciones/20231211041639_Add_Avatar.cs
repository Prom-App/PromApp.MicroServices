using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Add_Avatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Nacionalidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Nacionalidad",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAvatar",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidad_PaisId",
                table: "Nacionalidad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdAvatar",
                table: "AspNetUsers",
                column: "IdAvatar");

            migrationBuilder.CreateIndex(
                name: "IX_Avatar_Nombre",
                table: "Avatar",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Avatar_IdAvatar",
                table: "AspNetUsers",
                column: "IdAvatar",
                principalTable: "Avatar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nacionalidad_Pais_PaisId",
                table: "Nacionalidad",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Avatar_IdAvatar",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Nacionalidad_Pais_PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropTable(
                name: "Avatar");

            migrationBuilder.DropIndex(
                name: "IX_Nacionalidad_PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdAvatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Nacionalidad");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Nacionalidad");

            migrationBuilder.DropColumn(
                name: "IdAvatar",
                table: "AspNetUsers");
        }
    }
}
