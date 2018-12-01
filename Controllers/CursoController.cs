using System.Collections.Generic;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspIron.Controllers
{
    public class CursoController : Controller
    {
        private AcademyContext _context;

        public CursoController(AcademyContext context)
        {
            // database context
            _context = context;
        }
        
        [Route("Curso/Index/{cursoId}")]
        [Route("Curso/Index")]
        // GET
        public IActionResult Index(string cursoId)
        {
            var alList = from curso in _context.Cursos
                where curso.Id == cursoId
                select curso;
            
            // validation
            return !string.IsNullOrWhiteSpace(cursoId)
                // a)
                // if MultiAlumno is called from Index, we should
                // specify what view should we return in MultiAlumno
                // or it will return to Index view
                ? View(alList.SingleOrDefault()) : MultiCurso();
        }

        public IActionResult MultiCurso()
        {
            // collecting all alumnos data from context -> in memory database
            var listaCursos = _context.Cursos.ToList();
            
            // a)
            return View("MultiCurso", listaCursos);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}