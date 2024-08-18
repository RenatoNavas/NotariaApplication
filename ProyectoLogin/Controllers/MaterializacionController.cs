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
    public class MaterializacionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _storagePath;

        public MaterializacionController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _storagePath = configuration["FileStorage:Path"];
        }

        public async Task<IActionResult> Materializacion()
        {
            var usuarioId = ObtenerUsuarioIdActual();

            // Verificar si ya existe un proceso en curso para el usuario actual
            var proceso = await _context.Procesos
                .Where(p => p.UsuarioClienteId == usuarioId && p.FechaFinalizacion == null)
                .FirstOrDefaultAsync();

            // Si no existe, crear un nuevo proceso automáticamente
            if (proceso == null)
            {
                proceso = CrearNuevoProceso(usuarioId);
            }

            // Obtener archivos relacionados con el proceso actual
            var archivos = await _context.Archivos
                .Where(a => a.ProcesoId == proceso.Id)
                .ToListAsync();

            return View(archivos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarArchivos(List<IFormFile> documentos)
        {
            foreach (var documento in documentos)
            {
                if (documento != null && documento.Length > 0)
                {
                    var fileName = Path.GetFileName(documento.FileName);
                    var filePath = Path.Combine(_storagePath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await documento.CopyToAsync(stream);
                    }

                    var archivo = new Archivo
                    {
                        Documento = filePath,
                        ProcesoId = ObtenerProcesoIdActual()
                    };

                    _context.Archivos.Add(archivo);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Materializacion));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo != null)
            {
                var filePath = Path.Combine(_storagePath, archivo.Documento);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.Archivos.Remove(archivo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Materializacion));
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
                TipoProcesoId = 1,  // Ajustar según el tipo de proceso deseado
                UsuarioClienteId = usuarioId
            };

            _context.Procesos.Add(proceso);
            _context.SaveChanges();

            return proceso;
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

                    TempData["Mensaje"] = "Su proforma está siendo generada, un funcionario se comunicará con usted.";
                    TempData["ArchivosEnviados"] = true;  // Marcar que los archivos han sido enviados
                    ViewBag.ProcesoId = procesoId;

                    return RedirectToAction(nameof(Materializacion));
                }
                catch (DbUpdateException ex)
                {
                    // Capturar la excepción interna
                    var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    TempData["Error"] = $"Ocurrió un error al guardar los cambios: {errorMessage}";
                }
            }

            return RedirectToAction(nameof(Materializacion));
        }

        [HttpPost]
        public async Task<IActionResult> GuardarFactura(Factura factura)
        {
            factura.ProcesoId = ObtenerProcesoIdActual();
                _context.Facturas.Add(factura);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = "Factura guardada correctamente. Un funcionario se comunicará con usted para confirmar el envío de los documentos";

            return RedirectToAction(nameof(Materializacion));
        }



    }
}
