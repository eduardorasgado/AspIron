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
        
        [HttpPost] // this will lead the form data to be handle
        public IActionResult Create(Curso curso)
        {
            // if model is corrupted
            // corrupted -> [Required] data annotation in Curso model
            // is not checked
            if (!ModelState.IsValid) return View(curso);
            
            var escuela = _context.Academies.FirstOrDefault();
            // add curso to db
            curso.AcademyId = escuela.Id;
                
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            ViewBag.MensajeExtra = "Curso Creado con éxito!";
            
            // return to individual view(Note: Not method Index,
            // Index view instead)
            return View("Index", curso);
        }
    }
}