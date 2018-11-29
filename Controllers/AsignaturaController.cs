using System;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspIron.Controllers
{
    public class AsignaturaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var asignatura1 = new Asignatura();
            asignatura1.Nombre = "Patrones de Diseño";
            ViewBag.FechaDeLanzamiento = DateTime.UtcNow;
            return View(asignatura1);
        }
    }
}