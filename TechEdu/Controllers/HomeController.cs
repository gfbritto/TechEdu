using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Login()
        {
            return PartialView("_Login");
        }
    }
}