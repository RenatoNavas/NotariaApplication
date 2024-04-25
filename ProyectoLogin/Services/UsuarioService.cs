using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioContext _context;

        public UsuarioService(UsuarioContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario = await _context.Usuarios.Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuarioPorCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                throw new ArgumentNullException(nameof(correo), "Correo electrónico no puede ser vacío o nullo.");
            }

            List<Usuario> usuarios = await _context.Usuarios.ToListAsync();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));

            return usuario;
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

    }
}
