using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspIron.Models
{
    /// <summary>
    /// Clase que representa un curso dentro de una lista de cursos
    /// que tiene una Escuela.
    /// </summary>
    public class Curso : AcademyBase
    {
        // Data Anotation to declare Nombre attribute to be 
        // required
        [Required]
        // the virtual attribute in base
        public override string Nombre { get; set; }
        
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { set; get; }
        
        // engine automatically knows and detect what model
        // we are using by Convention: ModelNameId
        public string AcademyId { set; get; }
        // to sustract academy with just the Curso instance
        public Academy Academy { set; get; }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Jornada: {Jornada}";
        }

        public void LimpiarLugar()
        {
            Console.WriteLine("Limpiando la dirección");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}