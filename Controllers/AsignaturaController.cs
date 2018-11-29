using System;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspIron.Controllers
{
    public class AsignaturaController : Controller
    {
        /// <summary>
        /// TO have a global view and management of all
        /// the asignaturas in the Academy
        /// GET
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var allAsignaturas = new List<Asignatura>
            {
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
            };
            return View(allAsignaturas);
        }

        private DateTime generateRandomUTC()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2018, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays((gen.Next(range)));
        }
    }
}