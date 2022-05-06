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
    public class StudentController : Controller
    {
        private readonly ColegioContext _context;

        public StudentController(ColegioContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var colegioContext = _context.Alunos.Include(a => a.Endereco).Include(a => a.Responsavel).Include(a => a.Turma);
            return View(await colegioContext.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Endereco)
                .Include(a => a.Responsavel)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Logradouro");
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id");
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,TurmaId,Ra,EnderecoId,Cpf,Nascimento,ResponsavelId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Logradouro", aluno.EnderecoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Student/Edit/5
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
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Logradouro", aluno.EnderecoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", aluno.TurmaId);
            return View(aluno);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TurmaId,Ra,EnderecoId,Cpf,Nascimento,ResponsavelId")] Aluno aluno)
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
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "Logradouro", aluno.EnderecoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavels, "Id", "Id", aluno.ResponsavelId);
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "Id", "Id", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Endereco)
                .Include(a => a.Responsavel)
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
