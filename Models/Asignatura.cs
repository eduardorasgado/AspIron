using System;
using AspIron.Models;

namespace AspIron.Models
{
    /// <summary>
    /// Un curso debe de tener asignaturas
    /// </summary>
    public class Asignatura : AcademyBase
    {
        public override string ToString()
        {
            return $"Nombre: {Nombre}";
        }
    }
}