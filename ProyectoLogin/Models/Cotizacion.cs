using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Cotizacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProcesoId { get; set; }

    public int UsuarioNotariaId { get; set; }

    public double? ValorTotal { get; set; }

    public string? Documento { get; set; }

    public DateOnly? Fecha { get; set; }

    public bool? Aceptacion { get; set; }

    public virtual Proceso Pro { get; set; } = null!;

    public virtual UsuarioNotaria Usunot { get; set; } = null!;
}
