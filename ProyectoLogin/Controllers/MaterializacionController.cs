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
    }
}
