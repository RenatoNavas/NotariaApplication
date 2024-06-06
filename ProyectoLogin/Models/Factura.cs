using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Factura
{
    public int FacId { get; set; }

    public long ProId { get; set; }

    public int? FacNumero { get; set; }

    public string? FacNombreCliente { get; set; }

    public string? FacCedulaCliente { get; set; }

    public string? FacCorreoCliente { get; set; }

    public string? FacDireccionCliente { get; set; }

    public virtual Proceso Pro { get; set; } = null!;

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
