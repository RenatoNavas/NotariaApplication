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

        public MaterializacionController(ITipoProcesoService tipoProcesoService, ApplicationDbContext context)
        {
            _tipoProcesoService = tipoProcesoService;
            _context = context;
        }

        public async Task<IActionResult> Materializacion()
        {
            TipoProceso tipoProceso = await _tipoProcesoService.GetTipoProcesoMaterializacion();


            AllViewModel viewModel = new AllViewModel
            {
                TipoProcesos = tipoProceso != null ? new List<TipoProceso> { tipoProceso } : new List<TipoProceso>()
            };

            return View(viewModel);
        }

    }
}
