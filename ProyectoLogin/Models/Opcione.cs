using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Opcione
{
    public long OpId { get; set; }

    public string? OpNombrePermiso { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
