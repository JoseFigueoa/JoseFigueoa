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
    public class PaisController : Controller
    {

        private readonly GestorDeActasNetContext _context;

        public PaisController(GestorDeActasNetContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            try
            {
                PaisServices Pais = new PaisServices(_context);
                return StatusCode(200, new Respuesta(200, "Ok", await Pais.ObtenerPaises()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Respuesta(500, ex.Message, null));
            }
        }

    }
}
