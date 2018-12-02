using System;
using System.Collections.Generic;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

            // checking if name is not repeated in db
            var actionResult = CheckRepeatedName(curso);
            if (actionResult != null) return actionResult;

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

        [Route("Curso/Update")]
        [Route("Curso/Update/{cursoId}")]
        public IActionResult Update(string cursoId)
        {
            var cursoResponse = from curso in _context.Cursos
                where curso.Id == cursoId
                select curso;

            // validation: cursoId is available
            if (string.IsNullOrWhiteSpace(cursoId)) return MultiCurso();
            
            return View(cursoResponse.SingleOrDefault());
        }


        [Route("Curso/Update/{cursoId}")]
        [HttpPost]
        public IActionResult UpdatePost(string cursoId, Curso cursoForm)
        {   
            var curso = _context.Cursos.Find(cursoId);
            
            // validating all required data
            if (!ModelState.IsValid) return View("Update", curso);

            // search and extract the course to be updated
            // from db
            var modelCurso = _context.Cursos
                .SingleOrDefault(c => c.Id == cursoId);
            
            // updating fields
            // in case curso does not exist
            if (modelCurso == null) return MultiCurso();

            modelCurso.Nombre = cursoForm.Nombre;
            modelCurso.Direccion = cursoForm.Direccion;
            modelCurso.Jornada = cursoForm.Jornada;
            
            // saving updated data
            _context.SaveChanges();
            
            ViewBag.MensajeExtra = "Curso Actualizado con éxito!";
            
            // return to individual view(Note: Not method Index,
            // Index view instead)
            // add the course searched
            return View("Index",curso);
        }
        
        private IActionResult CheckRepeatedName(Curso curso)
        {
            try
            {
                var repeatedCurso = from c in _context.Cursos
                    where c.Nombre == curso.Nombre
                    select c;

                if (repeatedCurso.SingleOrDefault() != null)
                {
                    // in case name already exists
                    ViewBag.MensajeExtra = "El curso ya existe, intente otro nombre.";
                    return View("Create", curso);
                }
            }
            catch (Exception e)
            {
                return MultiCurso();
            }

            return null;
        }
    }
}