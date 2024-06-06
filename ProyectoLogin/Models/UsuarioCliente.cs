using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class UsuarioCliente
{
    public int UsucliId { get; set; }

    public string? UsucliNombre { get; set; }

    public string? UsucliApellido { get; set; }

    public string? UsucliCorreo { get; set; }

    public string? UsucliTelefono { get; set; }

    public string? UsucliDireccion { get; set; }

    public string? UsucliClave { get; set; }

    public string? UsucliCedula { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
