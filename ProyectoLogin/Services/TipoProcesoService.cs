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

        public async Task<List<TipoProceso>> GetTipoProcesos()
        {
            List<TipoProceso> tipoProcesos = await _context.TipoProcesos.ToListAsync();

            return tipoProcesos;
        }
    }
}
