using ProyectoLogin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoLogin.Services
{
    public interface IArchivoService
    {
        Task<List<Archivo>> GetArchivos();
    }
}
