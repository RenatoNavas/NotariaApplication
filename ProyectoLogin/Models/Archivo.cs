using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Archivo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Documento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? PersonaEntrega { get; set; }

    public DateOnly? FechaOtorgamiento { get; set; }

    public string? TipoActo { get; set; }

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
