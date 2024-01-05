using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_Relationship_Career : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CualidadXPersonalidad_Cualidad_CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.DropIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado");

            migrationBuilder.DropIndex(
                name: "IX_CualidadXPersonalidad_CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.DropColumn(
                name: "CualidadId",
                table: "CualidadXPersonalidad");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "MBTIResutlado",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado",
                columns: new[] { "IdUsuario", "IdTestXUsuario" },
                unique: true,
                filter: "[IdUsuario] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "MBTIResutlado",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CualidadId",
                table: "CualidadXPersonalidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado",
                columns: new[] { "IdUsuario", "IdTestXUsuario" },
                unique: true);

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
