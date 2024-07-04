using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateArchivoProcesoRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_proceso_tiene_archivo",
                table: "Proceso");

            migrationBuilder.DropIndex(
                name: "IX_Proceso_ArchivoId",
                table: "Proceso");

            migrationBuilder.DropColumn(
                name: "ArchivoId",
                table: "Proceso");

            migrationBuilder.AddColumn<int>(
                name: "ProcesoId",
                table: "Archivo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_ProcesoId",
                table: "Archivo",
                column: "ProcesoId");

            migrationBuilder.AddForeignKey(
                name: "fk_archivo_proceso",
                table: "Archivo",
                column: "ProcesoId",
                principalTable: "Proceso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_archivo_proceso",
                table: "Archivo");

            migrationBuilder.DropIndex(
                name: "IX_Archivo_ProcesoId",
                table: "Archivo");

            migrationBuilder.DropColumn(
                name: "ProcesoId",
                table: "Archivo");

            migrationBuilder.AddColumn<int>(
                name: "ArchivoId",
                table: "Proceso",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Proceso_ArchivoId",
                table: "Proceso",
                column: "ArchivoId");

            migrationBuilder.AddForeignKey(
                name: "fk_proceso_tiene_archivo",
                table: "Proceso",
                column: "ArchivoId",
                principalTable: "Archivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
