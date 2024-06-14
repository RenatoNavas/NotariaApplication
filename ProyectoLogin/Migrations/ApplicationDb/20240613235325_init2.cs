using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "archivo",
                newName: "Archivo");

            migrationBuilder.RenameColumn(
                name: "TipAacto",
                table: "Archivo",
                newName: "TipoActo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Archivo",
                newName: "archivo");

            migrationBuilder.RenameColumn(
                name: "TipoActo",
                table: "archivo",
                newName: "TipAacto");
        }
    }
}
