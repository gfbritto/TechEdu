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
        private readonly colegioContext _context;

        public HomeController(colegioContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Email, Senha")] Usuario user)
        {

            var autenticatedUser = _context.Usuarios.Include(roles => roles.PapelPessoa)
                .SingleOrDefault(u => u.Email.Equals(user.Email) && u.Senha.Equals(user.Senha));

            if (autenticatedUser != null)
            {
                await new AuthService().Login(HttpContext, autenticatedUser);
                return View("Index");
            }
            return View("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}