using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Cotizacion
{
    public int CotId { get; set; }

    public long ProId { get; set; }

    public int UsunotId { get; set; }

    public double? CotValorTotal { get; set; }

    public string? CotDocumento { get; set; }

    public DateOnly? CotFecha { get; set; }

    public bool? CotAceptacion { get; set; }

    public virtual Proceso Pro { get; set; } = null!;

    public virtual UsuarioNotarium Usunot { get; set; } = null!;
}
