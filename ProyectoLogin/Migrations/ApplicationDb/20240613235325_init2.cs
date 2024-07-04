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

            // Agregar el nuevo campo token_recovery a UsuarioCliente
            migrationBuilder.AddColumn<string>(
                name: "token_recovery",
                table: "UsuarioCliente",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            // Agregar el nuevo campo token_recovery a UsuarioNotaria
            migrationBuilder.AddColumn<string>(
                name: "token_recovery",
                table: "UsuarioNotaria",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
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

            // Eliminar el campo token_recovery de UsuarioCliente
            migrationBuilder.DropColumn(
                name: "token_recovery",
                table: "UsuarioCliente");

            // Eliminar el campo token_recovery de UsuarioNotaria
            migrationBuilder.DropColumn(
                name: "token_recovery",
                table: "UsuarioNotaria");
        }
    }
}
