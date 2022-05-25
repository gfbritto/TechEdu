using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    public class ClassesSubjectsController : Controller
    {
        private readonly ColegioContext _context;

        public ClassesSubjectsController(ColegioContext context)
        {
            _context = context;
        }

        // GET: ClassesSubjects
        public async Task<IActionResult> Index()
        {
            var colegioContext = _context.TurmaMateria.Include(t => t.Materia).Include(t => t.Turma);
            return View(await colegioContext.ToListAsync());
        }

        // GET: ClassesSubjects/Create
        public IActionResult Create()
        {
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nome");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Nome");
            return View();
        }

        // POST: ClassesSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,MateriaId")] TurmaMaterium turmaMaterium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmaMaterium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nome", turmaMaterium.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", turmaMaterium.TurmaId);
            return View(turmaMaterium);
        }

        // GET: ClassesSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurmaMateria == null)
            {
                return NotFound();
            }

            var turmaMaterium = await _context.TurmaMateria.FindAsync(id);
            if (turmaMaterium == null)
            {
                return NotFound();
            }
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nome", turmaMaterium.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", turmaMaterium.TurmaId);
            return View(turmaMaterium);
        }

        // POST: ClassesSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurmaId,MateriaId")] TurmaMaterium turmaMaterium)
        {
            if (id != turmaMaterium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaMaterium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaMateriumExists(turmaMaterium.Id))
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
            ViewData["MateriaId"] = new SelectList(_context.Materia, "Id", "Nome", turmaMaterium.MateriaId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", turmaMaterium.TurmaId);
            return View(turmaMaterium);
        }

        // GET: ClassesSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurmaMateria == null)
            {
                return NotFound();
            }

            var turmaMaterium = await _context.TurmaMateria
                .Include(t => t.Materia)
                .Include(t => t.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaMaterium == null)
            {
                return NotFound();
            }

            return View(turmaMaterium);
        }

        // POST: ClassesSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurmaMateria == null)
            {
                return Problem("Entity set 'ColegioContext.TurmaMateria'  is null.");
            }
            var turmaMaterium = await _context.TurmaMateria.FindAsync(id);
            if (turmaMaterium != null)
            {
                _context.TurmaMateria.Remove(turmaMaterium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaMateriumExists(int id)
        {
          return (_context.TurmaMateria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
