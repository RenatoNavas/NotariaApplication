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

    public int ArchivoId { get; set; }
    public bool? Envio { get; set; }
    public string? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaFinalizacion { get; set; }
    public string? Observacion { get; set; }
    public int TipoProcesoId { get; set; }
    public int UsuarioClienteId { get; set; }

    [ForeignKey("ArchivoId")]
    public virtual Archivo Archivo { get; set; }
    [ForeignKey("TipoProcesoId")]
    public virtual TipoProceso TipoProceso { get; set; }
    [ForeignKey("UsuarioClienteId")]
    public virtual UsuarioCliente UsuarioCliente { get; set; }

    public virtual ICollection<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();
    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
