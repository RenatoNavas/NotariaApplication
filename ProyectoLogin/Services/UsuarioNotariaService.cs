using Microsoft.EntityFrameworkCore;
using ProyectoLogin.Models;

namespace ProyectoLogin.Services
{
    public class UsuarioNotariaService : IUsuarioNotariaService
    {

        private readonly ApplicationDbContext _context;

        public UsuarioNotariaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioNotaria> GetUsuarioNotaria(string correo, string clave)
        {
            UsuarioNotaria usuario = await _context.UsuariosNotaria.Where(u => u.Correo == correo && u.Clave == clave)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<UsuarioNotaria> GetUsuarioNotariaPorCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                throw new ArgumentNullException(nameof(correo), "Correo electrónico no puede ser vacío o nulo.");
            }

            string correoLower = correo.ToLower();

            UsuarioNotaria usuario = await _context.UsuariosNotaria
                .FirstOrDefaultAsync(u => u.Correo.ToLower() == correoLower);

            return usuario;
        }

        public async Task<UsuarioNotaria> SaveUsuarioNotaria(UsuarioNotaria usuario)
        {
            _context.UsuariosNotaria.Add(usuario);
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

            UsuarioNotaria usuario = await _context.UsuariosNotaria
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

