using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class UsuarioCliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Clave { get; set; }

    public string? Cedula { get; set; }

    public string? TokenRecovery { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
