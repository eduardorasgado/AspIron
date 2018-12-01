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

            // adding data if we have no data
            model_builder.Entity<Academy>().HasData(escuela);
            model_builder.Entity<Asignatura>().HasData(
                //
                new Asignatura
                {
                    Nombre = "Programación Básica",
                    FechaDeLanzamiento = generateRandomUTC()
                },
                new Asignatura
                {
                    Nombre = "Cálculo Diferencial",
                    FechaDeLanzamiento = generateRandomUTC()
                },
                new Asignatura
                {
                    Nombre = "Electrónica Digital",
                    FechaDeLanzamiento = generateRandomUTC()
                },
                new Asignatura
                {
                    Nombre = "Lenguajes de Programación",
                    FechaDeLanzamiento = generateRandomUTC()
                }
            );
            // HasData just receives arrays so we have to
            // convert from collection to array
            model_builder.Entity<Alumno>().HasData(
                    GenerarAlumnosAlAzar().ToArray()
                );

        }
        
        // UTILITIES-----------
        
        private static DateTime generateRandomUTC()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;
            
            return start.AddDays((gen.Next(range)))
                .AddHours(gen.Next(0,12));
        }
        
        private List<Alumno> GenerarAlumnosAlAzar()
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
                select new Alumno{Nombre = $"{n} {a1} {a2}"};
            // retornamos para asignarlo a cada uno de los cursos
            // retorna cierta cantidad y en un orden basado en el Id
            return listaAlumnos.OrderBy((alumno) => alumno.Id)
                .ToList();
        }
    }
}