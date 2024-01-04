using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Add_MBTI_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MBTIResutlado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTestXUsuario = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extroversion = table.Column<int>(type: "int", nullable: false),
                    Introversion = table.Column<int>(type: "int", nullable: false),
                    Sensing = table.Column<int>(type: "int", nullable: false),
                    Intuition = table.Column<int>(type: "int", nullable: false),
                    Thinking = table.Column<int>(type: "int", nullable: false),
                    Feeling = table.Column<int>(type: "int", nullable: false),
                    Judging = table.Column<int>(type: "int", nullable: false),
                    Perceiving = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBTIResutlado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado",
                columns: new[] { "IdUsuario", "IdTestXUsuario" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBTIResutlado");
        }
    }
}
