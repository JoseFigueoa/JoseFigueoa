using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Gestor2._0.Models;
using Gestor2._0.Services;
using Gestor2._0.Data.DB_BASE;

namespace Gestor2._0.Controllers
{
    public class LoginController : Controller
    {
        private readonly GestorDeActasNetContext _context;

        public LoginController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Iniciar(Usuario _usuario)
        {

            if (_usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            SecurityServices security = new SecurityServices();
            _usuario.password = security.Encrypt(_usuario.password, int.Parse("256"));

            UsuarioServices usuarioServices = new UsuarioServices(_context);
            Usuario usuario = usuarioServices.ObtenerUsuarioLogin(_usuario);

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.usuario),
                    new Claim(ClaimTypes.Role, "Administrador")
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Cerrar()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> ValidarUsuario([FromBody] Usuario _usuario)
        {

            if (_usuario == null)
            {
                return StatusCode(401, new Respuesta(211, "Faltan parametros", null));
            }

            SecurityServices security = new SecurityServices();
            _usuario.password = security.Encrypt(_usuario.password, int.Parse("256"));

            UsuarioServices usuarioServices = new UsuarioServices(_context);
            Usuario usuario = usuarioServices.ObtenerUsuarioLogin(_usuario);

            if (usuario == null)
            {
                return StatusCode(401, new Respuesta(210, "Usuario o contraseña incorrectos", null));
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.usuario),
                    new Claim(ClaimTypes.Role, "Administrador")
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return StatusCode(200, new Respuesta(200, "Usuario o contraseña incorrecto", null));

        }


    }
}
