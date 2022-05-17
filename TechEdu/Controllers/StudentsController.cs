#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ColegioContext _context;

        public StudentsController(ColegioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var colegioContext = _context.Alunos.Include(a => a.Responsavel).Include(a => a.Turma);
            return View(await colegioContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Responsavel)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Students/Create
        []
        public IActionResult Create()
        {
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Nome");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,Ra,ResponsavelId,PrimeiroNome,UltimoNome,DataNascimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Nome", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Nome", aluno.TurmaId);
            return View(aluno);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = TechEduRoles.Master)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurmaId,Ra,ResponsavelId,PrimeiroNome,UltimoNome,DataNascimento")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
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
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Nome", aluno.TurmaId);
            return View(aluno);
        }

        [Authorize(Roles = TechEduRoles.Master)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Responsavel)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = TechEduRoles.Master)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
