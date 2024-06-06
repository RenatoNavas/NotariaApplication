using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Permiso
{
    public long OpId { get; set; }

    public int UsunotId { get; set; }

    public int UsucliId { get; set; }

    public long PerId { get; set; }

    public virtual Opcione Op { get; set; } = null!;

    public virtual UsuarioCliente Usucli { get; set; } = null!;

    public virtual UsuarioNotarium Usunot { get; set; } = null!;
}
