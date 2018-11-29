using System.Collections.Generic;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspIron.Controllers
{
    public class AlumnoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var alumno = new Alumno();
            alumno.Nombre = "Pancho Perez Jacome";
            
            return View(alumno);
        }

        public IActionResult MultiAlumno()
        {
            var listaAlumnos = new List<Alumno>();
            listaAlumnos.AddRange(GenerarAlumnosAlAzar());
            
            return View(listaAlumnos);
        }
        
        // UTILITIES
        private List<Alumno> GenerarAlumnosAlAzar()
        {
            string[] nombres = {"Eduardo", "Mario", "Francisco", "Manuel", "Fabian", "Mariana", "Victor"};
            string[] apellido1 = {"Rasgado", "Guzman", "Olmedo", "Santiago", "Peña", "Jimenez", "Amampour", "Bartolo"};
            string[] apellido2 = {"Ruiz", "Mendoza", "Cabrera", "Manrriquez", "Torres", "Santiago", "Alvarado"};
            
            // Utilizamos linq para crear combinatorias random de nombres
            // linq son expresiones de consultas
            // Language-Integrated Query
            //
            // aqui estamos creando un producto cartesiano con los arrays de strings arriba escritos
            var listaAlumnos = from n in nombres
                from a1 in apellido1
                from a2 in apellido2
                select new Alumno{Nombre = $"{n} {a1} {a2}"};
            // retornamos para asignarlo a cada uno de los cursos
            // retorna cierta cantidad y en un orden basado en el UniqueId
            return listaAlumnos.OrderBy((alumno) => alumno.UniqueId)
                .ToList();
        }
    }
}