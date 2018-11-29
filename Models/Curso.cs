using System;
using System.Collections.Generic;

namespace AspIron.Models
{
    /// <summary>
    /// Clase que representa un curso dentro de una lista de cursos
    /// que tiene una Escuela.
    /// </summary>
    public class Curso : AcademyBase
    {   
        public TiposJornadas Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { set; get; }
        

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