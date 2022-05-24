using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechEdu.Models.DataAccess.DataObjects;

namespace TechEdu.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ColegioContext _context;

        public HomeController(ColegioContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}