﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLogin.Models
{
    public partial class Archivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Documento { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? PersonaEntrega { get; set; }

        // Usa DateTime en lugar de DateOnly temporalmente para pruebas
        public DateTime? FechaOtorgamiento { get; set; }

        public string? TipoActo { get; set; }

        public int ProcesoId { get; set; }
        [ForeignKey("ProcesoId")]
        public virtual Proceso Proceso { get; set; }
    }
}