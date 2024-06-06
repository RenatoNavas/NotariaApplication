using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class UsuarioNotarium
{
    public int UsunotId { get; set; }

    public string? UsunotNombre { get; set; }

    public string? UsunotApellido { get; set; }

    public string? UsunotCorreo { get; set; }

    public string? UsunotTelefono { get; set; }

    public string? UsunotClave { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
