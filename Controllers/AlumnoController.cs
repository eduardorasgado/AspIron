using System.Collections.Generic;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspIron.Controllers
{
    public class AlumnoController : Controller
    {
        private AcademyContext _context;

        public AlumnoController(AcademyContext context)
        {
            // database context
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            var alumno = _context.Alumnos.FirstOrDefault();
            
            return View(alumno);
        }

        public IActionResult MultiAlumno()
        {
            // collecting all alumnos data from context -> in memory database
            var listaAlumnos = _context.Alumnos.ToList();
            
            return View(listaAlumnos);
        }
    }
}