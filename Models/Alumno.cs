using System;
using System.Collections.Generic;

namespace AspIron.Models
{
    public class Alumno : AcademyBase
    {
        public List<Evaluacion> Evaluaciones { set; get; }
    }
}