using System;
using System.Collections.Generic;
using System.Linq;
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
        
        /*Seeding data in table Academy*/
        protected override void OnModelCreating(ModelBuilder model_builder)
        {
            // do everything in rule by default
            base.OnModelCreating(model_builder);
            // seeding data

            var escuela = new Academy("AspIron", 2017);
            escuela.Ciudad = "Cd del Carmén, Campeche";
            escuela.Pais = "México";
            escuela.TipoEscuela = TiposEscuelas.Online;
            escuela.Direccion = "Av. Naufrago #104, Colonia Morelos. Zona Cocoa.";
            
            // load cursos to academy
            CargarCursos(out var cursos, escuela);
            
            //  for each curso load asignaturas
            var asignaturas = CargarAsignaturas(cursos);
            // and load alumnos
            var generator = new Random();
            var alumnos = CargarAlumnos(cursos, generator);
            
            // loading evaluaciones
            // RETO
            
            // adding data if we have no data
            model_builder.Entity<Academy>().HasData(escuela);
            model_builder.Entity<Curso>().HasData(cursos.ToArray());
            model_builder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            model_builder.Entity<Alumno>().HasData(alumnos.ToArray());

        }
        
        /// <summary>
        /// UTILITIES is a bunch of methods AcademyContext uses to
        /// prototype and test Entity framework to Inmemory DB
        /// </summary>
        /// <param name="cursos"></param>
        /// <param name="generator"></param>
        #region Utilities
        
        private List<Alumno> CargarAlumnos(List<Curso> cursos, Random generator)
        {
            var alumnosFull = new List<Alumno>();
            
            foreach (var curso in cursos)
            {
                // random alumnos quantity for each curso
                var numAlumnos = generator.Next(10, 30);
                var listaAlumnosTemp = GenerarAlumnosAlAzar(numAlumnos, curso);
                alumnosFull.AddRange(listaAlumnosTemp);
            }

            return alumnosFull;
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaFull = new List<Asignatura>();
            
            foreach (var curso in cursos)
            {
                
                var tempList = new List<Asignatura>
                {
                    new Asignatura
                    {
                        Nombre = "Programación Básica",
                        CursoId = curso.Id,
                        FechaDeLanzamiento = generateRandomUTC()
                    },
                    new Asignatura
                    {
                        Nombre = "Cálculo Diferencial",
                        CursoId = curso.Id,
                        FechaDeLanzamiento = generateRandomUTC()
                    },
                    new Asignatura
                    {
                        Nombre = "Patrones de Diseño",
                        CursoId = curso.Id,
                        FechaDeLanzamiento = generateRandomUTC()
                    },
                    new Asignatura
                    {
                        Nombre = "Lenguajes de Programación",
                        CursoId = curso.Id,
                        FechaDeLanzamiento = generateRandomUTC()
                    }
                };

                listaFull.AddRange(tempList);
            }

            return listaFull;
        }

        private static void CargarCursos
            (out List<Curso> cursos, Academy academia)
        {
            var gen = new Random();
            cursos = new List<Curso>
            {
                new Curso
                {
                    Nombre = "101", Jornada = TiposJornadas.Mañana,
                    Direccion = $"Calle #{gen.Next(0, 100)} {gen.Next(10, 20)}° Avenida",
                    AcademyId = academia.Id,
                },
                new Curso
                {
                    Nombre = "201", Jornada = TiposJornadas.Tarde,
                    Direccion = $"Calle #{gen.Next(0, 100)} {gen.Next(10, 20)}° Avenida",
                    AcademyId = academia.Id,
                },
                new Curso
                {
                    Nombre = "301", Jornada = TiposJornadas.Noche,
                    Direccion = $"Calle #{gen.Next(0, 100)} {gen.Next(10, 20)}° Avenida",
                    AcademyId = academia.Id,
                },
                new Curso
                {
                    Nombre = "401", Jornada = TiposJornadas.Mañana,
                    Direccion = $"Calle #{gen.Next(0, 100)} {gen.Next(10, 20)}° Avenida",
                    AcademyId = academia.Id,
                },
                new Curso
                {
                    Nombre = "501", Jornada = TiposJornadas.Weekend,
                    Direccion = $"Calle #{gen.Next(0, 100)} {gen.Next(10, 20)}° Avenida",
                    AcademyId = academia.Id,
                }
            };
        }
        
        private static DateTime generateRandomUTC()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;
            
            return start.AddDays((gen.Next(range)))
                .AddHours(gen.Next(0,12));
        }
        
        private static List<Alumno> GenerarAlumnosAlAzar
            (int alumnosQuantity, Curso curso)
        {
            string[] nombres = {"Eduardo", "Mario", "Francisco", "Manuel", "Fabian", "Mariana", "Victor"};
            string[] apellido1 = {"Rasgado", "Guzman", "Olmedo", "Santiago", "Peña", "Jimenez", "Amampour", "Bartolo"};
            string[] apellido2 = {"Ruiz", "Mendoza", "Cabrera", "Manrriquez", "Torres", "Santiago", "Alvarado"};
            
            // Utilizamos linq para crear combinatorias random de nombres
            // linq son expresiones de consultas
            // Language-Integrated Query
            //
            // aqui estamos creando un producto cartesiano con los arrays de strings arriba escritos
            var listaAlumnos = from n in nombres
                from a1 in apellido1
                from a2 in apellido2
                select new Alumno
                {
                    Nombre = $"{n} {a1} {a2}",
                    // loading relation
                    CursoId = curso.Id
                };
            // retornamos para asignarlo a cada uno de los cursos
            // retorna cierta cantidad y en un orden basado en el Id
            return listaAlumnos.OrderBy((alumno) => alumno.Id).Take(alumnosQuantity)
                .ToList();
        }
        #endregion
    }
}