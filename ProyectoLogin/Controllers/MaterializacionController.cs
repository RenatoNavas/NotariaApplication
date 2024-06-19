using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class MaterializacionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITipoProcesoService _tipoProcesoService;
        private readonly IArchivoService _archivoService;
        private readonly ICotizacionService _cotizacionService;
        private readonly IFacturaService _facturaService;

        public MaterializacionController(IFacturaService facturaService, ICotizacionService cotizacionService, IArchivoService archivoService,  ITipoProcesoService tipoProcesoService, ApplicationDbContext context)
        {
            _tipoProcesoService = tipoProcesoService;
            _archivoService = archivoService;
            _cotizacionService = cotizacionService;
            _facturaService = facturaService;
            _context = context;
        }

        public async Task<IActionResult> Materializacion()
        {
            AllViewModel viewModel = new AllViewModel
            {
                TipoProcesos = await _tipoProcesoService.GetTipoProcesos(),
                Archivos = await _archivoService.GetArchivos(),
                Cotizaciones = await _cotizacionService.GetCotizaciones(),
                Facturas = await _facturaService.GetFacturas()

            };

            return View(viewModel);
        }
    }
}
