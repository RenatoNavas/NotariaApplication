using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddTokenRecoveryToUsuario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "token_recovery",
                table: "UsuarioNotaria",
                newName: "TokenRecovery");

            migrationBuilder.RenameColumn(
                name: "token_recovery",
                table: "UsuarioCliente",
                newName: "TokenRecovery");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenRecovery",
                table: "UsuarioNotaria",
                newName: "token_recovery");

            migrationBuilder.RenameColumn(
                name: "TokenRecovery",
                table: "UsuarioCliente",
                newName: "token_recovery");
        }
    }
}
