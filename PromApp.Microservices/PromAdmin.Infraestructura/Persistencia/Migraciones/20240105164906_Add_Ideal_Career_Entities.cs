using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Add_Ideal_Career_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPais",
                table: "Colegio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Colegio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradoEscolar",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreActitud = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actitud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrerasEvitar",
                columns: table => new
                {
                    IdPersonalidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrerasEvitar", x => new { x.IdPersonalidad, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_CarrerasEvitar_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrerasEvitar_Personalidad_IdPersonalidad",
                        column: x => x.IdPersonalidad,
                        principalTable: "Personalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrerasFuturo",
                columns: table => new
                {
                    IdPersonalidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrerasFuturo", x => new { x.IdPersonalidad, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_CarrerasFuturo_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrerasFuturo_Personalidad_IdPersonalidad",
                        column: x => x.IdPersonalidad,
                        principalTable: "Personalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrerasRecomendadas",
                columns: table => new
                {
                    IdPersonalidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrerasRecomendadas", x => new { x.IdPersonalidad, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_CarrerasRecomendadas_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrerasRecomendadas_Personalidad_IdPersonalidad",
                        column: x => x.IdPersonalidad,
                        principalTable: "Personalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habilidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHabilidad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreInteres = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadesXCarrera",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdHabilidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadesXCarrera", x => new { x.IdHabilidad, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_HabilidadesXCarrera_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadesXCarrera_Habilidad_IdHabilidad",
                        column: x => x.IdHabilidad,
                        principalTable: "Habilidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActitudesXCarrera",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdActitud = table.Column<int>(type: "int", nullable: false),
                    ActitudId = table.Column<int>(type: "int", nullable: true),
                    CarreraId = table.Column<int>(type: "int", nullable: true),
                    HabilidadId = table.Column<int>(type: "int", nullable: true),
                    InteresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActitudesXCarrera", x => new { x.IdActitud, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Actitud_ActitudId",
                        column: x => x.ActitudId,
                        principalTable: "Actitud",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Actitud_IdActitud",
                        column: x => x.IdActitud,
                        principalTable: "Actitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Carrera_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carrera",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Habilidad_HabilidadId",
                        column: x => x.HabilidadId,
                        principalTable: "Habilidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActitudesXCarrera_Interes_InteresId",
                        column: x => x.InteresId,
                        principalTable: "Interes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InteresesXCarrera",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdInteres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteresesXCarrera", x => new { x.IdInteres, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_InteresesXCarrera_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteresesXCarrera_Interes_IdInteres",
                        column: x => x.IdInteres,
                        principalTable: "Interes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colegio_PaisId",
                table: "Colegio",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Actitud_NombreActitud",
                table: "Actitud",
                column: "NombreActitud",
                unique: true,
                filter: "[NombreActitud] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_ActitudId",
                table: "ActitudesXCarrera",
                column: "ActitudId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_CarreraId",
                table: "ActitudesXCarrera",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_HabilidadId",
                table: "ActitudesXCarrera",
                column: "HabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_IdCarrera",
                table: "ActitudesXCarrera",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_ActitudesXCarrera_InteresId",
                table: "ActitudesXCarrera",
                column: "InteresId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrerasEvitar_IdCarrera",
                table: "CarrerasEvitar",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_CarrerasFuturo_IdCarrera",
                table: "CarrerasFuturo",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_CarrerasRecomendadas_IdCarrera",
                table: "CarrerasRecomendadas",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidad_NombreHabilidad",
                table: "Habilidad",
                column: "NombreHabilidad",
                unique: true,
                filter: "[NombreHabilidad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadesXCarrera_IdCarrera",
                table: "HabilidadesXCarrera",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Interes_NombreInteres",
                table: "Interes",
                column: "NombreInteres",
                unique: true,
                filter: "[NombreInteres] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InteresesXCarrera_IdCarrera",
                table: "InteresesXCarrera",
                column: "IdCarrera");

            migrationBuilder.AddForeignKey(
                name: "FK_Colegio_Pais_PaisId",
                table: "Colegio",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colegio_Pais_PaisId",
                table: "Colegio");

            migrationBuilder.DropTable(
                name: "ActitudesXCarrera");

            migrationBuilder.DropTable(
                name: "CarrerasEvitar");

            migrationBuilder.DropTable(
                name: "CarrerasFuturo");

            migrationBuilder.DropTable(
                name: "CarrerasRecomendadas");

            migrationBuilder.DropTable(
                name: "HabilidadesXCarrera");

            migrationBuilder.DropTable(
                name: "InteresesXCarrera");

            migrationBuilder.DropTable(
                name: "Actitud");

            migrationBuilder.DropTable(
                name: "Habilidad");

            migrationBuilder.DropTable(
                name: "Interes");

            migrationBuilder.DropIndex(
                name: "IX_Colegio_PaisId",
                table: "Colegio");

            migrationBuilder.DropColumn(
                name: "IdPais",
                table: "Colegio");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Colegio");

            migrationBuilder.DropColumn(
                name: "GradoEscolar",
                table: "AspNetUsers");
        }
    }
}
