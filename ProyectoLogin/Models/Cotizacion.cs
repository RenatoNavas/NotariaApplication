using System;
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
    public float ValorTotal { get; set; }
    public string? Documento { get; set; }
    public DateOnly? Fecha { get; set; }
    public bool Aceptacion { get; set; }

    [ForeignKey("ProcesoId")]
    public virtual Proceso Proceso { get; set; }
    [ForeignKey("UsuarioNotariaId")]
    public virtual UsuarioNotaria UsuarioNotaria { get; set; }
}
