using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TechEdu.Models;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ColegioContext _context;

        public HomeController(ColegioContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(bool erroLogin)
        {
            if (erroLogin)
            {
                ViewBag.Erro = "Nickname e/ou senha estão incorretos";
            }

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> AuthUser([Bind("Email, Senha")] Usuario user)
        {
            var autenticatedUser = _context.Usuarios.Include(roles => roles.PapelPessoa)
                .SingleOrDefault(u => u.Email.Equals(user.Email) && u.Senha.Equals(user.Senha));

            if (autenticatedUser != null)
            {
                await new AuthService().Login(HttpContext, autenticatedUser);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", new { erroLogin = true });
        }
    }
}