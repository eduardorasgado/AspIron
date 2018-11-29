using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
namespace AspIron.Controllers
{
    public class AcademyController : Controller
    {
        // IACtionResult represents a generic interface
        public IActionResult Index()
        {
            // a model object
            var escuela = new Academy("AspIron", 2017);
            escuela.Ciudad = "Cd del Carmén, Campeche";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuelas.Online;
            escuela.Direccion = "Av. Naufrago #104, Colonia Morelos. Zona Cocoa.";
            
            // returning the view with same name as actual function
            // inside Academy folder
            ViewBag.DatoDinamico = "Curso de ASP.NET MVC";
            return View(escuela);
        }
    }
}