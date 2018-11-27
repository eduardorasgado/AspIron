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
            var escuela = new Academy();
            escuela.FundationYear = 2017;
            escuela.Name = "AspIron";
            // returning the view with same name as actual function
            // inside Academy folder
            return View(escuela);
        }
    }
}