using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Archivo
{
    public int ArchId { get; set; }

    public string? ArchDocumento { get; set; }

    public string? ArchDireccion { get; set; }

    public string? ArchTelefono { get; set; }

    public string? ArchPersonaEntrega { get; set; }

    public DateOnly? ArchFechaOtorgamiento { get; set; }

    public string? ArchTipoActo { get; set; }

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
