using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Agregarnacionalidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdNacionalidad",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdNacionalidad2",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nacionalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdNacionalidad",
                table: "AspNetUsers",
                column: "IdNacionalidad");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdNacionalidad2",
                table: "AspNetUsers",
                column: "IdNacionalidad2");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NacionalidadId",
                table: "AspNetUsers",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Nacionalidad_Descripcion",
                table: "Nacionalidad",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_IdNacionalidad",
                table: "AspNetUsers",
                column: "IdNacionalidad",
                principalTable: "Nacionalidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_IdNacionalidad2",
                table: "AspNetUsers",
                column: "IdNacionalidad2",
                principalTable: "Nacionalidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_NacionalidadId",
                table: "AspNetUsers",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_IdNacionalidad",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_IdNacionalidad2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Nacionalidad_NacionalidadId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Nacionalidad");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdNacionalidad",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdNacionalidad2",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NacionalidadId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdNacionalidad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdNacionalidad2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "AspNetUsers");
        }
    }
}
