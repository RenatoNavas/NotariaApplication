using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public class CotizacionService : ICotizacionService
    {
        private readonly ApplicationDbContext _context;

        public CotizacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cotizacion>> GetCotizaciones()
        {
            List<Cotizacion> cotizaciones = await _context.Cotizaciones.ToListAsync();

            return cotizaciones;
        }
    }
}
