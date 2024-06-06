using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Proceso
{
    public long ProId { get; set; }

    public int UsucliId { get; set; }

    public int FacId { get; set; }

    public int ArchId { get; set; }

    public int TipId { get; set; }

    public DateOnly? ProFechaCreacion { get; set; }

    public string? ProEstado { get; set; }

    public DateOnly? ProFechaFinalizacion { get; set; }

    public string? ProObservacion { get; set; }

    public bool? ProEnvio { get; set; }

    public virtual Archivo Arch { get; set; } = null!;

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual Factura Fac { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual TipoProceso Tip { get; set; } = null!;

    public virtual UsuarioCliente Usucli { get; set; } = null!;
}
