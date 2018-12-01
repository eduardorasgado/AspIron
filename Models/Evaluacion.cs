using System;

namespace AspIron.Models
{
    public class Evaluacion : AcademyBase
    {
        // Entity framework recommends that 
        // if a relation is defined we should define
        // a ModelNameId and a Model Model variables
        public string AlumnoId { set; get; }
        public Alumno Alumno { set; get; }
        
        public string AsignaturaId { set; get; }
        public Asignatura Asignatura {set; get; }
        public float Nota { set; get; }
        
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Nota: {Nota}, Asignatura: {Asignatura}";
        }
    }
}