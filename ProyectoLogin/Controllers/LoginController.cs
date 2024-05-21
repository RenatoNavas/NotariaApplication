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
        private readonly IUsuarioService _usuarioService;
        private readonly IFilesService _filesService;
        private readonly UsuarioContext _context;

        public LoginController(IUsuarioService usuarioService, IFilesService filesService, UsuarioContext context)
        {
            _usuarioService = usuarioService;
            _filesService = filesService;
            _context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario, IFormFile Imagen)
        {
            // Verificar si ya existe un correo electrónico registrado
            Usuario usuarioExistente = await _usuarioService.GetUsuarioPorCorreo(usuario.Correo);

            if (usuarioExistente != null)
            {
                ViewData["Mensaje"] = "Ya existe un usuario registrado con ese correo electrónico.";
                return View(); // Retornar vista con mensaje de error
            }

            // Procesar la imagen si está presente
            string urlImagen = null;
            if (Imagen != null)
            {
                Stream image = Imagen.OpenReadStream();
                urlImagen = await _filesService.SubirArchivo(image, Imagen.FileName);
            }

            // Encriptar contraseña y asignar URL de la imagen (si existe)
            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);
            usuario.URLFotoPerfil = urlImagen;

            // Guardar usuario
            Usuario usuarioCreado = await _usuarioService.SaveUsuario(usuario);

            if (usuarioCreado.Id > 0)
            {
                return RedirectToAction("IniciarSesion", "Login");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }


        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(correo, Utilidades.EncriptarClave(clave));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "Correo o contraseña incorrectos";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario)
            };

            // Agregar el Claim de la foto de perfil solo si existe
            if (!string.IsNullOrEmpty(usuarioEncontrado.URLFotoPerfil))
            {
                claims.Add(new Claim("FotoPerfil", usuarioEncontrado.URLFotoPerfil));
            }

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
