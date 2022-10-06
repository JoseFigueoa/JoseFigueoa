using Gestor2._0.Data.DB_BASE;
using Gestor2._0.Models;
using Gestor2._0.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestor2._0.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {

        private readonly GestorDeActasNetContext _context;

        public DepartamentoController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        // Metodos desde ASP.NET

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nuevo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            return View(new Departamento { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Departamento _departamento)
        {
            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                await services.Ingresar(_departamento);
                return StatusCode(200, new Respuesta(200, "Ok", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }

        }



        [HttpPost]
        public async Task<IActionResult> Actualizar([FromBody] Departamento _departamento)
        {
            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                await services.Editar(_departamento);
                return StatusCode(200, new Respuesta(200, "Ok", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }
        }

        // Metodo AJAX

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await services.Obtener()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Obtener(int id)
        {
            if (id == 0)
            {
                return StatusCode(400, new Respuesta(400, "No se encontro parametros", null));
            }

            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await services.Obtener(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPorPais(int id)
        {
            if (id == 0)
            {
                return StatusCode(400, new Respuesta(400, "No se encontro parametros", null));
            }

            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await services.ObtenerPorPais(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (id == 0)
            {
                return StatusCode(400, new Respuesta(400, "No se encontro parametros", null));
            }

            try
            {
                DepartamentoServices services = new DepartamentoServices(_context);
                if (await services.Eliminar(id))
                    return StatusCode(200, new Respuesta(200, "Ok", null));
                else
                    return StatusCode(200, new Respuesta(1500, "No se pudo eliminar el registro", null));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }
        }

    }
}
