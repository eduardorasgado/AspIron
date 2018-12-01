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
        
        [Route("Alumno/Index")]
        [Route("Alumno/Index/{alumnoId}")]
        // GET
        public IActionResult Index(string alumnoId)
        {
            var alList = from alumno in _context.Alumnos
                where alumno.Id == alumnoId
                select alumno;
            
            return View(alList.SingleOrDefault());
        }

        public IActionResult MultiAlumno()
        {
            // collecting all alumnos data from context -> in memory database
            var listaAlumnos = _context.Alumnos.ToList();
            
            return View(listaAlumnos);
        }
    }
}