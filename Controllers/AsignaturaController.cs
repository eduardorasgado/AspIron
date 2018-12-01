using System;
using AspIron.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspIron.Controllers
{
    public class AsignaturaController : Controller
    {   
        private AcademyContext _context;
        
        public AsignaturaController(AcademyContext context)
        {
            _context = context;
        }
        // routing by attribute
        // should be after constructor
        [Route("Asignatura/Index/{asignaturaId}")]
        
        public IActionResult Index(string asignaturaId)
        {        
            //
            var assig = from asignatura in _context.Asignaturas
                where asignatura.Id == asignaturaId
                select asignatura;
            
            return View(assig.SingleOrDefault());
        }
        
        /// <summary>
        /// TO have a global view and management of all
        /// the asignaturas in the Academy
        /// GET
        /// </summary>
        /// <returns></returns>
        public IActionResult MultiAsignatura()
        {
            var allAsignaturas = _context.Asignaturas.ToList();
            // we can specify what view do we want to send the data to
            return View("MultiAsignatura", allAsignaturas);
        }
    }
}