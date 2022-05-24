using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechEdu.Models.DataAccess.DataObjects;
using TechEdu.Services.Interfaces;

namespace TechEdu.Controllers
{
    public class AccountController : Controller
    {
        private readonly ColegioContext _context;
        private readonly ICryptographyService _cryptographyService;

        public AccountController(ColegioContext context, ICryptographyService cryptographyService)
        {
            _context = context;
            _cryptographyService = cryptographyService;
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
            user.Senha = await _cryptographyService.EncryptStringAsync(user.Senha);

            var autenticatedUser = await _context.Usuarios.Include(roles => roles.PapelPessoa)
                .SingleOrDefaultAsync(u => u.Email.Equals(user.Email) && u.Senha.Equals(user.Senha));

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
