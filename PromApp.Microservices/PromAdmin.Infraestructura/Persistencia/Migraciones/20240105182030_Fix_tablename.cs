using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromAdmin.Infraestructura.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Fix_tablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBTIResutlado",
                table: "MBTIResutlado");

            migrationBuilder.RenameTable(
                name: "MBTIResutlado",
                newName: "MBTIResultado");

            migrationBuilder.RenameIndex(
                name: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario",
                table: "MBTIResultado",
                newName: "IX_MBTIResultado_IdUsuario_IdTestXUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBTIResultado",
                table: "MBTIResultado",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MBTIResultado",
                table: "MBTIResultado");

            migrationBuilder.RenameTable(
                name: "MBTIResultado",
                newName: "MBTIResutlado");

            migrationBuilder.RenameIndex(
                name: "IX_MBTIResultado_IdUsuario_IdTestXUsuario",
                table: "MBTIResutlado",
                newName: "IX_MBTIResutlado_IdUsuario_IdTestXUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MBTIResutlado",
                table: "MBTIResutlado",
                column: "Id");
        }
    }
}
