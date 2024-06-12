using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Proceso
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int TipoProcesoId { get; set; }

    public int ArchivoId { get; set; }

    public int UsuarioClienteId { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaFinalizacion { get; set; }

    public string? Observacion { get; set; }

    public bool? Envio { get; set; }

    public virtual Archivo Arch { get; set; } = null!;

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual TipoProceso Tip { get; set; } = null!;

    public virtual UsuarioCliente Usucli { get; set; } = null!;
}
