using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ColegioContext _context;

        public SchoolController(ColegioContext context)
        {
            _context = context;
        }

        // GET: School
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colegios.ToListAsync());
        }

        // GET: School/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colegio == null)
            {
                return NotFound();
            }

            return View(colegio);
        }

        // GET: School/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: School/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeColegio")] Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colegio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colegio);
        }

        // GET: School/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios.FindAsync(id);
            if (colegio == null)
            {
                return NotFound();
            }
            return View(colegio);
        }

        // POST: School/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeColegio")] Colegio colegio)
        {
            if (id != colegio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colegio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColegioExists(colegio.Id))
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
            return View(colegio);
        }

        // GET: School/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colegio = await _context.Colegios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colegio == null)
            {
                return NotFound();
            }

            return View(colegio);
        }

        // POST: School/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colegio = await _context.Colegios.FindAsync(id);
            _context.Colegios.Remove(colegio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColegioExists(int id)
        {
            return _context.Colegios.Any(e => e.Id == id);
        }
    }
}
