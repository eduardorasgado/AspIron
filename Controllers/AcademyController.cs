using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspIron.Models;

namespace AspIron.Controllers
{
    public class AcademyController : Controller
    {
        private readonly AcademyContext _context;

        public AcademyController(AcademyContext context)
        {
            _context = context;
        }

        // GET: Academy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Academies.ToListAsync());
        }

        // GET: Academy/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academy = await _context.Academies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academy == null)
            {
                return NotFound();
            }

            return View(academy);
        }

        // GET: Academy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Academy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AñoCreacion,Pais,Ciudad,TipoEscuela,Direccion,Nombre,Id")] Academy academy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academy);
        }

        // GET: Academy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academy = await _context.Academies.FindAsync(id);
            if (academy == null)
            {
                return NotFound();
            }
            return View(academy);
        }

        // POST: Academy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AñoCreacion,Pais,Ciudad,TipoEscuela,Direccion,Nombre,Id")] Academy academy)
        {
            if (id != academy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademyExists(academy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(academy);
        }

        // GET: Academy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academy = await _context.Academies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academy == null)
            {
                return NotFound();
            }

            return View(academy);
        }

        // POST: Academy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var academy = await _context.Academies.FindAsync(id);
            _context.Academies.Remove(academy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademyExists(string id)
        {
            return _context.Academies.Any(e => e.Id == id);
        }
    }
}
