using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public class TipoProcesoService : ITipoProcesoService
    {
        private readonly ApplicationDbContext _context;

        public TipoProcesoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TipoProceso> GetTipoProcesoMaterializacion()
        {
            TipoProceso tipoProceso = await _context.TipoProcesos
                .FirstOrDefaultAsync(tp => tp.Id == 1);

            return tipoProceso;
        }
        public async Task<TipoProceso> GetTipoProcesoCopiaArchivos()
        {
            TipoProceso tipoProceso = await _context.TipoProcesos
                .FirstOrDefaultAsync(tp => tp.Id == 2);

            return tipoProceso;
        }

    }
}
