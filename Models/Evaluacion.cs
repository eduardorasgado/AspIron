using System;

namespace AspIron.Models
{
    public class Evaluacion : AcademyBase
    {
        public Alumno Alumno { set; get; }
        public Asignatura Asignatura {set; get; }
        public float Nota { set; get; }
        
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Nota: {Nota}, Asignatura: {Asignatura}";
        }
    }
}