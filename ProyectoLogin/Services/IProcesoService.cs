using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public interface IProcesoService
    {
        Task<Dictionary<Proceso, List<Archivo>>> ObtenerTodosLosProcesosMaterializacion();
        Task<IEnumerable<Proceso>> ObtenerTodosLosProcesosCopiasArchivo();
        Task GuardarArchivo(int procesoId, string rutaArchivo);
        Task<bool> CancelarProceso(int procesoId);
        Task<Dictionary<Proceso, List<Cotizacion>>> ObtenerProcesosConCotizacionesPorUsuario(int usuarioClienteId);
        Task<bool> ActualizarEstadoProceso(int procesoId, string nuevoEstado);
    }
}
