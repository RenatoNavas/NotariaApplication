using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoLogin.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Cotizacion> Cotizacions { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Opcione> Opciones { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Proceso> Procesos { get; set; }

    public virtual DbSet<TipoProceso> TipoProcesos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCliente> UsuarioClientes { get; set; }

    public virtual DbSet<UsuarioNotarium> UsuarioNotaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=NotariaDb;Port=5432;Username=postgres;Password=2001pizza;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.ArchId).HasName("pk_archivo");

            entity.ToTable("Archivo");

            entity.HasIndex(e => e.ArchId, "archivo_pk").IsUnique();

            entity.Property(e => e.ArchId)
                .ValueGeneratedNever()
                .HasColumnName("arch_id");
            entity.Property(e => e.ArchDireccion)
                .HasMaxLength(250)
                .HasColumnName("arch_direccion");
            entity.Property(e => e.ArchDocumento)
                .HasMaxLength(250)
                .HasColumnName("arch_documento");
            entity.Property(e => e.ArchFechaOtorgamiento).HasColumnName("arch_fecha_otorgamiento");
            entity.Property(e => e.ArchPersonaEntrega)
                .HasMaxLength(50)
                .HasColumnName("arch_persona_entrega");
            entity.Property(e => e.ArchTelefono)
                .HasMaxLength(50)
                .HasColumnName("arch_telefono");
            entity.Property(e => e.ArchTipoActo)
                .HasMaxLength(250)
                .HasColumnName("arch_tipo_acto");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.CotId).HasName("pk_cotizacion");

            entity.ToTable("Cotizacion");

            entity.HasIndex(e => e.CotId, "cotizacion_pk").IsUnique();

            entity.HasIndex(e => e.UsunotId, "crea_fk");

            entity.HasIndex(e => e.ProId, "tener_fk");

            entity.Property(e => e.CotId)
                .ValueGeneratedNever()
                .HasColumnName("cot_id");
            entity.Property(e => e.CotAceptacion).HasColumnName("cot_aceptacion");
            entity.Property(e => e.CotDocumento)
                .HasMaxLength(250)
                .HasColumnName("cot_documento");
            entity.Property(e => e.CotFecha).HasColumnName("cot_fecha");
            entity.Property(e => e.CotValorTotal).HasColumnName("cot_valor_total");
            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.UsunotId).HasColumnName("usunot_id");

            entity.HasOne(d => d.Pro).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.ProId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_tener_proceso");

            entity.HasOne(d => d.Usunot).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.UsunotId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_crea_usuario_");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacId).HasName("pk_factura");

            entity.ToTable("Factura");

            entity.HasIndex(e => e.FacId, "factura_pk").IsUnique();

            entity.HasIndex(e => e.ProId, "lleva2_fk");

            entity.Property(e => e.FacId)
                .ValueGeneratedNever()
                .HasColumnName("fac_id");
            entity.Property(e => e.FacCedulaCliente)
                .HasMaxLength(50)
                .HasColumnName("fac_cedula_cliente");
            entity.Property(e => e.FacCorreoCliente)
                .HasMaxLength(50)
                .HasColumnName("fac_correo_cliente");
            entity.Property(e => e.FacDireccionCliente)
                .HasMaxLength(250)
                .HasColumnName("fac_direccion_cliente");
            entity.Property(e => e.FacNombreCliente)
                .HasMaxLength(250)
                .HasColumnName("fac_nombre_cliente");
            entity.Property(e => e.FacNumero).HasColumnName("fac_numero");
            entity.Property(e => e.ProId).HasColumnName("pro_id");

            entity.HasOne(d => d.Pro).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ProId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_factura_lleva2_proceso");
        });

        modelBuilder.Entity<Opcione>(entity =>
        {
            entity.HasKey(e => e.OpId).HasName("pk_opciones");

            entity.HasIndex(e => e.OpId, "opciones_pk").IsUnique();

            entity.Property(e => e.OpId)
                .ValueGeneratedNever()
                .HasColumnName("op_id");
            entity.Property(e => e.OpNombrePermiso)
                .HasMaxLength(250)
                .HasColumnName("op_nombre_permiso");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => new { e.OpId, e.UsunotId, e.UsucliId }).HasName("pk_permisos");

            entity.HasIndex(e => e.UsunotId, "permisos2_fk");

            entity.HasIndex(e => e.UsucliId, "permisos3_fk");

            entity.HasIndex(e => e.OpId, "permisos_fk");

            entity.HasIndex(e => new { e.OpId, e.UsunotId, e.UsucliId }, "permisos_pk").IsUnique();

            entity.Property(e => e.OpId).HasColumnName("op_id");
            entity.Property(e => e.UsunotId).HasColumnName("usunot_id");
            entity.Property(e => e.UsucliId).HasColumnName("usucli_id");
            entity.Property(e => e.PerId).HasColumnName("per_id");

            entity.HasOne(d => d.Op).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.OpId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos_opciones");

            entity.HasOne(d => d.Usucli).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsucliId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos3_usuario_");

            entity.HasOne(d => d.Usunot).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsunotId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos2_usuario_");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("pk_proceso");

            entity.ToTable("Proceso");

            entity.HasIndex(e => e.TipId, "es_fk");

            entity.HasIndex(e => e.FacId, "lleva_fk");

            entity.HasIndex(e => e.ProId, "proceso_pk").IsUnique();

            entity.HasIndex(e => e.UsucliId, "relationship_5_fk");

            entity.HasIndex(e => e.ArchId, "tiene_fk");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.ArchId).HasColumnName("arch_id");
            entity.Property(e => e.FacId).HasColumnName("fac_id");
            entity.Property(e => e.ProEnvio).HasColumnName("pro_envio");
            entity.Property(e => e.ProEstado)
                .HasMaxLength(50)
                .HasColumnName("pro_estado");
            entity.Property(e => e.ProFechaCreacion).HasColumnName("pro_fecha_creacion");
            entity.Property(e => e.ProFechaFinalizacion).HasColumnName("pro_fecha_finalizacion");
            entity.Property(e => e.ProObservacion)
                .HasMaxLength(300)
                .HasColumnName("pro_observacion");
            entity.Property(e => e.TipId).HasColumnName("tip_id");
            entity.Property(e => e.UsucliId).HasColumnName("usucli_id");

            entity.HasOne(d => d.Arch).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.ArchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_tiene_archivo");

            entity.HasOne(d => d.Fac).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.FacId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_lleva_factura");

            entity.HasOne(d => d.Tip).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.TipId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_es_tipo_pro");

            entity.HasOne(d => d.Usucli).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.UsucliId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_relations_usuario_");
        });

        modelBuilder.Entity<TipoProceso>(entity =>
        {
            entity.HasKey(e => e.TipId).HasName("pk_tipo_proceso");

            entity.ToTable("Tipo Proceso");

            entity.HasIndex(e => e.TipId, "tipo_proceso_pk").IsUnique();

            entity.Property(e => e.TipId)
                .ValueGeneratedNever()
                .HasColumnName("tip_id");
            entity.Property(e => e.TipNombre)
                .HasMaxLength(50)
                .HasColumnName("tip_nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.UrlfotoPerfil).HasColumnName("URLFotoPerfil");
        });

        modelBuilder.Entity<UsuarioCliente>(entity =>
        {
            entity.HasKey(e => e.UsucliId).HasName("pk_usuario_cliente");

            entity.ToTable("Usuario Cliente");

            entity.HasIndex(e => e.UsucliId, "usuario_cliente_pk").IsUnique();

            entity.Property(e => e.UsucliId)
                .ValueGeneratedNever()
                .HasColumnName("usucli_id");
            entity.Property(e => e.UsucliApellido)
                .HasMaxLength(250)
                .HasColumnName("usucli_apellido");
            entity.Property(e => e.UsucliCedula)
                .HasMaxLength(50)
                .HasColumnName("usucli_cedula");
            entity.Property(e => e.UsucliClave)
                .HasMaxLength(50)
                .HasColumnName("usucli_clave");
            entity.Property(e => e.UsucliCorreo)
                .HasMaxLength(250)
                .HasColumnName("usucli_correo");
            entity.Property(e => e.UsucliDireccion)
                .HasMaxLength(250)
                .HasColumnName("usucli_direccion");
            entity.Property(e => e.UsucliNombre)
                .HasMaxLength(250)
                .HasColumnName("usucli_nombre");
            entity.Property(e => e.UsucliTelefono)
                .HasMaxLength(50)
                .HasColumnName("usucli_telefono");
        });

        modelBuilder.Entity<UsuarioNotarium>(entity =>
        {
            entity.HasKey(e => e.UsunotId).HasName("pk_usuario_notaria");

            entity.ToTable("Usuario Notaria");

            entity.HasIndex(e => e.UsunotId, "usuario_notaria_pk").IsUnique();

            entity.Property(e => e.UsunotId)
                .ValueGeneratedNever()
                .HasColumnName("usunot_id");
            entity.Property(e => e.UsunotApellido)
                .HasMaxLength(250)
                .HasColumnName("usunot_apellido");
            entity.Property(e => e.UsunotClave)
                .HasMaxLength(50)
                .HasColumnName("usunot_clave");
            entity.Property(e => e.UsunotCorreo)
                .HasMaxLength(50)
                .HasColumnName("usunot_correo");
            entity.Property(e => e.UsunotNombre)
                .HasMaxLength(250)
                .HasColumnName("usunot_nombre");
            entity.Property(e => e.UsunotTelefono)
                .HasMaxLength(50)
                .HasColumnName("usunot_telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
