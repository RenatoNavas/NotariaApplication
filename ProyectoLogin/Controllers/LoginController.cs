using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System.Security.Claims;

namespace ProyectoLogin.Controllers
{

    public class LoginController : Controller
    {
        private readonly IUsuarioClienteService _usuarioClienteService;
        private readonly ITipoProcesoService _tipoProcesoservice;

        private readonly ApplicationDbContext _context;

        public LoginController(IUsuarioClienteService usuarioClienteService, ITipoProcesoService tipoProcesoservice ,ApplicationDbContext context)
        {
            _usuarioClienteService = usuarioClienteService;
            _tipoProcesoservice = tipoProcesoservice;
            _context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioCliente usuario)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Mensaje"] = "Datos inválidos.";
                return View(usuario);
            }

            // Verificar si ya existe un correo electrónico registrado
            UsuarioCliente usuarioExistente = await _usuarioClienteService.GetUsuarioClientePorCorreo(usuario.Correo);

            if (usuarioExistente != null)
            {
                ViewData["Mensaje"] = "Ya existe un usuario registrado con ese correo electrónico.";
                return View(usuario); // Retornar vista con mensaje de error
            }

            // Procesar la imagen si está presente

            // Encriptar contraseña y asignar URL de la imagen (si existe)
            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);

            // Guardar usuario
            UsuarioCliente usuarioCreado = await _usuarioClienteService.SaveUsuarioCliente(usuario);


            if (usuarioCreado.Id > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View(usuario);
        }


        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            UsuarioCliente usuarioEncontrado = await _usuarioClienteService.GetUsuarioCliente(correo, Utilidades.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Correo o contraseña incorrectos";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.Nombre)
            };


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
            );

            return RedirectToAction("Index", "Home");
        }

        public IActionResult OlvidarContraseña()
        {
            return View();
        }

        public IActionResult RestablecerContraseña()
        {
            return View();
        }



    }
}