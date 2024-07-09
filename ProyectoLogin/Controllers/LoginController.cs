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

        public LoginController(IUsuarioClienteService usuarioClienteService, ITipoProcesoService tipoProcesoservice, ApplicationDbContext context)
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

            UsuarioCliente usuarioExistente = await _usuarioClienteService.GetUsuarioClientePorCorreo(usuario.Correo);

            if (usuarioExistente != null)
            {
                ViewData["Mensaje"] = "Ya existe un usuario registrado con ese correo electrónico.";
                return View(usuario);
            }

            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);
            usuario.TokenRecovery = Utilidades.GenerarToken();
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
                new Claim(ClaimTypes.NameIdentifier, usuarioEncontrado.Id.ToString()),
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

        public IActionResult OlvidarContraseña(string token)
        {
            ViewBag.Token = token;
            return View();
        }

        public IActionResult RestablecerContraseña()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RestablecerContraseña(string correo)
        {
            UsuarioCliente user = await _usuarioClienteService.GetUsuarioClientePorCorreo(correo);
            ViewBag.Correo = correo;
            if (user != null)
            {
                bool respuesta = await _usuarioClienteService.ActualizarClave(user.TokenRecovery, user.Clave);
                if (respuesta)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "Plantilla", "Restablecer.html");
                    string content = await System.IO.File.ReadAllTextAsync(path);

                    string scheme = Request.Scheme;
                    string host = Request.Host.ToString();
                    string url = $"{scheme}://{host}/Login/OlvidarContraseña?token={user.TokenRecovery}";

                    string htmlBody = string.Format(content, user.Nombre, url);

                    Correo correoDTO = new Correo()
                    {
                        Para = correo,
                        Asunto = "Restablecer cuenta",
                        Contenido = htmlBody
                    };

                    bool enviado = CorreoServicio.Enviar(correoDTO);
                    ViewBag.Restablecido = true;
                }
            }
            else
            {
                ViewBag.Mensaje = "No se encontraron coincidencias con el correo";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OlvidarContraseña(string token, string clave, string confirmarClave)
        {
            ViewBag.Token = token;
            if (clave != confirmarClave)
            {
                ViewBag.Mensaje = "Las contraseñas no coinciden";
                return View();
            }

            bool respuesta = await _usuarioClienteService.ActualizarClave(token, Utilidades.EncriptarClave(clave));

            if (respuesta)
                ViewBag.Restablecido = true;
            else
                ViewBag.Mensaje = "No se pudo actualizar";

            return View();
        }
    }
}
