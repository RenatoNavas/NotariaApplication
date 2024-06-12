using Microsoft.EntityFrameworkCore;

namespace ProyectoLogin.Models
{
    public class UsuarioClienteContext : DbContext
    {
        public UsuarioClienteContext(DbContextOptions<UsuarioClienteContext> options) : base(options)
        {
        }

        public DbSet<UsuarioCliente> UsuarioCliente { get; set; }
    }
}
