using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class InitSchema6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "proceso",
                newName: "Proceso");

            migrationBuilder.RenameTable(
                name: "factura",
                newName: "Factura");

            migrationBuilder.RenameTable(
                name: "cotizacion",
                newName: "Cotizacion");

            migrationBuilder.RenameTable(
                name: "archivo",
                newName: "Archivo");

            migrationBuilder.RenameTable(
                name: "usuario_notaria",
                newName: "UsuarioNotaria");

            migrationBuilder.RenameTable(
                name: "usuario_cliente",
                newName: "UsuarioCliente");

            migrationBuilder.RenameTable(
                name: "permisos",
                newName: "Permiso");

            migrationBuilder.RenameTable(
                name: "opciones",
                newName: "Opcion");

            migrationBuilder.RenameColumn(
                name: "usucli_id",
                table: "Proceso",
                newName: "UsuarioClienteId");

            migrationBuilder.RenameColumn(
                name: "tip_id",
                table: "Proceso",
                newName: "TipoProcesoId");

            migrationBuilder.RenameColumn(
                name: "pro_observacion",
                table: "Proceso",
                newName: "Observacion");

            migrationBuilder.RenameColumn(
                name: "pro_fecha_finalizacion",
                table: "Proceso",
                newName: "FechaFinalizacion");

            migrationBuilder.RenameColumn(
                name: "pro_fecha_creacion",
                table: "Proceso",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "pro_estado",
                table: "Proceso",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "pro_envio",
                table: "Proceso",
                newName: "Envio");

            migrationBuilder.RenameColumn(
                name: "arch_id",
                table: "Proceso",
                newName: "ArchivoId");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "Proceso",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_usucli_id",
                table: "Proceso",
                newName: "IX_Proceso_UsuarioClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_tip_id",
                table: "Proceso",
                newName: "IX_Proceso_TipoProcesoId");

            migrationBuilder.RenameIndex(
                name: "IX_proceso_arch_id",
                table: "Proceso",
                newName: "IX_Proceso_ArchivoId");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "Factura",
                newName: "ProcesoId");

            migrationBuilder.RenameColumn(
                name: "fac_numero",
                table: "Factura",
                newName: "Numero");

            migrationBuilder.RenameColumn(
                name: "fac_nombre_cliente",
                table: "Factura",
                newName: "NombreCliente");

            migrationBuilder.RenameColumn(
                name: "fac_direccion_cliente",
                table: "Factura",
                newName: "DireccionCliente");

            migrationBuilder.RenameColumn(
                name: "fac_correo_cliente",
                table: "Factura",
                newName: "CorreoCliente");

            migrationBuilder.RenameColumn(
                name: "fac_cedula_cliente",
                table: "Factura",
                newName: "CedulaCliente");

            migrationBuilder.RenameColumn(
                name: "fac_id",
                table: "Factura",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_factura_pro_id",
                table: "Factura",
                newName: "IX_Factura_ProcesoId");

            migrationBuilder.RenameColumn(
                name: "usunot_id",
                table: "Cotizacion",
                newName: "UsuarioNotariaId");

            migrationBuilder.RenameColumn(
                name: "pro_id",
                table: "Cotizacion",
                newName: "ProcesoId");

            migrationBuilder.RenameColumn(
                name: "cot_valor_total",
                table: "Cotizacion",
                newName: "ValorTotal");

            migrationBuilder.RenameColumn(
                name: "cot_fecha",
                table: "Cotizacion",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "cot_documento",
                table: "Cotizacion",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "cot_aceptacion",
                table: "Cotizacion",
                newName: "Aceptacion");

            migrationBuilder.RenameColumn(
                name: "cot_id",
                table: "Cotizacion",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_usunot_id",
                table: "Cotizacion",
                newName: "IX_Cotizacion_UsuarioNotariaId");

            migrationBuilder.RenameIndex(
                name: "IX_cotizacion_pro_id",
                table: "Cotizacion",
                newName: "IX_Cotizacion_ProcesoId");

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

            migrationBuilder.RenameColumn(
                name: "usunot_telefono",
                table: "UsuarioNotaria",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "usunot_nombre",
                table: "UsuarioNotaria",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "usunot_correo",
                table: "UsuarioNotaria",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "usunot_clave",
                table: "UsuarioNotaria",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "usunot_apellido",
                table: "UsuarioNotaria",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "usunot_id",
                table: "UsuarioNotaria",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usucli_telefono",
                table: "UsuarioCliente",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "usucli_nombre",
                table: "UsuarioCliente",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "usucli_direccion",
                table: "UsuarioCliente",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "usucli_correo",
                table: "UsuarioCliente",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "usucli_clave",
                table: "UsuarioCliente",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "usucli_cedula",
                table: "UsuarioCliente",
                newName: "Cedula");

            migrationBuilder.RenameColumn(
                name: "usucli_apellido",
                table: "UsuarioCliente",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "usucli_id",
                table: "UsuarioCliente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usunot_id",
                table: "Permiso",
                newName: "UsuarioNotariaId");

            migrationBuilder.RenameColumn(
                name: "usucli_id",
                table: "Permiso",
                newName: "UsuarioClienteId");

            migrationBuilder.RenameColumn(
                name: "op_id",
                table: "Permiso",
                newName: "OpcionesId");

            migrationBuilder.RenameColumn(
                name: "per_id",
                table: "Permiso",
                newName: "PermisoId");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_usunot_id",
                table: "Permiso",
                newName: "IX_Permiso_UsuarioNotariaId");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_usucli_id",
                table: "Permiso",
                newName: "IX_Permiso_UsuarioClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_permisos_op_id",
                table: "Permiso",
                newName: "IX_Permiso_OpcionesId");

            migrationBuilder.RenameColumn(
                name: "op_nombre_permiso",
                table: "Opcion",
                newName: "NombrePermiso");

            migrationBuilder.RenameColumn(
                name: "op_id",
                table: "Opcion",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Proceso",
                newName: "proceso");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "factura");

            migrationBuilder.RenameTable(
                name: "Cotizacion",
                newName: "cotizacion");

            migrationBuilder.RenameTable(
                name: "Archivo",
                newName: "archivo");

            migrationBuilder.RenameTable(
                name: "UsuarioNotaria",
                newName: "usuario_notaria");

            migrationBuilder.RenameTable(
                name: "UsuarioCliente",
                newName: "usuario_cliente");

            migrationBuilder.RenameTable(
                name: "Permiso",
                newName: "permisos");

            migrationBuilder.RenameTable(
                name: "Opcion",
                newName: "opciones");

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
                name: "IX_Proceso_UsuarioClienteId",
                table: "proceso",
                newName: "IX_proceso_usucli_id");

            migrationBuilder.RenameIndex(
                name: "IX_Proceso_TipoProcesoId",
                table: "proceso",
                newName: "IX_proceso_tip_id");

            migrationBuilder.RenameIndex(
                name: "IX_Proceso_ArchivoId",
                table: "proceso",
                newName: "IX_proceso_arch_id");

            migrationBuilder.RenameColumn(
                name: "ProcesoId",
                table: "factura",
                newName: "pro_id");

            migrationBuilder.RenameColumn(
                name: "Numero",
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
                name: "CedulaCliente",
                table: "factura",
                newName: "fac_cedula_cliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "factura",
                newName: "fac_id");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_ProcesoId",
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
                name: "IX_Cotizacion_UsuarioNotariaId",
                table: "cotizacion",
                newName: "IX_cotizacion_usunot_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cotizacion_ProcesoId",
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
                name: "UsuarioNotariaId",
                table: "permisos",
                newName: "usunot_id");

            migrationBuilder.RenameColumn(
                name: "UsuarioClienteId",
                table: "permisos",
                newName: "usucli_id");

            migrationBuilder.RenameColumn(
                name: "OpcionesId",
                table: "permisos",
                newName: "op_id");

            migrationBuilder.RenameColumn(
                name: "PermisoId",
                table: "permisos",
                newName: "per_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permiso_UsuarioNotariaId",
                table: "permisos",
                newName: "IX_permisos_usunot_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permiso_UsuarioClienteId",
                table: "permisos",
                newName: "IX_permisos_usucli_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permiso_OpcionesId",
                table: "permisos",
                newName: "IX_permisos_op_id");

            migrationBuilder.RenameColumn(
                name: "NombrePermiso",
                table: "opciones",
                newName: "op_nombre_permiso");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "opciones",
                newName: "op_id");
        }
    }
}
