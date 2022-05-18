using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    public class AccountController : Controller
    {
        private readonly ColegioContext _context;

        public AccountController(ColegioContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(bool erroLogin)
        {
            if (erroLogin)
            {
                ViewBag.Erro = "Nickname e/ou senha estão incorretos";
            }

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", new { erroLogin = true });
        }

        [Authorize]
        public async Task<IActionResult> Logoff()
        {
            await new AuthService().Logoff(HttpContext);
            return RedirectToAction("Login", "Account");
        }
    }
}
