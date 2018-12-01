using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace AspIron.Models
{
    /// <summary>
    /// This class will handle all about connection to database
    /// DbContext should be included
    /// </summary>
    public class AcademyContext : DbContext
    {
        // list of academies
        // to create all the tables
        public DbSet<Academy> Academies { set; get; }
        public DbSet<Asignatura> Asignaturas { set; get; }
        public DbSet<Alumno> Alumnos { set; get; }
        public DbSet<Curso> Cursos { set; get; }
        public DbSet<Evaluacion> Evaluaciones { set; get; }

        public AcademyContext(DbContextOptions<AcademyContext> options)
            : base(options)
        {
            // base constructor
        }
    }
}