using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateSchema11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usucli_id",
                table: "proceso",
                newName: "UsuarioClienteId");

            migrationBuilder.RenameColumn(
                name: "tip_id",
                table: "proceso",
                newName: "TipoProcesoId");

            migrationBuilder.RenameColumn(
                name: "pro_observacion",
                table: "proceso",
                newName: "Observacion");

            migrationBuilder.RenameColumn(
                name: "pro_fecha_finalizacion",
                table: "proceso",
                newName: "FechaFinalizacion");

            migrationBuilder.RenameColumn(
                name: "pro_fecha_creacion",
                table: "proceso",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "pro_estado",
                table: "proceso",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "pro_envio",
                table: "proceso",
                newName: "Envio");

            migrationBuilder.RenameColumn(
                name: "arch_id",
                table: "proceso",
                newName: "ArchivoId");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "proceso",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_usucli_id",
                table: "proceso",
                newName: "IX_proceso_UsuarioClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_tip_id",
                table: "proceso",
                newName: "IX_proceso_TipoProcesoId");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_arch_id",
                table: "proceso",
                newName: "IX_proceso_ArchivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioClienteId",
                table: "proceso",
                newName: "usucli_id");

            migrationBuilder.RenameColumn(
                name: "TipoProcesoId",
                table: "proceso",
                newName: "tip_id");

            migrationBuilder.RenameColumn(
                name: "Observacion",
                table: "proceso",
                newName: "pro_observacion");

            migrationBuilder.RenameColumn(
                name: "FechaFinalizacion",
                table: "proceso",
                newName: "pro_fecha_finalizacion");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "proceso",
                newName: "pro_fecha_creacion");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "proceso",
                newName: "pro_estado");

            migrationBuilder.RenameColumn(
                name: "Envio",
                table: "proceso",
                newName: "pro_envio");

            migrationBuilder.RenameColumn(
                name: "ArchivoId",
                table: "proceso",
                newName: "arch_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "proceso",
                newName: "pro_id");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_UsuarioClienteId",
                table: "proceso",
                newName: "IX_proceso_usucli_id");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_TipoProcesoId",
                table: "proceso",
                newName: "IX_proceso_tip_id");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_ArchivoId",
                table: "proceso",
                newName: "IX_proceso_arch_id");
        }
    }
}
