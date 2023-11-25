using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Add_Test_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cualidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caracteristica = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cualidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreModulo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Definicion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personalidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPregunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPregunta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTest = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdModulo = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Modulo_IdModulo",
                        column: x => x.IdModulo,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CualidadXPersonalidad",
                columns: table => new
                {
                    IdPersonalidad = table.Column<int>(type: "int", nullable: false),
                    IdCualidad = table.Column<int>(type: "int", nullable: false),
                    CualidadId = table.Column<int>(type: "int", nullable: true),
                    PersonalidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CualidadXPersonalidad", x => new { x.IdCualidad, x.IdPersonalidad });
                    table.ForeignKey(
                        name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                        column: x => x.CualidadId,
                        principalTable: "Cualidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CualidadXPersonalidad_Cualidad_IdCualidad",
                        column: x => x.IdCualidad,
                        principalTable: "Cualidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CualidadXPersonalidad_Personalidad_IdPersonalidad",
                        column: x => x.IdPersonalidad,
                        principalTable: "Personalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CualidadXPersonalidad_Personalidad_PersonalidadId",
                        column: x => x.PersonalidadId,
                        principalTable: "Personalidad",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSeccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdTest = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seccion_Test_IdTest",
                        column: x => x.IdTest,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoPregunta = table.Column<int>(type: "int", nullable: false),
                    IdSeccion = table.Column<int>(type: "int", nullable: false),
                    IdTest = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregunta_Seccion_IdSeccion",
                        column: x => x.IdSeccion,
                        principalTable: "Seccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregunta_Test_IdTest",
                        column: x => x.IdTest,
                        principalTable: "Test",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pregunta_TipoPregunta_IdTipoPregunta",
                        column: x => x.IdTipoPregunta,
                        principalTable: "TipoPregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuesta_Pregunta_IdPregunta",
                        column: x => x.IdPregunta,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cualidad_Caracteristica",
                table: "Cualidad",
                column: "Caracteristica",
                unique: true,
                filter: "[Caracteristica] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CualidadXPersonalidad_CualidadId",
                table: "CualidadXPersonalidad",
                column: "CualidadId");

            migrationBuilder.CreateIndex(
                name: "IX_CualidadXPersonalidad_IdPersonalidad",
                table: "CualidadXPersonalidad",
                column: "IdPersonalidad");

            migrationBuilder.CreateIndex(
                name: "IX_CualidadXPersonalidad_PersonalidadId",
                table: "CualidadXPersonalidad",
                column: "PersonalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulo_NombreModulo",
                table: "Modulo",
                column: "NombreModulo",
                unique: true,
                filter: "[NombreModulo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personalidad_Codigo",
                table: "Personalidad",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personalidad_Definicion",
                table: "Personalidad",
                column: "Definicion",
                unique: true,
                filter: "[Definicion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_Enunciado_IdTest",
                table: "Pregunta",
                columns: new[] { "Enunciado", "IdTest" },
                unique: true,
                filter: "[Enunciado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_IdSeccion",
                table: "Pregunta",
                column: "IdSeccion");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_IdTest",
                table: "Pregunta",
                column: "IdTest");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_IdTipoPregunta",
                table: "Pregunta",
                column: "IdTipoPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_Enunciado_IdPregunta",
                table: "Respuesta",
                columns: new[] { "Enunciado", "IdPregunta" },
                unique: true,
                filter: "[Enunciado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_IdPregunta",
                table: "Respuesta",
                column: "IdPregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_IdTest",
                table: "Seccion",
                column: "IdTest");

            migrationBuilder.CreateIndex(
                name: "IX_Seccion_NombreSeccion_IdTest",
                table: "Seccion",
                columns: new[] { "NombreSeccion", "IdTest" },
                unique: true,
                filter: "[NombreSeccion] IS NOT NULL AND [IdTest] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Test_IdModulo",
                table: "Test",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Test_NombreTest_IdModulo",
                table: "Test",
                columns: new[] { "NombreTest", "IdModulo" },
                unique: true,
                filter: "[NombreTest] IS NOT NULL AND [IdModulo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPregunta_Tipo",
                table: "TipoPregunta",
                column: "Tipo",
                unique: true,
                filter: "[Tipo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CualidadXPersonalidad");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Cualidad");

            migrationBuilder.DropTable(
                name: "Personalidad");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "Seccion");

            migrationBuilder.DropTable(
                name: "TipoPregunta");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Modulo");
        }
    }
}
