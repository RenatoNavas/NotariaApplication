using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly ApplicationDbContext _context;

        public ArchivoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Archivo>> GetArchivos()
        {
            List<Archivo> archivos = await _context.Archivos.ToListAsync();

            return archivos;
        }
    }
}
