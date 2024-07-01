using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ProyectoLogin.Controllers
{
    public class MaterializacionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IArchivoService _archivoService;

        public MaterializacionController(IArchivoService archivoService, ApplicationDbContext context)
        {
            _archivoService = archivoService;
            _context = context;
        }

        public async Task<IActionResult>
    Materializacion()
        {
            var archivos = await _context.Archivos.ToListAsync();

            return View(archivos);
        }

        [HttpPost]
        public async Task<IActionResult>
            AgregarArchivos(List<IFormFile>
                documentos)
        {
            foreach (var documento in documentos)
            {
                if (documento != null && documento.Length > 0)
                {
                    // Guardar el archivo en la base de datos o en algún almacenamiento
                    var archivo = new Archivo
                    {
                        Documento = documento.FileName,  // Nombre del archivo
                                                         // Asigna otros campos del archivo según tu modelo Archivo
                    };
                    _context.Archivos.Add(archivo);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Materializacion));
        }

        [HttpPost]
        public async Task<IActionResult>
            EliminarArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo != null)
            {
                _context.Archivos.Remove(archivo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Materializacion));
        }
    }
}
