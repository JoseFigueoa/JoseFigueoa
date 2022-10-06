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
    public class MunicipioController : Controller
    {

        private readonly GestorDeActasNetContext _context;

        public MunicipioController(GestorDeActasNetContext context)
        {
            _context = context;
        }

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
            return View(new Municipio() { id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] Municipio _municipio)
        {
            try
            {
                MunicipioServices services = new MunicipioServices(_context);
                await services.Ingresar(_municipio);
                return StatusCode(200, new Respuesta(200, "Ok", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Actualizar([FromBody] Municipio _municipio)
        {
            try
            {
                MunicipioServices services = new MunicipioServices(_context);
                await services.Editar(_municipio);
                return StatusCode(200, new Respuesta(200, "Ok", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                MunicipioServices services = new MunicipioServices(_context);
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
                MunicipioServices services = new MunicipioServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await services.Obtener(id)));
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
                MunicipioServices services = new MunicipioServices(_context);

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

        [HttpGet]
        public async Task<IActionResult> ObtenerPorDepartamento(int id)
        {
            if (id == 0)
            {
                return StatusCode(400, new Respuesta(400, "No se encontro parametros", null));
            }

            try
            {
                MunicipioServices services = new MunicipioServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await services.ObtenerPorDepartamento(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }
        }

    }
}
