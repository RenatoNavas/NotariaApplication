using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class UsuarioNotaria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Clave { get; set; }

    public string? TokenRecovery { get; set; }

    public virtual ICollection<Cotizacion> Cotizaciones { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

    public string[] Roles { get; set; } = new string[0];
}
