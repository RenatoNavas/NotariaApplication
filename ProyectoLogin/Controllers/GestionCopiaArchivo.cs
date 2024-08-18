using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class GestionCopiaArchivoController : Controller
    {
        private readonly IUsuarioNotariaService _usuarioNotariaService;
        private readonly ITipoProcesoService _tipoProcesoservice;
        private readonly IProcesoService _procesoService;

        public GestionCopiaArchivoController(IUsuarioNotariaService usuarioNotariaService, ITipoProcesoService tipoProcesoservice, IProcesoService procesoService)
        {
            _usuarioNotariaService = usuarioNotariaService;
            _tipoProcesoservice = tipoProcesoservice;
            _procesoService = procesoService;
        }

        // Acción para mostrar la vista con los procesos cargados
        public async Task<IActionResult> GestionCopiaArchivo()
        {
            var procesos = await _procesoService.ObtenerTodosLosProcesosCopiasArchivo();
            return View(procesos);
        }
    }
}
