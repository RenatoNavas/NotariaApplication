using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public interface IUsuarioClienteService
    {
        Task<UsuarioCliente> GetUsuarioCliente(string correo, string clave);
        Task<UsuarioCliente> GetUsuarioClientePorCorreo(string correo);
        Task<UsuarioCliente> SaveUsuarioCliente(UsuarioCliente usuario);
        Task<bool> ActualizarClave(string token, string nuevaClave);
    }
}
