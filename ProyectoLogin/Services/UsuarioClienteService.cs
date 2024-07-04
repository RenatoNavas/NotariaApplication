using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public class UsuarioClienteService : IUsuarioClienteService
    {
        private readonly UsuarioClienteContext _context;

        public UsuarioClienteService(UsuarioClienteContext context)
        {
            _context = context;
        }

        public async Task<UsuarioCliente> GetUsuarioCliente(string correo, string clave)
        {
            UsuarioCliente usuario = await _context.UsuarioCliente.Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<UsuarioCliente> GetUsuarioClientePorCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                throw new ArgumentNullException(nameof(correo), "Correo electrónico no puede ser vacío o nulo.");
            }

            string correoLower = correo.ToLower();

            UsuarioCliente usuario = await _context.UsuarioCliente
                .FirstOrDefaultAsync(u => u.Correo.ToLower() == correoLower);

            return usuario;
        }

        public async Task<UsuarioCliente> SaveUsuarioCliente(UsuarioCliente usuario)
        {
            _context.UsuarioCliente.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ActualizarClave(string token, string nuevaClave)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(nuevaClave))
            {
                return false;
            }

            token = token.Trim();

            UsuarioCliente usuario = await _context.UsuarioCliente
                .FirstOrDefaultAsync(u => u.TokenRecovery == token);

            if (usuario != null)
            {
                usuario.Clave = nuevaClave;
                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }

}

