using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class GestionMaterializacionController : Controller
    {
        private readonly IProcesoService _procesoService;
        private readonly ApplicationDbContext _context;

        public GestionMaterializacionController(IProcesoService procesoService, ApplicationDbContext context)
        {
            _procesoService = procesoService;
            _context = context;
        }

        public async Task<IActionResult> GestionMaterializacion()
        {
            var procesos = await _procesoService.ObtenerTodosLosProcesosMaterializacion();
            return View(procesos);
        }

        [HttpPost]
        public async Task<IActionResult> SubirArchivo(int procesoId, IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                // Ruta para guardar el archivo
                var filePath = Path.Combine("wwwroot/uploads", archivo.FileName);

                // Guardar el archivo en la ruta especificada
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                // Obtener el ID del usuario autenticado
                var usuarioNotariaId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Crear una nueva instancia de Cotizacion y llenar los campos
                var cotizacion = new Cotizacion
                {
                    ProcesoId = procesoId,
                    UsuarioNotariaId = int.Parse(usuarioNotariaId), // Convertir a entero
                    ValorTotal = 0, // Puedes ajustar esto según sea necesario
                    Documento = filePath, // Guardar la ruta del archivo
                    Fecha = DateOnly.FromDateTime(DateTime.Now),
                    Aceptacion = false // Por defecto no aceptado, puede cambiarse luego
                };

                // Guardar la cotización en la base de datos
                _context.Cotizaciones.Add(cotizacion);
                await _context.SaveChangesAsync();

                TempData["MensajeExito"] = "Archivo subido y cotización creada con éxito.";
            }
            else
            {
                TempData["MensajeError"] = "No se pudo subir el archivo.";
            }

            return RedirectToAction("GestionMaterializacion");
        }

        [HttpPost]
        public async Task<IActionResult> CancelarProceso(int id)
        {
            var result = await _procesoService.CancelarProceso(id);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
