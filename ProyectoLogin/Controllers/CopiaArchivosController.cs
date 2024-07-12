using Microsoft.AspNetCore.Mvc;

namespace ProyectoLogin.Controllers
{
    public class CopiaArchivosController : Controller
    {
        // Acción que renderiza la vista de Copia de Archivos
        public IActionResult CopiaArchivos()
        {
            return View();
        }
    }
}
