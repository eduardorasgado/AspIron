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
        
        [Route("Alumno/Index/{alumnoId}")]
        [Route("Alumno/Index")]
        // GET
        public IActionResult Index(string alumnoId)
        {
            var alList = from alumno in _context.Alumnos
                where alumno.Id == alumnoId
                select alumno;
            
            // validation
            return !string.IsNullOrWhiteSpace(alumnoId)
                // a) if MultiAlumno is called from Index, we should
                // specify what view should we return in MultiAlumno
                // or it will return to Index view
                ? View(alList.SingleOrDefault()) : MultiAlumno();
        }

        public IActionResult MultiAlumno()
        {
            // collecting all alumnos data from context -> in memory database
            var listaAlumnos = _context.Alumnos.ToList();
            
            // a)
            return View("MultiAlumno", listaAlumnos);
        }
    }
}