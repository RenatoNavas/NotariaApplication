using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Permiso
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int OpcionId { get; set; }
    public int UsuarioClienteId { get; set; }
    public int UsuarioNotariaId { get; set; }

    [ForeignKey("OpcionId")]
    public virtual Opcion Opcion { get; set; }
    [ForeignKey("UsuarioClienteId")]
    public virtual UsuarioCliente UsuarioCliente { get; set; }
    [ForeignKey("UsuarioNotariaId")]
    public virtual UsuarioNotaria UsuarioNotaria { get; set; }
}
