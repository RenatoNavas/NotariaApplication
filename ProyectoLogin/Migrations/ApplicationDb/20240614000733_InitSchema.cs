using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InitSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Archivo",
                newName: "archivo");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "usuario_notaria",
                newName: "usunot_telefono");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "usuario_notaria",
                newName: "usunot_nombre");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "usuario_notaria",
                newName: "usunot_correo");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "usuario_notaria",
                newName: "usunot_clave");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "usuario_notaria",
                newName: "usunot_apellido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario_notaria",
                newName: "usunot_id");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "usuario_cliente",
                newName: "usucli_telefono");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "usuario_cliente",
                newName: "usucli_nombre");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "usuario_cliente",
                newName: "usucli_direccion");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "usuario_cliente",
                newName: "usucli_correo");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "usuario_cliente",
                newName: "usucli_clave");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "usuario_cliente",
                newName: "usucli_cedula");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "usuario_cliente",
                newName: "usucli_apellido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuario_cliente",
                newName: "usucli_id");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "tipo_proceso",
                newName: "tip_nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tipo_proceso",
                newName: "tip_id");

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

            migrationBuilder.RenameColumn(
                name: "NombrePermiso",
                table: "opciones",
                newName: "op_nombre_permiso");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "opciones",
                newName: "op_id");

            migrationBuilder.RenameColumn(
                name: "proid",
                table: "factura",
                newName: "pro_id");

            migrationBuilder.RenameColumn(
                name: "numero",
                table: "factura",
                newName: "fac_numero");

            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "factura",
                newName: "fac_nombre_cliente");

            migrationBuilder.RenameColumn(
                name: "DireccionCliente",
                table: "factura",
                newName: "fac_direccion_cliente");

            migrationBuilder.RenameColumn(
                name: "CorreoCliente",
                table: "factura",
                newName: "fac_correo_cliente");

            migrationBuilder.RenameColumn(
                name: "Cedulacliente",
                table: "factura",
                newName: "fac_cedula_cliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "factura",
                newName: "fac_id");

            migrationBuilder.RenameIndex(
                name: "IX_factura_proid",
                table: "factura",
                newName: "IX_factura_pro_id");

            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "cotizacion",
                newName: "cot_valor_total");

            migrationBuilder.RenameColumn(
                name: "UsuarioNotariaId",
                table: "cotizacion",
                newName: "usunot_id");

            migrationBuilder.RenameColumn(
                name: "ProcesoId",
                table: "cotizacion",
                newName: "pro_id");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "cotizacion",
                newName: "cot_fecha");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "cotizacion",
                newName: "cot_documento");

            migrationBuilder.RenameColumn(
                name: "Aceptacion",
                table: "cotizacion",
                newName: "cot_aceptacion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cotizacion",
                newName: "cot_id");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_UsuarioNotariaId",
                table: "cotizacion",
                newName: "IX_cotizacion_usunot_id");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_ProcesoId",
                table: "cotizacion",
                newName: "IX_cotizacion_pro_id");

            migrationBuilder.RenameColumn(
                name: "TipoActo",
                table: "archivo",
                newName: "arch_tipo_acto");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "archivo",
                newName: "arch_telefono");

            migrationBuilder.RenameColumn(
                name: "PersonaEntrega",
                table: "archivo",
                newName: "arch_persona_entrega");

            migrationBuilder.RenameColumn(
                name: "FechaOtorgamiento",
                table: "archivo",
                newName: "arch_fecha_otorgamiento");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "archivo",
                newName: "arch_documento");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "archivo",
                newName: "arch_direccion");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "archivo",
                newName: "arch_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "pro_fecha_finalizacion",
                table: "proceso",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "pro_fecha_creacion",
                table: "proceso",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fac_numero",
                table: "factura",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "cot_valor_total",
                table: "cotizacion",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "cot_aceptacion",
                table: "cotizacion",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "archivo",
                newName: "Archivo");

            migrationBuilder.RenameColumn(
                name: "usunot_telefono",
                table: "usuario_notaria",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "usunot_nombre",
                table: "usuario_notaria",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "usunot_correo",
                table: "usuario_notaria",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "usunot_clave",
                table: "usuario_notaria",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "usunot_apellido",
                table: "usuario_notaria",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "usunot_id",
                table: "usuario_notaria",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usucli_telefono",
                table: "usuario_cliente",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "usucli_nombre",
                table: "usuario_cliente",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "usucli_direccion",
                table: "usuario_cliente",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "usucli_correo",
                table: "usuario_cliente",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "usucli_clave",
                table: "usuario_cliente",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "usucli_cedula",
                table: "usuario_cliente",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "usucli_apellido",
                table: "usuario_cliente",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "usucli_id",
                table: "usuario_cliente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tip_nombre",
                table: "tipo_proceso",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "tip_id",
                table: "tipo_proceso",
                newName: "Id");

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

            migrationBuilder.RenameColumn(
                name: "op_nombre_permiso",
                table: "opciones",
                newName: "NombrePermiso");

            migrationBuilder.RenameColumn(
                name: "op_id",
                table: "opciones",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "factura",
                newName: "proid");

            migrationBuilder.RenameColumn(
                name: "fac_numero",
                table: "factura",
                newName: "numero");

            migrationBuilder.RenameColumn(
                name: "fac_nombre_cliente",
                table: "factura",
                newName: "NombreCliente");

            migrationBuilder.RenameColumn(
                name: "fac_direccion_cliente",
                table: "factura",
                newName: "DireccionCliente");

            migrationBuilder.RenameColumn(
                name: "fac_correo_cliente",
                table: "factura",
                newName: "CorreoCliente");

            migrationBuilder.RenameColumn(
                name: "fac_cedula_cliente",
                table: "factura",
                newName: "Cedulacliente");

            migrationBuilder.RenameColumn(
                name: "fac_id",
                table: "factura",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_factura_pro_id",
                table: "factura",
                newName: "IX_factura_proid");

            migrationBuilder.RenameColumn(
                name: "usunot_id",
                table: "cotizacion",
                newName: "UsuarioNotariaId");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "cotizacion",
                newName: "ProcesoId");

            migrationBuilder.RenameColumn(
                name: "cot_valor_total",
                table: "cotizacion",
                newName: "ValorTotal");

            migrationBuilder.RenameColumn(
                name: "cot_fecha",
                table: "cotizacion",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "cot_documento",
                table: "cotizacion",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "cot_aceptacion",
                table: "cotizacion",
                newName: "Aceptacion");

            migrationBuilder.RenameColumn(
                name: "cot_id",
                table: "cotizacion",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_usunot_id",
                table: "cotizacion",
                newName: "IX_cotizacion_UsuarioNotariaId");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_pro_id",
                table: "cotizacion",
                newName: "IX_cotizacion_ProcesoId");

            migrationBuilder.RenameColumn(
                name: "arch_tipo_acto",
                table: "Archivo",
                newName: "TipoActo");

            migrationBuilder.RenameColumn(
                name: "arch_telefono",
                table: "Archivo",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "arch_persona_entrega",
                table: "Archivo",
                newName: "PersonaEntrega");

            migrationBuilder.RenameColumn(
                name: "arch_fecha_otorgamiento",
                table: "Archivo",
                newName: "FechaOtorgamiento");

            migrationBuilder.RenameColumn(
                name: "arch_documento",
                table: "Archivo",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "arch_direccion",
                table: "Archivo",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "arch_id",
                table: "Archivo",
                newName: "Id");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaFinalizacion",
                table: "proceso",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaCreacion",
                table: "proceso",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "numero",
                table: "factura",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "ValorTotal",
                table: "cotizacion",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<bool>(
                name: "Aceptacion",
                table: "cotizacion",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
