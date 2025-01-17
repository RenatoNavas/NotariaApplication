﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoLogin.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProyectoLogin.Models.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Direccion");

                    b.Property<string>("Documento")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Documento");

                    b.Property<DateTime?>("FechaOtorgamiento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("FechaOtorgamiento");

                    b.Property<string>("PersonaEntrega")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("PersonaEntrega");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("integer")
                        .HasColumnName("ProcesoId");

                    b.Property<int?>("ProcesoId1")
                        .HasColumnType("integer");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Telefono");

                    b.Property<string>("TipoActo")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("TipoActo");

                    b.HasKey("Id")
                        .HasName("archivo_pkey");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("ProcesoId1");

                    b.ToTable("Archivo", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Cotizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aceptacion")
                        .HasColumnType("boolean")
                        .HasColumnName("Aceptacion");

                    b.Property<string>("Documento")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Documento");

                    b.Property<DateOnly?>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("Fecha");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("integer")
                        .HasColumnName("ProcesoId");

                    b.Property<int>("UsuarioNotariaId")
                        .HasColumnType("integer")
                        .HasColumnName("UsuarioNotariaId");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("real")
                        .HasColumnName("ValorTotal");

                    b.HasKey("Id")
                        .HasName("cotizacion_pkey");

                    b.HasIndex("ProcesoId");

                    b.HasIndex("UsuarioNotariaId");

                    b.ToTable("Cotizacion", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CedulaCliente")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CedulaCliente");

                    b.Property<string>("CorreoCliente")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CorreoCliente");

                    b.Property<string>("DireccionCliente")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("DireccionCliente");

                    b.Property<string>("NombreCliente")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("NombreCliente");

                    b.Property<int>("Numero")
                        .HasColumnType("integer")
                        .HasColumnName("Numero");

                    b.Property<int>("ProcesoId")
                        .HasColumnType("integer")
                        .HasColumnName("ProcesoId");

                    b.HasKey("Id")
                        .HasName("factura_pkey");

                    b.HasIndex("ProcesoId");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Opcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NombrePermiso")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("NombrePermiso");

                    b.HasKey("Id")
                        .HasName("opciones_pkey");

                    b.ToTable("Opcion", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Permiso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("PermisoId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OpcionId")
                        .HasColumnType("integer")
                        .HasColumnName("OpcionesId");

                    b.Property<int>("UsuarioClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("UsuarioClienteId");

                    b.Property<int>("UsuarioNotariaId")
                        .HasColumnType("integer")
                        .HasColumnName("UsuarioNotariaId");

                    b.HasKey("Id")
                        .HasName("permisos_pkey");

                    b.HasIndex("OpcionId");

                    b.HasIndex("UsuarioClienteId");

                    b.HasIndex("UsuarioNotariaId");

                    b.ToTable("Permiso", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Proceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Envio")
                        .HasColumnType("boolean")
                        .HasColumnName("Envio");

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Estado");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("FechaCreacion");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("FechaFinalizacion");

                    b.Property<string>("Observacion")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)")
                        .HasColumnName("Observacion");

                    b.Property<int>("TipoProcesoId")
                        .HasColumnType("integer")
                        .HasColumnName("TipoProcesoId");

                    b.Property<int>("UsuarioClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("UsuarioClienteId");

                    b.HasKey("Id")
                        .HasName("proceso_pkey");

                    b.HasIndex("TipoProcesoId");

                    b.HasIndex("UsuarioClienteId");

                    b.ToTable("Proceso", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.TipoProceso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id")
                        .HasName("tipo_proceso_pkey");

                    b.ToTable("TipoProceso", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.UsuarioCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Cedula")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Cedula");

                    b.Property<string>("Clave")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Clave");

                    b.Property<string>("Correo")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Correo");

                    b.Property<string>("Direccion")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Direccion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Telefono");

                    b.Property<string>("TokenRecovery")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("TokenRecovery");

                    b.HasKey("Id")
                        .HasName("usuario_cliente_pkey");

                    b.ToTable("UsuarioCliente", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.UsuarioNotaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Apellido");

                    b.Property<string>("Clave")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Clave");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Correo");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Telefono");

                    b.Property<string>("TokenRecovery")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("TokenRecovery");

                    b.HasKey("Id")
                        .HasName("usuario_notaria_pkey");

                    b.ToTable("UsuarioNotaria", (string)null);
                });

            modelBuilder.Entity("ProyectoLogin.Models.Archivo", b =>
                {
                    b.HasOne("ProyectoLogin.Models.Proceso", "Proceso")
                        .WithMany()
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_archivo_proceso");

                    b.HasOne("ProyectoLogin.Models.Proceso", null)
                        .WithMany("Archivos")
                        .HasForeignKey("ProcesoId1");

                    b.Navigation("Proceso");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Cotizacion", b =>
                {
                    b.HasOne("ProyectoLogin.Models.Proceso", "Proceso")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_cotizaci_tener_proceso");

                    b.HasOne("ProyectoLogin.Models.UsuarioNotaria", "UsuarioNotaria")
                        .WithMany("Cotizaciones")
                        .HasForeignKey("UsuarioNotariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_cotizaci_crea_usuario_");

                    b.Navigation("Proceso");

                    b.Navigation("UsuarioNotaria");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Factura", b =>
                {
                    b.HasOne("ProyectoLogin.Models.Proceso", "Proceso")
                        .WithMany("Facturas")
                        .HasForeignKey("ProcesoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_factura_lleva_proceso");

                    b.Navigation("Proceso");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Permiso", b =>
                {
                    b.HasOne("ProyectoLogin.Models.Opcion", "Opcion")
                        .WithMany("Permisos")
                        .HasForeignKey("OpcionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_permisos_permisos2_opciones");

                    b.HasOne("ProyectoLogin.Models.UsuarioCliente", "UsuarioCliente")
                        .WithMany("Permisos")
                        .HasForeignKey("UsuarioClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_permisos_permisos_usuario_");

                    b.HasOne("ProyectoLogin.Models.UsuarioNotaria", "UsuarioNotaria")
                        .WithMany("Permisos")
                        .HasForeignKey("UsuarioNotariaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_permisos_permisos3_usuario_");

                    b.Navigation("Opcion");

                    b.Navigation("UsuarioCliente");

                    b.Navigation("UsuarioNotaria");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Proceso", b =>
                {
                    b.HasOne("ProyectoLogin.Models.TipoProceso", "TipoProceso")
                        .WithMany("Procesos")
                        .HasForeignKey("TipoProcesoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_proceso_es_tipo_pro");

                    b.HasOne("ProyectoLogin.Models.UsuarioCliente", "UsuarioCliente")
                        .WithMany("Procesos")
                        .HasForeignKey("UsuarioClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_proceso_relations_usuario_");

                    b.Navigation("TipoProceso");

                    b.Navigation("UsuarioCliente");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Opcion", b =>
                {
                    b.Navigation("Permisos");
                });

            modelBuilder.Entity("ProyectoLogin.Models.Proceso", b =>
                {
                    b.Navigation("Archivos");

                    b.Navigation("Cotizaciones");

                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("ProyectoLogin.Models.TipoProceso", b =>
                {
                    b.Navigation("Procesos");
                });

            modelBuilder.Entity("ProyectoLogin.Models.UsuarioCliente", b =>
                {
                    b.Navigation("Permisos");

                    b.Navigation("Procesos");
                });

            modelBuilder.Entity("ProyectoLogin.Models.UsuarioNotaria", b =>
                {
                    b.Navigation("Cotizaciones");

                    b.Navigation("Permisos");
                });
#pragma warning restore 612, 618
        }
    }
}
