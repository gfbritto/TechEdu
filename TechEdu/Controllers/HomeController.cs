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
            LoadDashBoards();
            return View();
        }

        private void LoadDashBoards()
        {
            ViewBag.classes = _context.Turmas;
            ViewBag.totalStudents = _context.Alunos.Count();
            ViewBag.totalClasses = _context.Turmas.Count();
            ViewBag.totalSubjects = _context.Alunos.Count();
            ViewBag.totalTeachers = _context.Professors.Count();
        }
    }
}