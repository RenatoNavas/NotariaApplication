using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public interface ITipoProcesoService
    {
        Task<TipoProceso> GetTipoProcesoMaterializacion();
    }
}
