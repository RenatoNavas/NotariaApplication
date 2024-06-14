using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Factura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProcesoId { get; set; }
    public int Numero { get; set; }
    public string? NombreCliente { get; set; }
    public string? CedulaCliente { get; set; }
    public string? CorreoCliente { get; set; }
    public string? DireccionCliente { get; set; }

    [ForeignKey("ProcesoId")]
    public virtual Proceso Proceso { get; set; }
}
