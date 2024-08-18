using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoLogin.Models;
using ProyectoLogin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoLogin.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioNotariaService _usuarioNotariaService;
        private readonly ITipoProcesoService _tipoProcesoservice;
        private readonly ApplicationDbContext _context;

        public UsuarioController(IUsuarioNotariaService usuarioNotariaService, ITipoProcesoService tipoProcesoservice, ApplicationDbContext context)
        {
            _usuarioNotariaService = usuarioNotariaService;
            _tipoProcesoservice = tipoProcesoservice;
            _context = context;
        }
        public IActionResult Usuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Usuario(UsuarioNotaria usuario)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Mensaje"] = "Datos inválidos.";
                return View(usuario);
            }

            UsuarioNotaria usuarioExistente = await _usuarioNotariaService.GetUsuarioNotariaPorCorreo(usuario.Correo);

            if (usuarioExistente != null)
            {
                ViewData["Mensaje"] = "Ya existe un usuario registrado con ese correo electrónico.";
                return View(usuario);
            }

            usuario.Clave = Utilidades.EncriptarClave(usuario.Clave);
            usuario.TokenRecovery = Utilidades.GenerarToken();
            UsuarioNotaria usuarioCreado = await _usuarioNotariaService.SaveUsuarioNotaria(usuario);

            if (usuarioCreado.Id > 0)
            {
                ViewBag.MensajeExito = "Usuario creado con éxito.";
                return View(usuario); // Mantiene al usuario en la misma vista
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View(usuario);
        }


    }
}
