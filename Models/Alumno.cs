using System;
using System.Collections.Generic;

namespace AspIron.Models
{
    public class Alumno : AcademyBase
    {
        public List<Evaluacion> Evaluaciones { set; get; }
        // relation with curso
        public string CursoId { set; get; }
        public Curso Curso { set; get; }
    }
}