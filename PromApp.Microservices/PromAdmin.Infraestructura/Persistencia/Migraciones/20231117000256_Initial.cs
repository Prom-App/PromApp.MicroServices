using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
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
                    table.PrimaryKey("PK_Agencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demografia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tamaño = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demografia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGenero = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Saludo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geografia",
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
                    table.PrimaryKey("PK_Geografia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lenguaje = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parentesco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoParentesco = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parentesco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAcreditacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAcreditacion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Internacional = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAcreditacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoActividad = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoAplicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAplicacion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAplicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPrograma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPrograma = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPrograma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Universidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ranking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsPrivada = table.Column<bool>(type: "bit", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: true),
                    IdTipoAplicacion = table.Column<int>(type: "int", nullable: true),
                    IdAgencia = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universidad_Agencia_IdAgencia",
                        column: x => x.IdAgencia,
                        principalTable: "Agencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Universidad_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Universidad_TipoAplicacion_IdTipoAplicacion",
                        column: x => x.IdTipoAplicacion,
                        principalTable: "TipoAplicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdTipoPrograma = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrera_TipoPrograma_IdTipoPrograma",
                        column: x => x.IdTipoPrograma,
                        principalTable: "TipoPrograma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdDemografia = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Demografia_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Demografia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdiomaXUniversidad",
                columns: table => new
                {
                    IdIdioma = table.Column<int>(type: "int", nullable: false),
                    IdUniversidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdiomaXUniversidad", x => new { x.IdUniversidad, x.IdIdioma });
                    table.ForeignKey(
                        name: "FK_IdiomaXUniversidad_Idioma_IdIdioma",
                        column: x => x.IdIdioma,
                        principalTable: "Idioma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdiomaXUniversidad_Universidad_IdUniversidad",
                        column: x => x.IdUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoProgramaXUniversidad",
                columns: table => new
                {
                    IdTipoPrograma = table.Column<int>(type: "int", nullable: false),
                    IdUniversidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProgramaXUniversidad", x => new { x.IdTipoPrograma, x.IdUniversidad });
                    table.ForeignKey(
                        name: "FK_TipoProgramaXUniversidad_TipoPrograma_IdTipoPrograma",
                        column: x => x.IdTipoPrograma,
                        principalTable: "TipoPrograma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoProgramaXUniversidad_Universidad_IdUniversidad",
                        column: x => x.IdUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarreraRelacionada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCarrera = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraRelacionada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarreraRelacionada_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarreraXUniversidad",
                columns: table => new
                {
                    IdUniversidad = table.Column<int>(type: "int", nullable: false),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarreraXUniversidad", x => new { x.IdUniversidad, x.IdCarrera });
                    table.ForeignKey(
                        name: "FK_CarreraXUniversidad_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarreraXUniversidad_Universidad_IdUniversidad",
                        column: x => x.IdUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LaFiesta = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUniversidad = table.Column<int>(type: "int", nullable: true),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campus_Ciudad_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Campus_Universidad_IdUniversidad",
                        column: x => x.IdUniversidad,
                        principalTable: "Universidad",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Colegio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsPrivado = table.Column<bool>(type: "bit", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colegio_Ciudad_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicasXUniversidad",
                columns: table => new
                {
                    IdCaracteristica = table.Column<int>(type: "int", nullable: false),
                    IdCampus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasXUniversidad", x => new { x.IdCaracteristica, x.IdCampus });
                    table.ForeignKey(
                        name: "FK_CaracteristicasXUniversidad_Campus_IdCampus",
                        column: x => x.IdCampus,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaracteristicasXUniversidad_Geografia_IdCaracteristica",
                        column: x => x.IdCaracteristica,
                        principalTable: "Geografia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividadXCampus",
                columns: table => new
                {
                    IdTipoActividad = table.Column<int>(type: "int", nullable: false),
                    IdCampus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActividadXCampus", x => new { x.IdCampus, x.IdTipoActividad });
                    table.ForeignKey(
                        name: "FK_TipoActividadXCampus_Campus_IdCampus",
                        column: x => x.IdCampus,
                        principalTable: "Campus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoActividadXCampus_TipoActividad_IdTipoActividad",
                        column: x => x.IdTipoActividad,
                        principalTable: "TipoActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    IdColegio = table.Column<int>(type: "int", nullable: true),
                    IdGenero = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Ciudad_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Colegio_IdColegio",
                        column: x => x.IdColegio,
                        principalTable: "Colegio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Genero_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Genero",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TipoAcreditacionXColegio",
                columns: table => new
                {
                    IdAcreditacion = table.Column<int>(type: "int", nullable: false),
                    IdColegio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAcreditacionXColegio", x => new { x.IdColegio, x.IdAcreditacion });
                    table.ForeignKey(
                        name: "FK_TipoAcreditacionXColegio_Colegio_IdColegio",
                        column: x => x.IdColegio,
                        principalTable: "Colegio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoAcreditacionXColegio_TipoAcreditacion_IdAcreditacion",
                        column: x => x.IdAcreditacion,
                        principalTable: "TipoAcreditacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdParentesco = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    IdUsuarioContacto = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacto_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacto_AspNetUsers_IdUsuarioContacto",
                        column: x => x.IdUsuarioContacto,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacto_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacto_Parentesco_IdParentesco",
                        column: x => x.IdParentesco,
                        principalTable: "Parentesco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencia_Nombre",
                table: "Agencia",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCiudad",
                table: "AspNetUsers",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdColegio",
                table: "AspNetUsers",
                column: "IdColegio");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdGenero",
                table: "AspNetUsers",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_IdCiudad",
                table: "Campus",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_IdUniversidad",
                table: "Campus",
                column: "IdUniversidad");

            migrationBuilder.CreateIndex(
                name: "IX_Campus_Nombre_IdUniversidad_IdCiudad",
                table: "Campus",
                columns: new[] { "Nombre", "IdUniversidad", "IdCiudad" },
                unique: true,
                filter: "[Nombre] IS NOT NULL AND [IdUniversidad] IS NOT NULL AND [IdCiudad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasXUniversidad_IdCampus",
                table: "CaracteristicasXUniversidad",
                column: "IdCampus");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_IdTipoPrograma",
                table: "Carrera",
                column: "IdTipoPrograma");

            migrationBuilder.CreateIndex(
                name: "IX_Carrera_Nombre_IdTipoPrograma",
                table: "Carrera",
                columns: new[] { "Nombre", "IdTipoPrograma" },
                unique: true,
                filter: "[Nombre] IS NOT NULL AND [IdTipoPrograma] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraRelacionada_IdCarrera",
                table: "CarreraRelacionada",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraRelacionada_Nombre_IdCarrera",
                table: "CarreraRelacionada",
                columns: new[] { "Nombre", "IdCarrera" },
                unique: true,
                filter: "[Nombre] IS NOT NULL AND [IdCarrera] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarreraXUniversidad_IdCarrera",
                table: "CarreraXUniversidad",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDepartamento",
                table: "Ciudad",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_Nombre_IdDepartamento",
                table: "Ciudad",
                columns: new[] { "Nombre", "IdDepartamento" },
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Colegio_IdCiudad",
                table: "Colegio",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Colegio_Nombre_IdCiudad",
                table: "Colegio",
                columns: new[] { "Nombre", "IdCiudad" },
                unique: true,
                filter: "[Nombre] IS NOT NULL AND [IdCiudad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdParentesco",
                table: "Contacto",
                column: "IdParentesco");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdUsuario_IdParentesco_Correo",
                table: "Contacto",
                columns: new[] { "IdUsuario", "IdParentesco", "Correo" },
                unique: true,
                filter: "[Correo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_IdUsuarioContacto",
                table: "Contacto",
                column: "IdUsuarioContacto");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_UsuarioId",
                table: "Contacto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Demografia_Tamaño",
                table: "Demografia",
                column: "Tamaño",
                unique: true,
                filter: "[Tamaño] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPais_Nombre",
                table: "Departamento",
                columns: new[] { "IdPais", "Nombre" });

            migrationBuilder.CreateIndex(
                name: "IX_Genero_TipoGenero",
                table: "Genero",
                column: "TipoGenero",
                unique: true,
                filter: "[TipoGenero] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Geografia_Caracteristica",
                table: "Geografia",
                column: "Caracteristica",
                unique: true,
                filter: "[Caracteristica] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Idioma_Lenguaje",
                table: "Idioma",
                column: "Lenguaje",
                unique: true,
                filter: "[Lenguaje] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomaXUniversidad_IdIdioma",
                table: "IdiomaXUniversidad",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_Pais_Nombre",
                table: "Pais",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parentesco_TipoParentesco",
                table: "Parentesco",
                column: "TipoParentesco",
                unique: true,
                filter: "[TipoParentesco] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAcreditacion_TipoAcreditacion",
                table: "TipoAcreditacion",
                column: "TipoAcreditacion",
                unique: true,
                filter: "[TipoAcreditacion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAcreditacionXColegio_IdAcreditacion",
                table: "TipoAcreditacionXColegio",
                column: "IdAcreditacion");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividad_TipoActividad",
                table: "TipoActividad",
                column: "TipoActividad",
                unique: true,
                filter: "[TipoActividad] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActividadXCampus_IdTipoActividad",
                table: "TipoActividadXCampus",
                column: "IdTipoActividad");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAplicacion_TipoAplicacion",
                table: "TipoAplicacion",
                column: "TipoAplicacion",
                unique: true,
                filter: "[TipoAplicacion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPrograma_TipoPrograma",
                table: "TipoPrograma",
                column: "TipoPrograma",
                unique: true,
                filter: "[TipoPrograma] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TipoProgramaXUniversidad_IdUniversidad",
                table: "TipoProgramaXUniversidad",
                column: "IdUniversidad");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_IdAgencia",
                table: "Universidad",
                column: "IdAgencia");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_IdPais_Nombre",
                table: "Universidad",
                columns: new[] { "IdPais", "Nombre" },
                unique: true,
                filter: "[IdPais] IS NOT NULL AND [Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Universidad_IdTipoAplicacion",
                table: "Universidad",
                column: "IdTipoAplicacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaracteristicasXUniversidad");

            migrationBuilder.DropTable(
                name: "CarreraRelacionada");

            migrationBuilder.DropTable(
                name: "CarreraXUniversidad");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "IdiomaXUniversidad");

            migrationBuilder.DropTable(
                name: "TipoAcreditacionXColegio");

            migrationBuilder.DropTable(
                name: "TipoActividadXCampus");

            migrationBuilder.DropTable(
                name: "TipoProgramaXUniversidad");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Geografia");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Parentesco");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "TipoAcreditacion");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "TipoActividad");

            migrationBuilder.DropTable(
                name: "TipoPrograma");

            migrationBuilder.DropTable(
                name: "Colegio");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Universidad");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "TipoAplicacion");

            migrationBuilder.DropTable(
                name: "Demografia");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
