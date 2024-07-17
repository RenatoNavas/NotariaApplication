using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoLogin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class CopiaArchivosController : Controller
    {
        private readonly ApplicationDbContext _context;
     

        public CopiaArchivosController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
    
        }

        public async Task<IActionResult> CopiaArchivos()
        {
            var usuarioId = ObtenerUsuarioIdActual();

            // Verificar si ya existe un proceso en curso para el usuario actual
            var proceso = await _context.Procesos
                .Where(p => p.UsuarioClienteId == usuarioId && p.FechaFinalizacion == null && p.TipoProcesoId == 2)
                .FirstOrDefaultAsync();

            // Si no existe, crear un nuevo proceso automáticamente
            if (proceso == null)
            {
                proceso = CrearNuevoProceso(usuarioId);
            }

            // Crear un nuevo objeto Archivo para pasarlo a la vista
            var archivo = new Archivo
            {
                ProcesoId = proceso.Id  // Asignar el ProcesoId al nuevo archivo
            };

            return View(archivo); // Pasamos el archivo como modelo a la vista
        }


        private int ObtenerUsuarioIdActual()
        {
            var usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return usuarioId;
        }

        private Proceso CrearNuevoProceso(int usuarioId)
        {
            var proceso = new Proceso
            {
                Estado = "En Progreso",
                Observacion = "Ninguna",
                FechaCreacion = DateTime.UtcNow,
                TipoProcesoId = 2,  // Ajustar según el tipo de proceso deseado
                UsuarioClienteId = usuarioId
            };

            _context.Procesos.Add(proceso);
            _context.SaveChanges();

            return proceso;
        }

        



    }
}
