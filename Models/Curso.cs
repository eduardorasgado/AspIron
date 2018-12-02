using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

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
        [Required(ErrorMessage= "El nombre del curso es requerido")]
        // max size
        [StringLength(5, ErrorMessage= "El nombre del curso debe de " +
                                       "contener un máximo de cinco caracteres")]
        [MinLength(3, ErrorMessage = "La longitud minima del nombre es de" +
                                     " 3 caracteres")]
        // the virtual attribute in base
        public override string Nombre { get; set; }
        
        [Required(ErrorMessage = "La jornada es requerida")]
        [EnumDataType(typeof(TiposJornadas),ErrorMessage = "La jornada es requerida")]
        public TiposJornadas Jornada { get; set; }
        
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        
        [Required(ErrorMessage= "La dirección es requerido")]
        [MinLength(10, ErrorMessage= "La longitud minima de la " +
                                     "dirección es de 10 caracteres")]
        [Display(Prompt = "Direccion de correspondencia", Name = "Domicilio")]
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