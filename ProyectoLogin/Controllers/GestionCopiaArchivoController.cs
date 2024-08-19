using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class GestionCopiaArchivoController : Controller
    {
        private readonly IUsuarioNotariaService _usuarioNotariaService;
        private readonly ITipoProcesoService _tipoProcesoservice;
        private readonly IProcesoService _procesoService;
        private readonly ApplicationDbContext _context;
        private readonly string _storagePath;


        public GestionCopiaArchivoController(IUsuarioNotariaService usuarioNotariaService, ITipoProcesoService tipoProcesoservice, IProcesoService procesoService, ApplicationDbContext context, IConfiguration configuration)
        {
            _usuarioNotariaService = usuarioNotariaService;
            _tipoProcesoservice = tipoProcesoservice;
            _procesoService = procesoService;
            _context = context;
            _storagePath = configuration["FileStorage:Proforma"];

        }

        // Acción para mostrar la vista con los procesos cargados
        public async Task<IActionResult> GestionCopiaArchivo()
        {
            var procesos = await _procesoService.ObtenerTodosLosProcesosCopiasArchivo();
            return View(procesos);
        }

        [HttpPost]
        public async Task<IActionResult> SubirArchivo(int procesoId, IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                // Ruta para guardar el archivo
                var filePath = Path.Combine(_storagePath, archivo.FileName);

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

            return RedirectToAction("GestionCopiaArchivo");
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
