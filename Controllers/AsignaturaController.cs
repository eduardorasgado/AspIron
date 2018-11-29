using AspIron.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspIron.Controllers
{
    public class AsignaturaController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}