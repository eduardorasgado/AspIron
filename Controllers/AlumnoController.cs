using System.Collections.Generic;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspIron.Controllers
{
    public class AlumnoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var alumno = new Alumno();
            
            return View(alumno);
        }

        public IActionResult MultiAlumno()
        {
            var listaAlumnos = new List<Alumno>();
            return View(listaAlumnos);
        }
    }
}