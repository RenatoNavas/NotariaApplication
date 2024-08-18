using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public interface IUsuarioNotariaService
    {
        Task<UsuarioNotaria> GetUsuarioNotaria(string correo, string clave);
        Task<UsuarioNotaria> GetUsuarioNotariaPorCorreo(string correo);
        Task<UsuarioNotaria> SaveUsuarioNotaria(UsuarioNotaria usuario);
        Task<bool> ActualizarClave(string token, string nuevaClave);
    }
}
