using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }
    public virtual DbSet<Cotizacion> Cotizacions { get; set; }
    public virtual DbSet<Factura> Facturas { get; set; }
    public virtual DbSet<Opcion> Opciones { get; set; }
    public virtual DbSet<Permiso> Permisos { get; set; }
    public virtual DbSet<Proceso> Procesos { get; set; }
    public virtual DbSet<TipoProceso> TipoProcesos { get; set; }
    public virtual DbSet<UsuarioCliente> UsuarioClientes { get; set; }
    public virtual DbSet<UsuarioNotaria> UsuarioNotaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseNpgsql("Host=localhost;Database=NotariaDb;Port=5432;Username=postgres;Password=2001pizza;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("archivo_pkey");

            entity.ToTable("archivo");

            entity.Property(e => e.Id)
            .HasColumnName("Id")
            .UseIdentityColumn();

            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("Direccion");
            entity.Property(e => e.Documento)
                .HasMaxLength(250)
                .HasColumnName("Documento");
            entity.Property(e => e.FechaOtorgamiento).HasColumnName("FechaOtorgamiento");
            entity.Property(e => e.PersonaEntrega)
                .HasMaxLength(50)
                .HasColumnName("PersonaEntrega");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("Telefono");
            entity.Property(e => e.TipoActo)
                .HasMaxLength(250)
                .HasColumnName("TipAacto");
        });

        modelBuilder.Entity<Cotizacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cotizacion_pkey");

            entity.ToTable("cotizacion");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.Aceptacion).HasColumnName("Aceptacion");
            entity.Property(e => e.Documento)
                .HasMaxLength(250)
                .HasColumnName("Documento");
            entity.Property(e => e.Fecha).HasColumnName("Fecha");
            entity.Property(e => e.ValorTotal).HasColumnName("ValorTotal");
            entity.Property(e => e.ProcesoId).HasColumnName("ProcesoId");
            entity.Property(e => e.UsuarioNotariaId).HasColumnName("UsuarioNotariaId");

            entity.HasOne(d => d.Pro).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_tener_proceso");

            entity.HasOne(d => d.Usunot).WithMany(p => p.Cotizacions)
                .HasForeignKey(d => d.UsuarioNotariaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_cotizaci_crea_usuario_");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("factura_pkey");

            entity.ToTable("factura");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.CedulaCliente)
                .HasMaxLength(50)
                .HasColumnName("Cedulacliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .HasColumnName("CorreoCliente");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(250)
                .HasColumnName("DireccionCliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(250)
                .HasColumnName("NombreCliente");
            entity.Property(e => e.Numero).HasColumnName("numero");
            entity.Property(e => e.ProcesoId).HasColumnName("proid");

            entity.HasOne(d => d.Pro).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_factura_lleva_proceso");
        });

        modelBuilder.Entity<Opcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("opciones_pkey");

            entity.ToTable("opciones");

            entity.Property(e => e.Id).HasColumnName("id").UseIdentityColumn(); ;
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(250)
                .HasColumnName("NombrePermiso");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permisos_pkey");

            entity.ToTable("permisos");

            entity.Property(e => e.Id).HasColumnName("per_id").UseIdentityColumn();
            entity.Property(e => e.OpcionId).HasColumnName("op_id");
            entity.Property(e => e.UsuarioClienteId).HasColumnName("usucli_id");
            entity.Property(e => e.UsuarioNotariaId).HasColumnName("usunot_id");

            entity.HasOne(d => d.Op).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.OpcionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos2_opciones");

            entity.HasOne(d => d.Usucli).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos_usuario_");

            entity.HasOne(d => d.Usunot).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.UsuarioNotariaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_permisos_permisos3_usuario_");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proceso_pkey");

            entity.ToTable("proceso");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(e => e.ArchivoId).HasColumnName("ArchivoId");
            entity.Property(e => e.Envio).HasColumnName("Envio");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("Estado");
            entity.Property(e => e.FechaCreacion).HasColumnName("FechaCreacion");
            entity.Property(e => e.FechaFinalizacion).HasColumnName("FechaFinalizacion");
            entity.Property(e => e.Observacion)
                .HasMaxLength(300)
                .HasColumnName("Observacion");
            entity.Property(e => e.TipoProcesoId).HasColumnName("TipoProcesoId");
            entity.Property(e => e.UsuarioClienteId).HasColumnName("UsuarioClienteId");

            entity.HasOne(d => d.Arch).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.ArchivoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_tiene_archivo");

            entity.HasOne(d => d.Tip).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.TipoProcesoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_es_tipo_pro");

            entity.HasOne(d => d.Usucli).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.UsuarioClienteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_proceso_relations_usuario_");
        });

        modelBuilder.Entity<TipoProceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_proceso_pkey");

            entity.ToTable("tipo_proceso");

            entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn(); 
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("Nombre");
        });

        modelBuilder.Entity<UsuarioCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_cliente_pkey");

            entity.ToTable("usuario_cliente");

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();  // Ensure it's configured as an identity column

            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .HasColumnName("Nombre");

            entity.Property(e => e.Apellido)
                .HasMaxLength(250)
                .HasColumnName("Apellido");

            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .HasColumnName("Correo");

            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("Telefono");

            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .HasColumnName("Direccion");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("Clave");

            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .HasColumnName("Cedula");
        });

        modelBuilder.Entity<UsuarioNotaria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_notaria_pkey");

            entity.ToTable("usuario_notaria");


            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            entity.Property(e => e.Apellido)
                .HasMaxLength(250)
                .HasColumnName("Apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("Clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("Correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .HasColumnName("Nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("Telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
