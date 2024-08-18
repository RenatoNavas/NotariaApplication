using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public class ProcesoService : IProcesoService
    {
        private readonly ApplicationDbContext _context;

        public ProcesoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<Proceso, List<Archivo>>> ObtenerTodosLosProcesosMaterializacion()
        {
            // Obtén todos los procesos con TipoProceso.Id igual a 1
            var procesos = await _context.Procesos
                                         .Where(p => p.TipoProceso.Id == 1)
                                         .Include(p => p.TipoProceso)
                                         .Include(p => p.UsuarioCliente)
                                         .ToListAsync();

            // Obtén todos los archivos correspondientes a los procesos filtrados
            var archivos = await _context.Archivos
                                         .Where(a => procesos.Select(p => p.Id).Contains(a.ProcesoId))
                                         .ToListAsync();

            // Crear un diccionario para almacenar los procesos y sus archivos
            var procesosConArchivos = new Dictionary<Proceso, List<Archivo>>();

            // Asignar los archivos correspondientes a cada proceso en el diccionario
            foreach (var proceso in procesos)
            {
                var archivosProceso = archivos.Where(a => a.ProcesoId == proceso.Id).ToList();
                procesosConArchivos.Add(proceso, archivosProceso);
            }

            return procesosConArchivos;
        }

        public async Task<IEnumerable<Proceso>> ObtenerTodosLosProcesosCopiasArchivo()
        {
            return await _context.Procesos
                                 .Where(p => p.TipoProceso.Id == 2)
                                 .Include(p => p.TipoProceso)
                                 .Include(p => p.UsuarioCliente)
                                 .ToListAsync();
        }

        public async Task GuardarArchivo(int procesoId, string rutaArchivo)
        {
            var archivo = new Archivo
            {
                ProcesoId = procesoId,
                Documento = rutaArchivo
            };

            _context.Archivos.Add(archivo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CancelarProceso(int procesoId)
        {
            var proceso = await _context.Procesos.FindAsync(procesoId);
            if (proceso == null)
            {
                return false;
            }

            proceso.Estado = "Cancelado";
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
