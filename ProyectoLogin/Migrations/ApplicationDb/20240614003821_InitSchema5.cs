using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InitSchema5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tip_nombre",
                table: "TipoProceso",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "tip_id",
                table: "TipoProceso",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "TipoProceso",
                newName: "tip_nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoProceso",
                newName: "tip_id");
        }
    }
}
