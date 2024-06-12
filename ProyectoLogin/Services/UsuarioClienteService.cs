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
                throw new ArgumentNullException(nameof(correo), "Correo electrónico no puede ser vacío o nullo.");
            }

            List<UsuarioCliente> usuarios = await _context.UsuarioCliente.ToListAsync();
            UsuarioCliente usuario = usuarios.FirstOrDefault(u => u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));

            return usuario;
        }

        public async Task<UsuarioCliente> SaveUsuarioCliente(UsuarioCliente usuario)
        {
            _context.UsuarioCliente.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

    }
}
