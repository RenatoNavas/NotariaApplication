using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoLogin.Models;
using System;
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

        private int ObtenerProcesoIdActual()
        {
            var usuarioId = ObtenerUsuarioIdActual();

            // Buscar el último proceso en curso del usuario actual
            var proceso = _context.Procesos
                .Where(p => p.UsuarioClienteId == usuarioId && p.FechaFinalizacion == null)
                .OrderByDescending(p => p.FechaCreacion)
                .FirstOrDefault();

            return proceso != null ? proceso.Id : CrearNuevoProceso(usuarioId).Id;
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

        [HttpPost]
        public async Task<IActionResult> InformacionArchivos(Archivo arch)
        {
            arch.ProcesoId = ObtenerProcesoIdActual();

            // Convertir FechaOtorgamiento a UTC
            if (arch.FechaOtorgamiento.HasValue)
            {
                arch.FechaOtorgamiento = DateTime.SpecifyKind(arch.FechaOtorgamiento.Value, DateTimeKind.Utc);
            }

            _context.Archivos.Add(arch);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        public async Task<IActionResult> GenerarProforma(bool envio, string direccion, string telefono, string personaEntrega)
        {
            var procesoId = ObtenerProcesoIdActual();
            var proceso = await _context.Procesos.FindAsync(procesoId);

            if (proceso != null)
            {
                try
                {
                    // Actualizar proceso con los datos de envío
                    proceso.Envio = envio;
                    _context.Entry(proceso).State = EntityState.Modified;

                    // Obtener los archivos existentes del proceso
                    var archivosExistentes = await _context.Archivos
                        .Where(a => a.ProcesoId == procesoId)
                        .ToListAsync();

                    // Actualizar cada archivo con los nuevos datos
                    foreach (var archivo in archivosExistentes)
                    {
                        archivo.Direccion = direccion;
                        archivo.Telefono = telefono;
                        archivo.PersonaEntrega = personaEntrega;
                        _context.Entry(archivo).State = EntityState.Modified;
                    }

                    // Guardar los cambios
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }
                catch (DbUpdateException ex)
                {
                    // Capturar la excepción interna
                    var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return Json(new { success = false, errorMessage });
                }
            }

            return Json(new { success = false });
        }


        [HttpPost]
        public async Task<IActionResult> GuardarFactura(Factura factura)
        {
            factura.ProcesoId = ObtenerProcesoIdActual();
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Factura guardada correctamente.";

            return RedirectToAction(nameof(CopiaArchivos));
        }
    }
}
