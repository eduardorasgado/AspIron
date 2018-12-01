using System.Linq;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
namespace AspIron.Controllers
{
    public class AcademyController : Controller
    {
        private AcademyContext _context;
        // IACtionResult represents a generic interface
        public IActionResult Index()
        {
             
            // take database data for academy
            var escuela = _context.Academies.FirstOrDefault();
            
            return View(escuela);
        }

        /// <summary>
        /// Constructor to addapt controller to be able to have
        /// access to in memory database
        /// </summary>
        /// <param name="???"></param>
        public AcademyController(AcademyContext context) 
            => _context = context;
    }
}