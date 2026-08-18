using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechAcadStudentsMVC.Models;

namespace TechAcadStudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Instructor(int id)
        {
            ViewBag.Id = id;
            Instructor localInstructor = new Instructor()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            return View(localInstructor);
        }
        public IActionResult Instructors()
        {
            List<Instructor> instructors = new List<Instructor>()
            {
                new Instructor() { Id = 1, FirstName = "John", LastName = "Doe" },
                new Instructor() { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Instructor() { Id = 3, FirstName = "Bob", LastName = "Johnson" }
            };
            return View(instructors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
