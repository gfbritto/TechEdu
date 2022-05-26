using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models;
using TechEdu.Models.DataAccess.DataObjects;
using TechEdu.Services.Interfaces;

namespace TechEdu.Controllers
{
    [Authorize(Roles = TechEduRoles.Master)]
    public class UsersController : Controller
    {
        private readonly ColegioContext _context;
        private readonly ICryptographyService _cryptographyService;

        public UsersController(ColegioContext context, ICryptographyService cryptographyService)
        {
            _context = context;
            _cryptographyService = cryptographyService;
        }

        public async Task<IActionResult> Index()
        {
            var colegioContext = _context.Usuarios.Include(u => u.PapelPessoa);
            return View(await colegioContext.ToListAsync());
        }

        public IActionResult Login()
        {
            return PartialView("_Login");
        }


        public IActionResult Create()
        {
            ViewData["PapelPessoaId"] = new SelectList(_context.PapelPessoas, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Senha,Nome,PapelPessoaId")] Usuario usuario)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                usuario.Senha = await _cryptographyService.EncryptStringAsync(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PapelPessoaId"] = new SelectList(_context.PapelPessoas, "Id", "Descricao", usuario.PapelPessoaId);
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Senha = await _cryptographyService.DecryptStringAsync(usuario.Senha);
            ViewData["PapelPessoaId"] = new SelectList(_context.PapelPessoas, "Id", "Descricao", usuario.PapelPessoaId);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Senha,Nome,PapelPessoaId")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = await _cryptographyService.EncryptStringAsync(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["PapelPessoaId"] = new SelectList(_context.PapelPessoas, "Id", "Descricao", usuario.PapelPessoaId);
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.PapelPessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ColegioContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
