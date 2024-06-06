using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class TipoProceso
{
    public int TipId { get; set; }

    public string? TipNombre { get; set; }

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
