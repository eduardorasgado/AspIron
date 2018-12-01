using System;
using System.Collections.Generic;
using AspIron.Models;

namespace AspIron.Models
{
    /// <summary>
    /// Un curso debe de tener asignaturas
    /// </summary>
    public class Asignatura : AcademyBase
    {
        public DateTime FechaDeLanzamiento { set; get; }
        
        // relation is automatically detected
        public string CursoId { set; get; }
        public Curso Curso { set; get; }
        
        // down relation
        public List<Evaluacion> Evaluaciones { set; get; }
        
        public override string ToString()
        {
            return $"Nombre: {Nombre}";
        }
    }
}