using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }
    public virtual DbSet<Cotizacion> Cotizaciones { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public virtual DbSet<Opcion> Opciones { get; set; }
    public virtual DbSet<Permiso> Permisos { get; set; }
    public virtual DbSet<Proceso> Procesos { get; set; }
    public virtual DbSet<TipoProceso> TipoProcesos { get; set; }
    public virtual DbSet<UsuarioCliente> UsuarioClientes { get; set; }
    public virtual DbSet<UsuarioNotaria> UsuariosNotaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=NotariaDb;Port=5432;Username=postgres;Password=2001pizza;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("archivo_pkey");

            entity.ToTable("Archivo");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Documento).HasColumnName("Documento").HasMaxLength(250);
            entity.Property(e => e.Direccion).HasColumnName("Direccion").HasMaxLength(250);
            entity.Property(e => e.Telefono).HasColumnName("Telefono").HasMaxLength(50);
            entity.Property(e => e.PersonaEntrega).HasColumnName("PersonaEntrega").HasMaxLength(50);
            entity.Property(e => e.FechaOtorgamiento).HasColumnName("FechaOtorgamiento");
            entity.Property(e => e.TipoActo).HasColumnName("TipoActo").HasMaxLength(250);

            entity.Property(e => e.ProcesoId).HasColumnName("ProcesoId");
            entity.HasOne(d => d.Proceso)
                .WithMany()
                .HasForeignKey(d => d.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_archivo_proceso");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cotizacion_pkey");

            entity.ToTable("Cotizacion");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.ValorTotal).HasColumnName("ValorTotal");
            entity.Property(e => e.Documento).HasColumnName("Documento").HasMaxLength(250);
            entity.Property(e => e.Fecha).HasColumnName("Fecha");
            entity.Property(e => e.Aceptacion).HasColumnName("Aceptacion");
            entity.Property(e => e.ProcesoId).HasColumnName("ProcesoId");
            entity.Property(e => e.UsuarioNotariaId).HasColumnName("UsuarioNotariaId");

            entity.HasOne(d => d.Proceso).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_tener_proceso");

            entity.HasOne(d => d.UsuarioNotaria).WithMany(p => p.Cotizaciones)
                .HasForeignKey(d => d.UsuarioNotariaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_crea_usuario_");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("factura_pkey");

            entity.ToTable("Factura");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Numero).HasColumnName("Numero");
            entity.Property(e => e.NombreCliente).HasColumnName("NombreCliente").HasMaxLength(250);
            entity.Property(e => e.CedulaCliente).HasColumnName("CedulaCliente").HasMaxLength(50);
            entity.Property(e => e.CorreoCliente).HasColumnName("CorreoCliente").HasMaxLength(50);
            entity.Property(e => e.DireccionCliente).HasColumnName("DireccionCliente").HasMaxLength(250);
            entity.Property(e => e.ProcesoId).HasColumnName("ProcesoId");

            entity.HasOne(d => d.Proceso).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_factura_lleva_proceso");
        });

        modelBuilder.Entity<Opcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("opciones_pkey");

            entity.ToTable("Opcion");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.NombrePermiso).HasColumnName("NombrePermiso").HasMaxLength(250);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permisos_pkey");

            entity.ToTable("Permiso");

            entity.Property(e => e.Id).HasColumnName("PermisoId").UseIdentityColumn();
            entity.Property(e => e.OpcionId).HasColumnName("OpcionesId");
            entity.Property(e => e.UsuarioClienteId).HasColumnName("UsuarioClienteId");
            entity.Property(e => e.UsuarioNotariaId).HasColumnName("UsuarioNotariaId");

            entity.HasOne(d => d.Opcion).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.OpcionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos2_opciones");

            entity.HasOne(d => d.UsuarioCliente).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos_usuario_");

            entity.HasOne(d => d.UsuarioNotaria).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsuarioNotariaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos3_usuario_");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proceso_pkey");

            entity.ToTable("Proceso");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Envio).HasColumnName("Envio");
            entity.Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnName("FechaCreacion");
            entity.Property(e => e.FechaFinalizacion).HasColumnName("FechaFinalizacion");
            entity.Property(e => e.Observacion).HasColumnName("Observacion").HasMaxLength(300);
            entity.Property(e => e.TipoProcesoId).HasColumnName("TipoProcesoId");
            entity.Property(e => e.UsuarioClienteId).HasColumnName("UsuarioClienteId");

            entity.HasOne(d => d.TipoProceso).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.TipoProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_es_tipo_pro");

            entity.HasOne(d => d.UsuarioCliente).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_relations_usuario_");
        });

        modelBuilder.Entity<TipoProceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_proceso_pkey");

            entity.ToTable("TipoProceso");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("Nombre");
        });

        modelBuilder.Entity<UsuarioCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_cliente_pkey");

            entity.ToTable("UsuarioCliente");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Nombre).HasColumnName("Nombre").HasMaxLength(250);
            entity.Property(e => e.Apellido).HasColumnName("Apellido").HasMaxLength(250);
            entity.Property(e => e.Correo).HasColumnName("Correo").HasMaxLength(250);
            entity.Property(e => e.Telefono).HasColumnName("Telefono").HasMaxLength(50);
            entity.Property(e => e.Direccion).HasColumnName("Direccion").HasMaxLength(250);
            entity.Property(e => e.Clave).HasColumnName("Clave").HasMaxLength(50);
            entity.Property(e => e.Cedula).HasColumnName("Cedula").HasMaxLength(50);
            entity.Property(e => e.TokenRecovery).HasColumnName("TokenRecovery").HasMaxLength(200);
        });

        modelBuilder.Entity<UsuarioNotaria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_notaria_pkey");

            entity.ToTable("UsuarioNotaria");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Nombre).HasColumnName("Nombre").HasMaxLength(250);
            entity.Property(e => e.Apellido).HasColumnName("Apellido").HasMaxLength(250);
            entity.Property(e => e.Correo).HasColumnName("Correo").HasMaxLength(50);
            entity.Property(e => e.Telefono).HasColumnName("Telefono").HasMaxLength(50);
            entity.Property(e => e.Clave).HasColumnName("Clave").HasMaxLength(50);
            entity.Property(e => e.TokenRecovery).HasColumnName("TokenRecovery").HasMaxLength(200);
        });

        base.OnModelCreating(modelBuilder);
    }
}
