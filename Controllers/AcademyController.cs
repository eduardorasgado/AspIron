using Microsoft.AspNetCore.Mvc;
namespace AspIron.Controllers
{
    public class AcademyController : Controller
    {
        // IACtionResult representa una interfaz generica
        public IActionResult Index()
        {
            // retornando la vista con el mismo nombre de la funcion
            // dentro de la carpeta Academy
            return View();
        }
    }
}