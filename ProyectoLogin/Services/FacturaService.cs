using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly ApplicationDbContext _context;

        public FacturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Factura>> GetFacturas()
        {
            List<Factura> facturas = await _context.Facturas.ToListAsync();

            return facturas;
        }
    }
}
