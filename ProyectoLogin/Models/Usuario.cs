using System;
using System.Collections.Generic;

namespace ProyectoLogin.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string? UrlfotoPerfil { get; set; }
}
