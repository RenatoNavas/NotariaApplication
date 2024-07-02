using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
            var archivos = await _context.Archivos.ToListAsync();
            return View(archivos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarArchivos(List<IFormFile> documentos)
        {
            foreach (var documento in documentos)
            {
                if (documento != null && documento.Length > 0)
                {
                    // Generar un nombre único para el archivo
                    var fileName = Path.GetFileName(documento.FileName);
                    var filePath = Path.Combine(_storagePath, fileName);

                    // Guardar el archivo en la ruta especificada
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await documento.CopyToAsync(stream);
                    }

                    // Guardar solo el nombre del archivo en la base de datos
                    var archivo = new Archivo
                    {
                        Documento = filePath,  // Guardar solo el nombre del archivo en la base de datos
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
    }
}
