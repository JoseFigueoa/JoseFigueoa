using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebGestorActas.Controllers
{
    public class ActasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
