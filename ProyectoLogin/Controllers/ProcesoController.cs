using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class ProcesoController : Controller
    {
        private readonly IUsuarioNotariaService _usuarioNotariaService;
        private readonly ITipoProcesoService _tipoProcesoservice;
        private readonly IProcesoService _procesoService;
        private readonly ApplicationDbContext _context;
        private readonly string _storagePath;

        public ProcesoController(IUsuarioNotariaService usuarioNotariaService, ITipoProcesoService tipoProcesoservice, IProcesoService procesoService, ApplicationDbContext context, IConfiguration configuration)
        {
            _usuarioNotariaService = usuarioNotariaService;
            _tipoProcesoservice = tipoProcesoservice;
            _procesoService = procesoService;
            _context = context;
            _storagePath = configuration["FileStorage:Proforma"];
        }

        // Acción para mostrar la vista con los procesos cargados
        public async Task<IActionResult> Proceso(int usuarioClienteId)
        {
            // Obtener los procesos y sus cotizaciones para el usuario específico
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var procesosConCotizaciones = await _procesoService.ObtenerProcesosConCotizacionesPorUsuario(int.Parse(userId));
            return View(procesosConCotizaciones);
        }

        [HttpGet]
        public IActionResult DescargarArchivo(string rutaArchivo)
        {
            if (System.IO.File.Exists(rutaArchivo))
            {
                var nombreArchivo = System.IO.Path.GetFileName(rutaArchivo);
                var archivoBytes = System.IO.File.ReadAllBytes(rutaArchivo);
                return File(archivoBytes, "application/octet-stream", nombreArchivo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AceptarProforma(int id)
        {
            var success = await _procesoService.ActualizarEstadoProceso(id, "Aceptado");
            if (success)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> RechazarProforma(int id)
        {
            var success = await _procesoService.ActualizarEstadoProceso(id, "Cancelado");
            if (success)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}
