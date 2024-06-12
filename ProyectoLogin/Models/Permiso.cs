using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models;

public partial class Permiso
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int OpcionId { get; set; }

    public int UsuarioNotariaId { get; set; }

    public int UsuarioClienteId { get; set; }

    public virtual Opcion Op { get; set; } = null!;

    public virtual UsuarioCliente Usucli { get; set; } = null!;

    public virtual UsuarioNotaria Usunot { get; set; } = null!;
}
